using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class counterController : MonoBehaviour
{
    public static counterController Instance;
    float timer = 0.0f;
        [SerializeField]
    private TextAsset inkJSONAsset = null;
    public float ScorePercent = 0.0f;
    public float Score = 0;
    public Text scoreText;
    public bool SKIP;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void Start(){
        GameObject.Find("Inventory").SetActive(false);

    }
    
    void Update()
    {   
        if(SKIP == true){
        SceneManager.LoadScene("End");}
        ScorePercent = (Score / 250) * 100;
                timer+= Time.deltaTime;
                scoreText.text = " Score : " +  Score + "";
        if(timer >92){
            Debug.Log("timer ended");
            if(ScorePercent < 50){
                DialogueManager.Instance.StartStory(inkJSONAsset, "youSuck");}
                else if((ScorePercent > 50.0f  && ScorePercent < 75.0f)){
                DialogueManager.Instance.StartStory(inkJSONAsset, "notBad");}
                 else if((ScorePercent > 75.0f && ScorePercent < 100.0f)){
                DialogueManager.Instance.StartStory(inkJSONAsset, "prettyGood");}
                 else if((ScorePercent >99.0f)){
                DialogueManager.Instance.StartStory(inkJSONAsset, "perfect");}
            }
        
        
        }
    }

