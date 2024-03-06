using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody2D rb; // Referencia al componente Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D del jugador
    }

    void Update()
    {
        // Obtener la entrada del eje horizontal (izquierda/derecha)
        float moveInputX = Input.GetAxisRaw("Horizontal");

        // Obtener la entrada del eje vertical (arriba/abajo)
        float moveInputY = Input.GetAxisRaw("Vertical");

        // Calcular la velocidad del movimiento
        float moveVelocityX = moveInputX * moveSpeed;
        float moveVelocityY = moveInputY * moveSpeed;

        // Asignar la velocidad al Rigidbody para mover al jugador
        rb.velocity = new Vector2(moveVelocityX, moveVelocityY);
    }
}
