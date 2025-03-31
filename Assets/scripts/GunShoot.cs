using UnityEngine;
using UnityEngine.XR;
using Microsoft.MixedReality.Toolkit.Input;

public class GunShoot : MonoBehaviour
{
    public XRNode controllerNode = XRNode.RightHand; // O LeftHand
    private InputDevice device;
    public float raycastDistance = 100f; // Distancia del raycast
    public LayerMask hitLayer; // Capa de lo que puede impactar el disparo
    public GameObject impactEffect; // Efecto que se genera al impactar

    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    void Update()
    {
        // Detectar si el gatillo del controlador está presionado
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed) && isPressed)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Realizar un Raycast desde la posición y la dirección del controlador
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, hitLayer))
        {
            Debug.Log("Impacto detectado: " + hit.collider.name);

            // Si hay un impacto, generar un efecto en la posición del impacto
            if (impactEffect != null)
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        else
        {
            Debug.Log("No hay impacto");
        }
    }
}