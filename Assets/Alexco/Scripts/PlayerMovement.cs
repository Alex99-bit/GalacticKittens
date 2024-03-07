using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    public GameObject bulletPrefab; // Prefab de la bala

    private Rigidbody2D rb; // Referencia al componente Rigidbody2D

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D del jugador
    }

    private void Update()
    {
        if (!IsLocalPlayer || !IsOwner)
            return;

        // Obtener la entrada del eje horizontal (izquierda/derecha)
        float moveInputX = Input.GetAxisRaw("Horizontal");

        // Obtener la entrada del eje vertical (arriba/abajo)
        float moveInputY = Input.GetAxisRaw("Vertical");

        // Calcular la velocidad del movimiento
        float moveVelocityX = moveInputX * moveSpeed;
        float moveVelocityY = moveInputY * moveSpeed;

        // Asignar la velocidad al Rigidbody para mover al jugador
        rb.velocity = new Vector2(moveVelocityX, moveVelocityY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instanciar una nueva bala en la posición del jugador
            SpawnBulletServerRpc();
        }
    }

    [ServerRpc]
    private void SpawnBulletServerRpc()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        NetworkObject bulletNetworkObject = bullet.GetComponent<NetworkObject>();
        if (bulletNetworkObject != null)
        {
            bulletNetworkObject.Spawn();
        }
    }
}
