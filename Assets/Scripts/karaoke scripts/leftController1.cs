using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftController : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isInTrigger = false;
    bool isNoteHit = false;
    float timer = 0.0f;
    Renderer renderer;
    Color ogColor;
    GameObject current;
      public AudioSource negative;
    public AudioSource positive;

     void Awake()
        {
            negative = negative.gameObject.GetComponent<AudioSource>();
            positive = positive.gameObject.GetComponent<AudioSource>();

        }
    void Start()
    {   
        renderer = GetComponent<Renderer>(); 
        ogColor = renderer.material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left"))
        {
            current = other.gameObject;
            isInTrigger = true;
        }
        isNoteHit = false;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Left"))
        {
            current = null;
            isInTrigger = false;
            if (!isNoteHit)
            {
                isNoteHit = false;
            }
            
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if ( !isNoteHit && isInTrigger == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (current != null)
                Destroy(current); 
            counterController.Instance.Score++;
            isNoteHit = true;
            positive.Play();
            Invoke("ResetColor",0.5f);
            renderer.material.SetColor("_Color", Color.green);

        }

        if (isInTrigger == false && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            negative.Play();

            renderer.material.SetColor("_Color", Color.red);
            Invoke("ResetColor",0.5f);

        }
    }
    void ResetColor()
    {
        renderer.material.SetColor("_Color",ogColor);
    }

}

