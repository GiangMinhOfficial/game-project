using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 200;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log($"Vertical: {vertical}");

        Vector2 position = transform.position;
        position.x += 0.009f * horizontal * Time.deltaTime;
        position.y += 0.01f * vertical * Time.deltaTime;
        transform.position = position;
    }
}
