
using System.Numerics;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;
    public Transform orientation;
    float rotationX = 0.0f;
    float rotationY = 0.0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        orientation.rotation = UnityEngine.Quaternion.Euler(0, 90, 0);

    }
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = UnityEngine.Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = UnityEngine.Quaternion.Euler(0, rotationY, 0);


    }
}
