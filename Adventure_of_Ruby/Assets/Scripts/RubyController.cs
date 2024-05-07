using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3f;
    public float timeInvincible = 2f;

    public int maxHealth = 5;
    int currentHealth;
    public int Health { get { return currentHealth; } }

    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"change health method: {currentHealth}/{maxHealth}");
    }
}
