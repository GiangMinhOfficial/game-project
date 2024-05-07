using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3f;

    float timer;
    int direction = 1;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y += Time.deltaTime * speed * direction;
        }
        else
        {
            position.x += Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController player = collision.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
