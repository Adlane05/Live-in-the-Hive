using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upController : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isInTrigger = false;
    bool isNoteHit = false;
    public counterController counterController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Up"))
        {
            isInTrigger = true;
        }
        isNoteHit = false;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Up"))
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
        if ( !isNoteHit && isInTrigger == true && Input.GetKeyDown(KeyCode.UpArrow))
        {

            Debug.Log("hit up");
             counterController.Instance.Score++;
            isNoteHit = true;

        }

        if (isInTrigger == false && Input.GetKeyDown(KeyCode.UpArrow))
        {

            Debug.Log("up failed");
             counterController.Instance.Score--;

        }
    }

}

