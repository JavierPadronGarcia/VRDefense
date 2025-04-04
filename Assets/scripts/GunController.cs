using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class GunController : MonoBehaviour
{
    private bool wasTriggerPressed = false;

    public float fireRate = 0.3f;
    private float nextFireTime = 0f;

    void Update()
    {
        var rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
        {
            if (isPressed && Time.time >= nextFireTime)
            {
                Debug.Log("Disparo!");
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
