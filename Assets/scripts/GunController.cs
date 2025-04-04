using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class GunController : MonoBehaviour
{
    private bool wasTriggerPressed = false;

    public float fireRate = 0.8f;
    private float nextFireTime = 0f;

    public float bulletVelocity = 20f;

    public GameObject bullet;
    public Transform shootPoint;

    private void Start()
    {
        if (shootPoint == null)
        {
            GameObject foundShootPoint = GameObject.FindGameObjectWithTag("shootPoint");
            if (foundShootPoint != null)
            {
                shootPoint = foundShootPoint.transform;
            }
            else
            {
                Debug.LogError("No se encontró un objeto con la etiqueta 'shootPoint'");
            }
        }
    }

    void Update()
    {
        var leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (leftHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
        {
            if (isPressed && Time.time >= nextFireTime)
            {
                FireBullet();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private void FireBullet()
    {
        if (bullet == null || shootPoint == null) return;

        // Instancia la bala y la separa del padre
        GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        newBullet.transform.SetParent(null);

        // Asigna velocidad en la dirección hacia adelante del punto de disparo
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = shootPoint.forward * bulletVelocity;
        }
    }

}
