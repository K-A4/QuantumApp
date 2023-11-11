using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    private float distance;
    private float xAngle = 60;
    private float yAngle;

    public void SetTarget(Transform transform)
    {
        target = transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!target)
        {
            return;
        }
        //var xinput = Input.GetAxis("Mouse X");
        var yinput = Input.GetAxis("Mouse Y");
        distance -= Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance, 9, 12);
        xAngle = Mathf.Clamp(xAngle, -80, 80);
        var rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 60.0f * Time.deltaTime);

        transform.position = Vector3.Slerp(transform.position, target.position - transform.forward * distance, 60.0f * Time.deltaTime);
    }
}
