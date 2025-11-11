using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
public class DialogueManager : MonoBehaviour
{
    public TextAsset inkJsonAsset; // Drag your compiled Ink story here in the Inspector
    private Story inkStory;

    void Start()
    {
        inkStory = new Story(inkJsonAsset.text);
        ContinueStory();
    }

    void ContinueStory()
    {
        if (inkStory.canContinue)
        {
            string line = inkStory.Continue(); // Get the next line of dialogue
            Debug.Log(line); // Display the line (e.g., to a UI Text element)

            // Handle choices if available
            if (inkStory.currentChoices.Count > 0)
            {
                foreach (Choice choice in inkStory.currentChoices)
                {
                    Debug.Log("Choice: " + choice.text); // Display choice options
                }
            }
        }
        else
        {
            Debug.Log("End of story.");
        }
    }

    // Call this method when a player makes a choice
    public void MakeChoice(int choiceIndex)
    {
        inkStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    // Example of setting/getting variables
    public void SetInkVariable(string varName, object value)
    {
        inkStory.variablesState[varName] = value;
    }

    public object GetInkVariable(string varName)
    {
        return inkStory.variablesState[varName];
    }
}