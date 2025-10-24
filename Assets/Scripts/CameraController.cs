using UnityEngine;

/// <summary>
/// Sistema de cámara para TourMaya con modos de vista
/// Camera system for TourMaya with view modes
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Configuración de Cámara")]
    [SerializeField] private Transform player;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -5);
    
    [Header("Modos de Cámara")]
    [SerializeField] private CameraMode currentMode = CameraMode.FirstPerson;
    
    private Vector3 currentVelocity;

    public enum CameraMode
    {
        FirstPerson,
        ThirdPerson,
        Panoramic
    }

    private void LateUpdate()
    {
        if (player == null) return;

        switch (currentMode)
        {
            case CameraMode.FirstPerson:
                UpdateFirstPerson();
                break;
            case CameraMode.ThirdPerson:
                UpdateThirdPerson();
                break;
            case CameraMode.Panoramic:
                UpdatePanoramic();
                break;
        }

        // Cambiar modo de cámara con tecla C
        if (Input.GetKeyDown(KeyCode.C))
        {
            CycleCamera();
        }
    }

    private void UpdateFirstPerson()
    {
        // La cámara está fija como hijo del jugador
        // No se necesita actualización adicional
    }

    private void UpdateThirdPerson()
    {
        Vector3 targetPosition = player.position + player.TransformDirection(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 1f / followSpeed);
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }

    private void UpdatePanoramic()
    {
        // Rotar alrededor del jugador
        transform.RotateAround(player.position, Vector3.up, 10f * Time.deltaTime);
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }

    private void CycleCamera()
    {
        currentMode = (CameraMode)(((int)currentMode + 1) % System.Enum.GetValues(typeof(CameraMode)).Length);
        Debug.Log($"Modo de cámara: {currentMode}");
    }

    public void SetCameraMode(CameraMode mode)
    {
        currentMode = mode;
    }
}
