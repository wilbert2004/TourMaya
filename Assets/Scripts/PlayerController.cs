using UnityEngine;

/// <summary>
/// Controlador del jugador para el recorrido turístico
/// Player controller for the tourist tour
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    
    [Header("Cámara")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform cameraTransform;
    
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalRotation = 0f;
    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }
        
        // Configurar el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleInteraction();
    }

    /// <summary>
    /// Maneja el movimiento del jugador
    /// </summary>
    private void HandleMovement()
    {
        if (characterController == null) return;

        isGrounded = characterController.isGrounded;

        // Obtener input del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular dirección de movimiento
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        moveDirection = move * moveSpeed;

        // Aplicar gravedad
        if (!isGrounded)
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            moveDirection.y = jumpForce;
        }

        // Mover el personaje
        characterController.Move(moveDirection * Time.deltaTime);
    }

    /// <summary>
    /// Maneja la rotación de la cámara
    /// </summary>
    private void HandleRotation()
    {
        // Rotación horizontal (girar el cuerpo)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        // Rotación vertical (mirar arriba/abajo)
        if (cameraTransform != null)
        {
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
            cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }

    /// <summary>
    /// Maneja la interacción con objetos turísticos
    /// </summary>
    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Raycast para detectar objetos interactuables
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 3f))
            {
                LocationInteractable interactable = hit.collider.GetComponent<LocationInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }

        // Toggle cursor con ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    /// <summary>
    /// Teletransporta al jugador a una posición
    /// </summary>
    public void TeleportTo(Vector3 position)
    {
        if (characterController != null)
        {
            characterController.enabled = false;
            transform.position = position;
            characterController.enabled = true;
        }
        else
        {
            transform.position = position;
        }
    }
}
