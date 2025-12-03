using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpawner : MonoBehaviour
{
    public float TimeStamp;
    public Transform Origin;
    public Vector3 bottom;
    public float songLength;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        float ratio = TimeStamp/songLength;
        Vector3 originPosition = Origin.position;
        bottom = originPosition + Vector3.down * speed * songLength;
        Vector3 displacement = (bottom-originPosition)* ratio;
        transform.position = originPosition + displacement;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 movement = new Vector3(0, speed, 0);
        transform.position += Time.deltaTime * movement;
    }
}
