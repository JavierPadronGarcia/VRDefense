using UnityEngine;
using UnityEngine.XR;

public class AttachGunToHand : MonoBehaviour
{
    public GameObject gunPrefab;
    private GameObject gunInstance;

    void Start()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightHand.isValid)
        {
            Transform rightHandTransform = Camera.main.transform.parent.Find("RightHand Controller");
            if (rightHandTransform)
            {
                gunInstance = Instantiate(gunPrefab, rightHandTransform);
                gunInstance.transform.localPosition = Vector3.zero;
                gunInstance.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
