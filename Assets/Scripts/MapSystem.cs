using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Sistema de mapa interactivo para navegar entre locaciones
/// Interactive map system for navigating between locations
/// </summary>
public class MapSystem : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private Transform mapMarkersContainer;
    [SerializeField] private GameObject mapMarkerPrefab;

    [Header("Configuración")]
    [SerializeField] private float mapScale = 100f;
    [SerializeField] private Vector2 mapCenter = new Vector2(400, 300);

    private List<GameObject> mapMarkers = new List<GameObject>();
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        GenerateMapMarkers();
    }

    /// <summary>
    /// Genera marcadores en el mapa para todas las locaciones
    /// </summary>
    private void GenerateMapMarkers()
    {
        if (GameManager.Instance == null) return;

        // Limpiar marcadores existentes
        foreach (GameObject marker in mapMarkers)
        {
            if (marker != null)
                Destroy(marker);
        }
        mapMarkers.Clear();

        // Aquí se crearían los marcadores basados en las locaciones del GameManager
        // Por ahora, es una estructura base
        Debug.Log("Mapa generado - Marcadores listos para configuración");
    }

    /// <summary>
    /// Convierte coordenadas del mundo 3D a coordenadas del mapa 2D
    /// </summary>
    private Vector2 WorldToMapPosition(Vector3 worldPosition)
    {
        float mapX = mapCenter.x + (worldPosition.x / mapScale);
        float mapY = mapCenter.y + (worldPosition.z / mapScale);
        return new Vector2(mapX, mapY);
    }

    /// <summary>
    /// Teletransporta al jugador a una locación
    /// </summary>
    public void TeleportToLocation(TouristLocation location)
    {
        if (location == null || player == null) return;

        player.TeleportTo(location.position);
        
        // Cambiar ambientación de audio
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayAmbienceForLocation(location.locationType);
        }

        Debug.Log($"Teletransportado a: {location.locationName}");
        
        // Cerrar mapa
        if (mapPanel != null)
            mapPanel.SetActive(false);
    }

    /// <summary>
    /// Muestra/oculta el mapa
    /// </summary>
    public void ToggleMap()
    {
        if (mapPanel != null)
        {
            bool isActive = !mapPanel.activeSelf;
            mapPanel.SetActive(isActive);
            
            // Pausar/reanudar el juego
            Time.timeScale = isActive ? 0f : 1f;
            
            // Mostrar cursor cuando el mapa está activo
            Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isActive;
        }
    }

    /// <summary>
    /// Actualiza el estado de los marcadores según el progreso
    /// </summary>
    public void UpdateMarkers()
    {
        // Actualizar visualización de locaciones visitadas/no visitadas
        // Implementación base para expansión futura
    }
}
