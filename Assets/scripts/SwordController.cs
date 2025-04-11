using Oculus.Interaction;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            AudioManager.instance.PlaySFX("sword");
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.CompareTag("heart"))
        {
            Destroy(collision.gameObject);
            AudioManager.instance.PlaySFX("coin_heart");
        }
    }
}
