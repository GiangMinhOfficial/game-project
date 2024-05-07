using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();

        if (controller != null)
        {
            Debug.Log("damage zone minus health by 1");
            controller.ChangeHealth(-1);
        }
    }
}
