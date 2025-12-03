using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightController : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isInTrigger = false;
    bool isNoteHit = false;
    float timer = 0.0f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right"))
        {
            isInTrigger = true;
        }
        isNoteHit = false;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Right"))
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
        if ( !isNoteHit && isInTrigger == true && Input.GetKeyDown(KeyCode.RightArrow))
        {

            Debug.Log("hit right " + timer);
             counterController.Instance.Score++;
            isNoteHit = true;

        }

        if (isInTrigger == false && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("hit right " + timer);
             counterController.Instance.Score--;

        }
    }

}

