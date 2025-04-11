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

        if (collision.gameObject.CompareTag("heart"))
        {
            Destroy(collision.gameObject);
            AudioManager.instance.PlaySFX("coin_heart");
        }

        Destroy(gameObject);
    }
}
