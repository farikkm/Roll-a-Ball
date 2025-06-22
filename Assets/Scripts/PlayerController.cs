using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    private float axesX;
    private float axesY;
    private int score;

    readonly string pickUpGameObjectTag = "PickUp";
    readonly string enemyGameObjectTag = "Enemy";

    [SerializeField] private int speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText(score);
        winText.gameObject.SetActive(false);
    }

    void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12)
        {
            winText.gameObject.SetActive(true);
        }
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
        if (other.gameObject.CompareTag(pickUpGameObjectTag))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText(score);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyGameObjectTag))
        {
            Debug.Log(gameObject);
            Destroy(gameObject);
            winText.text = "You lose!";
            winText.gameObject.SetActive(true);
        }
    }
}
