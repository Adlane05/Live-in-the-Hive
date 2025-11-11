using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class DialogueMana : MonoBehaviour {

	public static DialogueMana Instance; 
    public event Action<Story> OnCreateStory;
	
    void Awake () {
		Instance = this;
		// Remove the default message
		RemoveChildren();
		textPanel.SetActive(false);
		buttonPanel.SetActive(false);
		// StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory (TextAsset otherinkJSONAsset) {
		inkJSONAsset = otherinkJSONAsset;
		StartStory ();
	}
	
	public void StartStory () {
		story = new Story (inkJSONAsset.text);
        if(OnCreateStory != null) OnCreateStory(story);
		RefreshView();
		Cursor.visible = true;
		textPanel.SetActive(true);
		buttonPanel.SetActive(true);
        Cursor.lockState =  CursorLockMode.None;
	}
	
	bool HandleTags(List<string> tags)
	{
		if (tags == null || tags.Count == 0)
			return false;

		foreach (string tag in tags)
		{
			//if (tag.StartsWith("image:"))
			//{
			//    string imageName = tag.Substring("image:".Length).Trim();
			//    Debug.Log($"Switching image to: {imageName}");
			//    LoadAndDisplayImage(imageName);
			//}
			if (tag.StartsWith("background:"))
			{
			}

			
		}
	}
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView () {
		// Remove all the UI on screen
		RemoveChildren ();
		
		// Read all the content until we can't continue any more
		while (story.canContinue) {
			bool hadTags = story.currentTags != null && story.currentTags.Count > 0;
                if (hadTags)
                    hitWaitTag = HandleTags(story.currentTags);
			// Continue gets the next line of the story
			string text = story.Continue ();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else {
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate{
				StartStory();
			});
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView (string text) {
		Text storyText = Instantiate (textPrefab) as Text;
		storyText.text = text;
		storyText.transform.SetParent (textPanel.transform, false);
	}

	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (buttonPanel.transform, false);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = textPanel.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			Destroy (textPanel.transform.GetChild (i).gameObject);
		}
		
		childCount = buttonPanel.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			Destroy (buttonPanel.transform.GetChild (i).gameObject);
		}
	}


	public Story story;

	[SerializeField]
	private GameObject textPanel = null;
	[SerializeField]
	private GameObject buttonPanel = null;
	// UI Prefabs
	[SerializeField]
	private Text textPrefab = null;
	[SerializeField]
	private Button buttonPrefab = null;

	private TextAsset inkJSONAsset = null; 
}
