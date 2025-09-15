using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightController : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isInTrigger = false;
    bool isNoteHit = false;
    public counterController counterController;

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
        Vector3 movement = new Vector3(0, speed, 0);
        transform.position += Time.deltaTime * movement;
        if ( !isNoteHit && isInTrigger == true && Input.GetKeyDown(KeyCode.RightArrow))
        {

            Debug.Log("hit right");
             counterController.Instance.Score++;
            isNoteHit = true;

        }

        if (isInTrigger == false && Input.GetKeyDown(KeyCode.RightArrow))
        {

            Debug.Log("right failed");
             counterController.Instance.Score--;

        }
    }

}

