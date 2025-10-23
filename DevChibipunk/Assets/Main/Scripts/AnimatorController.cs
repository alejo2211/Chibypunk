using UnityEngine;
using UnityEngine.InputSystem;
public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;

    [Header("Movimiento")]
    public float velocidad = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Obtener movimiento del jugador (WASD o joystick)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular dirección y velocidad
        Vector3 direccion = new Vector3(horizontal, 0, vertical);
        float velocidadActual = direccion.magnitude;

        // Actualizar parámetro "Speed" del Animator
        animator.SetFloat("Speed", velocidadActual);

        // Mover al jugador (opcional)
        if (velocidadActual > 0.1f)
        {
            // Hacer que el jugador mire hacia donde se mueve
            transform.forward = direccion.normalized;

            // Moverse
            controller.SimpleMove(direccion.normalized * velocidad);
        }
    }
}
