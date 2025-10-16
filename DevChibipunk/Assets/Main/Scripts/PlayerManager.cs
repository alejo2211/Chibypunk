using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de movimiento")]
    public float speed = 5f;             // Velocidad de movimiento
    public float jumpForce = 5f;         // Fuerza del salto
    public float groundCheckDistance = 0.2f; // Distancia para detectar el suelo
    public LayerMask groundMask;         // Capa del suelo

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoverJugador();
        Saltar();
    }

    void MoverJugador()
    {
        float moveX = Input.GetAxis("Horizontal"); // A y D
        float moveZ = Input.GetAxis("Vertical");   // W y S

        Vector3 movimiento = new Vector3(moveX, 0, moveZ) * speed;
        Vector3 nuevaVelocidad = new Vector3(movimiento.x, rb.velocity.y, movimiento.z);

        rb.velocity = transform.TransformDirection(nuevaVelocidad);
    }

    void Saltar()
    {
        // Detecta si está en el suelo
        isGrounded = Physics.CheckSphere(transform.position + Vector3.down * 0.5f, groundCheckDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja la esfera de detección de suelo (visible solo en modo editor)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.5f, groundCheckDistance);
    }
}

