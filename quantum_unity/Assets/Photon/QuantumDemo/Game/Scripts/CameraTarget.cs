using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    private void Awake()
    {
        var camera = Camera.main;
        var cameraMover = camera.GetComponent<CameraMovement>();
        cameraMover.SetTarget(transform);
    }
}
