using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchConversation : MonoBehaviour
{
    private Transform startPoint;
    public Transform endPoint;

    public  Vector3 velocity = new Vector3(0,0,0);
    public float movementTime= 15f;
    public float timeCount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        float t = Mathf.Clamp01(timeCount / movementTime);
        transform.position = Vector3.SmoothDamp(startPoint.position, endPoint.position, ref velocity, movementTime);
        transform.rotation = Quaternion.Slerp(startPoint.rotation, endPoint.rotation, t);
    }
}
