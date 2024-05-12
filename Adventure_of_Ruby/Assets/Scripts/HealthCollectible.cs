using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        RubyController controller = collision.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.Health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);

                controller.PlaySound(collectedClip);
            }
        }
    }
}
