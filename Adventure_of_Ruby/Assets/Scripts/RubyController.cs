using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3f;
    public float timeInvincible = 2f;
    public GameObject projectilePrefab;

    public int maxHealth = 5;
    int currentHealth;
    public int Health { get { return currentHealth; } }

    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2D;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    private AudioSource audioSource;
    public AudioClip throwAudioClip;
    public AudioClip enemyHitAudioClip;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<NonPlayerCharacter>(out var character))
                {
                    character.DisplayDialog();
                }
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
            animator.SetTrigger("Hit");

            PlaySound(enemyHitAudioClip);

            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        Debug.Log($"change health method: {currentHealth}/{maxHealth}");
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
        PlaySound(throwAudioClip);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
