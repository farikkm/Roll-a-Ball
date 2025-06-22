using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float axesX;
    private float axesY;

    [SerializeField] private int speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementDirection = movementValue.Get<Vector2>();

        axesX = movementDirection.x;
        axesY = movementDirection.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(axesX, 0.0f, axesY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
