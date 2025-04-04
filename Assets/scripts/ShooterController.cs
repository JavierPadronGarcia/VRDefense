using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShooterController : MonoBehaviour, IMixedRealityPointerHandler
{
    public GameObject bulletPrefab;
    private Transform shootPoint;
    public float bulletSpeed = 10f;
    [SerializeField] private Handedness shootingHand = Handedness.Right;

    void Update()
    {
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, shootingHand, out MixedRealityPose pose))
        {
            shootPoint.SetPositionAndRotation(pose.Position, pose.Rotation);
        }
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = shootPoint.forward * bulletSpeed;
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData) { }
    public void OnPointerClicked(MixedRealityPointerEventData eventData) { }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
}