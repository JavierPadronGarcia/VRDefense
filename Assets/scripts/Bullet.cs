using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.name.Equals("naveEspacial"))
            {
                Destroy(collision.transform.parent.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
