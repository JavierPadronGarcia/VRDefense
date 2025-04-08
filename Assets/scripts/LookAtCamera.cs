using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    [Tooltip("¿Debe rotar verticalmente también?")]
    public bool allowVerticalPan = false;
    public bool fixInvertedRotation = true;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // Hace que mire hacia la cámara
            transform.LookAt(mainCamera.transform);

            // Corrige la inversión (gira 180 en Y)
            if (fixInvertedRotation) transform.Rotate(0, 180f, 0);

            // Si no se permite paneo vertical, se bloquea la rotación X y Z
            if (!allowVerticalPan)
            {
                Vector3 angles = transform.eulerAngles;
                transform.rotation = Quaternion.Euler(0, angles.y, 0);
            }
        }
    }
}
