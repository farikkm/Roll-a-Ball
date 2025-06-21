using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        transform.position = SetCameraInitialPosition();
        offset = transform.position;
        SetNewCameraOffset();
    }

    Vector3 SetCameraInitialPosition()
    {
        Vector3 newVector = new Vector3(0f, 10f, -10f);
        return newVector;
    }

    void SetNewCameraOffset()
    {
        transform.position = player.transform.position + offset;
    }

    private void LateUpdate()
    {
        SetNewCameraOffset();
    }
}
