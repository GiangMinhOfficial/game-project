using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float spped;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;

        position.x += spped * horizontal * Time.deltaTime;
        position.y += spped * vertical * Time.deltaTime;

        transform.position = position;
    }
}
