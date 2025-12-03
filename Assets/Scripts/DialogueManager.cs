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
    public GameObject textBox;
    public GameObject customButton;
    public GameObject twoOptionPanel;
    public GameObject fourOptionPanel;
    public bool isTalking = false;
    public static Story story;
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
            Debug.Log("Prefix "+ prefix);
            Debug.Log("Parameters " + parameters[0]);
            switch (prefix)
            {
                case "level":
                    if (parameters.Length >= 1)
                        SceneManager.LoadScene(parameters[0]);
                    break;

                case "name":
                    if (parameters.Length >= 1)
                        nametag.text = parameters[0];
                    break;
                case "playhappy":
                {
                        FriendshipStruct friendStruct = InformationManager.Instance.GetFriendshipStruct(parameters[0]);
                        if (friendStruct != null)
                        {
                            friendStruct.character.GetComponent<Animator>().SetTrigger("playHappy");
                        }
                    
                        break;
                }
                       
            }
        }
    }
    

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        FriendshipStruct friendStruct = InformationManager.Instance.GetFriendshipStruct(nametag.text);
        if( friendStruct != null){
                friendStruct.character.GetComponent<Animator>().SetBool("playTalk", true);
        }
        
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }

        if( friendStruct != null)
        {
            friendStruct.character.GetComponent<Animator>().SetBool("playTalk", false);
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
            Debug.Log(index);
            AdvanceDialogue();
            twoOptionPanel.SetActive(false);

        }
        else if (numberOfChoices == 4)
        {
            Debug.Log(index);
            AdvanceDialogue();
            fourOptionPanel.SetActive(false);

        }
    }
    void FinishDialogue()
    {
        Debug.Log("FinishDialogue");
        isInDialogue = false;
        textBox.SetActive(false);
        storyStarted = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
   
