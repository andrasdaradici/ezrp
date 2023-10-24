using UnityEngine;

public class EnemyPaddle : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform ballTransform;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (ballTransform == null)
        {
            Debug.LogError("Ball Transform not set. Please assign the ball's transform in the Inspector.");
        }
    }

    private void Update()
    {
        if (ballTransform.position.x <= 0)
        {
            return;
        }

        float predictedY = PredictBallPosition().y;
        float deltaY = predictedY - rb.position.y;
        float newY = Mathf.Clamp(rb.position.y + deltaY * speed * Time.deltaTime, -4.001667f, 4.001667f);
        rb.MovePosition(new Vector2(rb.position.x, newY));
    }

    private Vector2 PredictBallPosition()
    {
        float timeToReachX = (transform.position.x - ballTransform.position.x) / ballTransform.GetComponent<Rigidbody2D>().velocity.x;
        float predictedY = ballTransform.position.y + ballTransform.GetComponent<Rigidbody2D>().velocity.y * timeToReachX;
        return new Vector2(transform.position.x, predictedY);
    }
}
