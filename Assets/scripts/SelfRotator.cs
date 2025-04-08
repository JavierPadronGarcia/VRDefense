using UnityEngine;

public class SelfRotator : MonoBehaviour
{
    [Header("Rotaci�n")]
    [Tooltip("Velocidad de rotaci�n en grados por segundo")]
    public float rotationSpeed = 90f;

    [Header("Movimiento Vertical")]
    [Tooltip("�Debe moverse arriba y abajo?")]
    public bool moveUpAndDown = false;

    [Tooltip("Amplitud m�xima del movimiento vertical")]
    public float verticalRange = 0.5f;

    [Tooltip("Velocidad del movimiento vertical")]
    public float verticalSpeed = 2f;

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // Rotaci�n
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Movimiento vertical
        if (moveUpAndDown)
        {
            float newY = startY + Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
