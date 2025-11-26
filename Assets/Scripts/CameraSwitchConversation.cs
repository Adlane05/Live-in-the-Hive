using UnityEngine;

public class CameraSwitchConversation : MonoBehaviour
{
    [Header("Transforms")]
    public Transform target;

    [Header("Timing")]
    public float moveDuration = 15f;

    private float timer = 0f;
    private bool isMoving = false;
    private Transform origin;
    void Start()
    {
        StartMove();
    }

    public void StartMove()
    {
        origin = transform;
        timer = 0f;
        isMoving = true;
    }

    void Update()
    {
        if (!isMoving) return;

        timer += Time.deltaTime;
        float t = Mathf.SmoothStep(0f, 1f, timer / moveDuration);

        // Position Lerp
        transform.position = Vector3.Lerp(origin.position, target.position, t);

        // Rotation Slerp
        transform.rotation = Quaternion.Slerp(origin.rotation, target.rotation, t);

        if (t >= 1f)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
            isMoving = false;
        }
    }
}
