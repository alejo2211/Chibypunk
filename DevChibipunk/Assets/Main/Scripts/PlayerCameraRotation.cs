using UnityEngine;
using Unity.Cinemachine; // Cinemachine 3.x usa este namespace nuevo

public class PlayerCameraRotation : MonoBehaviour
{
    [Header("Referencias")]
    public Transform cameraFollowTarget; // El objeto que la cámara sigue (Follow en Cinemachine)
    public float rotationSpeed = 10f;

    void LateUpdate()
    {
        if (cameraFollowTarget == null) return;

        // Dirección plana (solo en eje Y)
        Vector3 forward = cameraFollowTarget.forward;
        forward.y = 0f;

        if (forward.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

