using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftController : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isInTrigger = false;
    bool isNoteHit = false;
    float timer = 0.0f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left"))
        {
            isInTrigger = true;
        }
        isNoteHit = false;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Left"))
        {
            isInTrigger = false;
            if (!isNoteHit)
            {
                counterController.Instance.Score--;
                isNoteHit = false;
            }
            
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if ( !isNoteHit && isInTrigger == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Debug.Log("hit left " + timer);
            counterController.Instance.Score++;
            isNoteHit = true;

        }

        if (isInTrigger == false && Input.GetKeyDown(KeyCode.LeftArrow))
        {

             Debug.Log("hit left " + timer);
            counterController.Instance.Score--;

        }
    }

}

