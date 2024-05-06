using UnityEngine;

public class RubyController : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x += 3f * horizontal * Time.deltaTime;
        position.y += 3f * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }
}
