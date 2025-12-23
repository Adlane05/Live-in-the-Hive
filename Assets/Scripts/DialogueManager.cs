using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
public class DialogueManager : MonoBehaviour
{
    public static bool  isInDialogue = false;
    public static DialogueManager Instance;
    public GameObject cameraManager;
    public GameObject mainCamera;
    public GameObject textBox;
    public Text questText;
    public GameObject customButton;
    public GameObject twoOptionPanel;
    public GameObject fourOptionPanel;
    public bool isTalking = false;
    public static Story story;
    public AudioSource musicplayer;
    public AudioSource goodSound;
    public AudioSource badSound;
    Text nametag;
    Text message;
    List<string> tags;
    bool storyStarted = false;
    int numberOfChoices;
    GameObject character;
    CharResources resources;

    void Awake()
    {
        Instance = this;
    }
    public void StartStory(TextAsset otherinkJSONAsset)
    {
        if (!storyStarted)
        {
            
            story = new Story(otherinkJSONAsset.text);
            //story.variablesState["friendship"] = chara.GetComponent<CharResources>().friendshipPoints;
            nametag = textBox.transform.GetChild(0).GetComponent<Text>();
            message = textBox.transform.GetChild(1).GetComponent<Text>();
            tags = new List<string>();
            storyStarted = true;
            StartStory();
        }
    }

    public void StartStory()
    {
        cameraManager.SetActive(true);
        cameraManager.transform.position = mainCamera.transform.position;
        cameraManager.transform.rotation = mainCamera.transform.rotation;

        Camera.main.gameObject.SetActive(false);
        Cursor.visible = true;
        textBox.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        AdvanceDialogue();
    }
    public void StartStory( TextAsset otherinkJSONAsset, string Knotname)
    {
        if (!storyStarted)
        {
            story = new Story(otherinkJSONAsset.text);
            nametag = textBox.transform.GetChild(0).GetComponent<Text>();
            message = textBox.transform.GetChild(1).GetComponent<Text>();
            tags = new List<string>();
            storyStarted = true;
            story.ChoosePathString(Knotname);
            StartStory();
        }
    }
    private void Update()
    {
        if (!storyStarted) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            if (story.currentChoices.Count > 0)
                return;

            AdvanceDialogue();
        }
    }
    void AdvanceDialogue()
    {
        if (story.canContinue)
        {
            
            isInDialogue = true;
            string currentSentence = story.Continue();
            ParseTags();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence));

            if (story.currentChoices.Count > 0)
                StartCoroutine(ShowChoices());
        }
        else
        {
            if (story.currentChoices.Count == 0)
                FinishDialogue();
        }
    }

    void ParseTags()
    {
        tags = story.currentTags;
        foreach (string t in tags)
        {
            string[] parts = t.Split(' ');

            if (parts.Length == 0)
            continue;

            string prefix = parts[0].ToLower();

            // Everything after the prefix is parameters
            string[] parameters = parts.Skip(1).ToArray();
            switch (prefix)
            {
                case "end":
                {
                    if(parameters[0] == "desolation"){
                        EndingController.Instance.Desolation.SetActive(false);
                        goodSound.Play();
                    } if(parameters[0] == "Marya"){
                        EndingController.Instance.Marya.SetActive(true);
                        badSound.Play();
                    }
                    if(parameters[0] == "Shabloing1"){
                        EndingController.Instance.Shabloing1.SetActive(true);
                        goodSound.Play();
                    } 
                    if(parameters[0] == "Shabloing2"){
                        EndingController.Instance.Shabloing2.SetActive(true);
                        goodSound.Play();
                    }
                    if(parameters[0] == "Shabloing3"){
                        EndingController.Instance.Shabloing3.SetActive(true);
                        goodSound.Play();
                    }
                    if(parameters[0] == "Shabloings"){
                        EndingController.Instance.Shabloings.SetActive(true);
                        goodSound.Play();
                    }
                    if(parameters[0] == "spin"){
                        EndingController.Instance.animator.SetTrigger("spin");
                        goodSound.Play();
                    }
                    if(parameters[0] == "Door"){
                        EndingController.Instance.DoorCover.SetActive(true);
                        badSound.Play();
                    }
                    break;
                }
                case "door":
                {
                    if(parameters[0] == "gone"){
                        GameObject.Find("Access Door").SetActive(false);
                        badSound.Play();
                    }
                    if(parameters[0] == "back"){
                        GameObject.Find("Access Door").SetActive(true);
                        badSound.Play();
                    }
                    break;
                }
                 case "pickup":
                {
                     InventoryItem item = InformationManager.Instance.allItems.Find(i => i.itemId == parameters[0]);
                    
                    if(InventoryManager.Instance.AddItem(item))
                        goodSound.Play();
                    else{
                        badSound.Play();
                    }
                    break;
                }
                case "remove":
                {                    
                    if(InventoryManager.Instance.RemoveItem(parameters[0]))
                        goodSound.Play();
                    else{
                        badSound.Play();
                    }
                    break;
                }
                case "kristen":
                if(parameters[0] == "away"){
                    var character = InformationManager.Instance.GetCharacter("Kristen");
                if (character != null)
                {
                    character.GetAnimator().SetTrigger("sendAway");
                }
                    Invoke("changeKristen", 3);
                }
                if(parameters[0] == "there"){
                    KristenController.Instance.meshRenderer.material = KristenController.Instance.failKristen;

                }
                if(parameters[0] == "notthere"){
                    KristenController.Instance.meshRenderer.material = KristenController.Instance.normalKristen;
                }
                if(parameters[0] == "talk"){
                    KristenController.Instance.meshRenderer.material = KristenController.Instance.winKristen;

                }
                break;
                case "lost":
                if(parameters[0] == "stop"){
                    NPCAI.Instance.OnPlayerInteract();
                }
                if(parameters[0] == "home"){
                    NPCAI.Instance.OnItemGiven();

                }
                if(parameters[0] == "patrol"){
                    NPCAI.Instance.BackToPatrol();

                }
                if(parameters[0] == "follow"){
                    NPCAI.Instance.StartFollowing();

                }
                if(parameters[0] == "yes"){
                    InformationManager.Instance.IsHelping = true;
                }
                if(parameters[0] == "no"){
                    InformationManager.Instance.IsHelping = false;
                }
                break;
                case "music":
                musicplayer.Play();
                break;
                case "level":
                    
                    if (parameters.Length >= 1)
                        SceneManager.LoadScene(parameters[0]);
                        FinishDialogue();
                    break;

                case "name":
                    if (parameters.Length >= 1)
                        nametag.text = parameters[0];
                    break;
                case "quest":
                if (questText == null)
                questText = GameObject.Find("QuestText").GetComponent<Text>();

                questText.text = string.Join(" ", parameters);
                break;
                case "hell":
                GameObject.Find("Player").transform.position = GameObject.Find("Player").transform.position + new Vector3(0, -3, 0);

                
                break;
                case "play":
                {
                    var character = InformationManager.Instance.GetCharacter(parameters[1]);
                    if (character != null)
                    {
                    character.GetAnimator().SetTrigger(parameters[0]);
                    }            
                        break;
                }
                
                case "playsad":
                {               
                        var character = InformationManager.Instance.GetCharacter("Qinyi");
                        if (character != null)
                        {
                            if(parameters[0] == "true")
                            character.GetAnimator().SetBool("sad", true );
                        if(parameters[0] == "false")
                            character.GetAnimator().SetBool("sad", false );
                        }
                    
                        break;
                }
                case "camera":
                {
                    int cameraIndex = int.Parse(parameters[0]);
                    if (parameters.Length > 1){
                        float moveDuration = float.Parse(parameters[1]); 
                        CameraSwitchConversation.Instance.moveDuration = moveDuration;
                        
                        CameraSwitchConversation.Instance.StartMove(cameraIndex);
                    }else 
                        CameraSwitchConversation.Instance.StartMove(cameraIndex);
                    
                        break;
                }
                       
            }
        }
    }
    

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        var character = InformationManager.Instance.GetCharacter(nametag.text);
        if( character != null){
                character.GetAnimator().SetBool("playTalk", true);
        }
        
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }

        if( character != null)
        {
            character.GetAnimator().SetBool("playTalk", false);
        }
    }
    IEnumerator ShowChoices()
    {
        List<Choice> _choices = story.currentChoices;
        if (_choices.Count == 2)
        {
            numberOfChoices = 2;
            twoOptionPanel.SetActive(true);
            twoOptionPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = _choices[0].text;
            twoOptionPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = _choices[1].text;
            yield return null;
        }
        if (_choices.Count == 4)
        {
            numberOfChoices = 4;
            fourOptionPanel.SetActive(true);
            fourOptionPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = _choices[0].text;
            fourOptionPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = _choices[1].text;
            fourOptionPanel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = _choices[2].text;
            fourOptionPanel.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = _choices[3].text;

            yield return null;
        }

    }
    public void SetDecision(int index)
    {
        EventSystem.current.SetSelectedGameObject(null);
        story.ChooseChoiceIndex(index);
        if (numberOfChoices == 2)
        {
            AdvanceDialogue();
            twoOptionPanel.SetActive(false);

        }
        else if (numberOfChoices == 4)
        {
            AdvanceDialogue();
            fourOptionPanel.SetActive(false);

        }
    }
    void FinishDialogue()
    {
        CameraSwitchConversation.Instance.gameObject.SetActive(false);
        mainCamera.SetActive(true);
        isInDialogue = false;
        textBox.SetActive(false);
        storyStarted = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void changeKristen(){
        KristenController.Instance.meshRenderer.material = KristenController.Instance.failKristen;

    }
}
   
