using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downController : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isInTrigger = false;
    bool isNoteHit = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Down"))
        {
            isInTrigger = true;
        }
        isNoteHit = false;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Down"))
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
        Vector3 movement = new Vector3(0, speed, 0);
        transform.position += Time.deltaTime * movement;
        if ( !isNoteHit && isInTrigger == true && Input.GetKeyDown(KeyCode.DownArrow))
        {

            Debug.Log("hit down");
            counterController.Instance.Score++;
            isNoteHit = true;

        }

        if (isInTrigger == false && Input.GetKeyDown(KeyCode.DownArrow))
        {

            Debug.Log("Down failed");
            counterController.Instance.Score--;

        }
    }

}

