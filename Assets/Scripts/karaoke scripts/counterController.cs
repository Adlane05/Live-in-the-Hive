using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class counterController : MonoBehaviour
{
    public static counterController Instance;
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

    public int Score = 0;
    public Text scoreText;
    void Update()
    {
        scoreText.text = 
        " Score : " +  Score + "";
    }
}
