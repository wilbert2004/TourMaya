using UnityEngine;

/// <summary>
/// Componente para objetos interactuables en locaciones turísticas
/// Component for interactable objects at tourist locations
/// </summary>
public class LocationInteractable : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private TouristLocation locationData;
    [SerializeField] private bool showInfoOnInteract = true;
    
    private bool hasInteracted = false;

    /// <summary>
    /// Interactúa con el objeto turístico
    /// </summary>
    public void Interact()
    {
        if (locationData == null)
        {
            Debug.LogWarning("No hay datos de locación asignados");
            return;
        }

        if (!hasInteracted)
        {
            // Marcar como visitado en el GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.VisitLocation(locationData);
            }
            
            hasInteracted = true;
        }

        // Mostrar información
        if (showInfoOnInteract && UIManager.Instance != null)
        {
            UIManager.Instance.ShowLocationInfo(locationData);
        }
        
        Debug.Log($"Interactuando con: {locationData.locationName}");
    }

    private void OnDrawGizmos()
    {
        // Dibujar esfera en el editor para visualizar el punto de interacción
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
