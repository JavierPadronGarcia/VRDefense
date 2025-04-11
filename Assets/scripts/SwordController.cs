using Oculus.Interaction;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
