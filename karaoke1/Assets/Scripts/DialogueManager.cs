using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance;
    public GameObject textBox;
    public GameObject customButton;
    public GameObject twoOptionPanel;
    public GameObject fourOptionPanel;
    public bool isTalking = false;
    static Story story;
    Text nametag;
    Text message;
    List<string> tags;
    static Choice choiceSelected;
    bool storyStarted = false;
    int numberOfChoices;
    GameObject character;

    void Awake()
    {
        Instance = this;
    }
    public void StartStory(GameObject chara, TextAsset otherinkJSONAsset)
    {
        if (!storyStarted)
        {
            character = chara;
            story = new Story(otherinkJSONAsset.text);
            nametag = textBox.transform.GetChild(0).GetComponent<Text>();
            message = textBox.transform.GetChild(1).GetComponent<Text>();
            tags = new List<string>();
            choiceSelected = null;
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
    public void StartStory(GameObject chara, TextAsset otherinkJSONAsset, string Knotname)
    {
        if (!storyStarted)
        {
            character = chara;
            story = new Story(otherinkJSONAsset.text);
            nametag = textBox.transform.GetChild(0).GetComponent<Text>();
            message = textBox.transform.GetChild(1).GetComponent<Text>();
            tags = new List<string>();
            choiceSelected = null;
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
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "level":
                    SceneManager.LoadScene(param);
                    break;
                case "name":
                    nametag.text = param;
                    break;
                case "friend":
                    if(int.Parse(param) > 0)
                    {
                        character.GetComponent<MeshRenderer>().material = character.GetComponent<CharResources>().sprites[2];
                        Invoke("ReturnToOriginal", 1);
                    }
                    if(int.Parse(param) < 0)
                    {        
                        character.GetComponent<MeshRenderer>().material = character.GetComponent<CharResources>().sprites[1];
                        Invoke("ReturnToOriginal", 1);                    
                    }
                    break;
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
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
        textBox.SetActive(false);
        storyStarted = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void ReturnToOriginal()
    {
        character.GetComponent<MeshRenderer>().material = character.GetComponent<CharResources>().sprites[0];
    }
}
