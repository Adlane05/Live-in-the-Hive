using UnityEngine;

public class CameraSwitchConversation : MonoBehaviour
{
    [Header("Transforms")]
    public Transform[] target;

    [Header("Timing")]
    public float moveDuration = 15f;

    private float timer = 0f;
    public bool isMoving = false;
    public Transform origin;
    public int index = 0;

    public static CameraSwitchConversation Instance;

    void Awake()
    {
        Instance = this;
    }

    [ContextMenu("StartMove")]
    public void StartMoveInspector()
    {
        StartMove(index);
    }
    public void StartMove(int cameraIndex )
    {

        origin = transform;
        timer = 0f;
        isMoving = true;
        index = cameraIndex;
        
    }

    void Update()
    {   
        if (!isMoving ) return;

        timer += Time.deltaTime;
        float t = Mathf.SmoothStep(0f, 1f, timer / moveDuration);

        // Position Lerp
        transform.position = Vector3.Lerp(origin.position, target[index].position, t);

        // Rotation Slerp
        transform.rotation = Quaternion.Slerp(origin.rotation, target[index].rotation, t);

        if (t >= 1f)
        {
            transform.position = target[index].position;
            transform.rotation = target[index].rotation;
            isMoving = false;
        }
    }
}
