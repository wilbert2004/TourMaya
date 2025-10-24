using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// GameManager principal para TourMaya - Gestiona el sistema de recorrido turístico
/// Main GameManager for TourMaya - Manages the tourist tour system
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Configuración del Tour")]
    [SerializeField] private List<TouristLocation> touristLocations = new List<TouristLocation>();
    [SerializeField] private int currentLocationIndex = 0;
    
    [Header("Estado del Jugador")]
    [SerializeField] private float playerScore = 0f;
    [SerializeField] private int locationsVisited = 0;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeGame();
    }

    /// <summary>
    /// Inicializa el juego con las locaciones de Yucatán
    /// </summary>
    private void InitializeGame()
    {
        Debug.Log("Iniciando TourMaya - Recorrido por Yucatán");
        LoadTouristLocations();
    }

    /// <summary>
    /// Carga las locaciones turísticas de Yucatán
    /// </summary>
    private void LoadTouristLocations()
    {
        // Las locaciones se configurarán en el Inspector de Unity
        if (touristLocations.Count == 0)
        {
            Debug.LogWarning("No hay locaciones turísticas configuradas");
        }
        else
        {
            Debug.Log($"Cargadas {touristLocations.Count} locaciones turísticas");
        }
    }

    /// <summary>
    /// Marca una locación como visitada
    /// </summary>
    public void VisitLocation(TouristLocation location)
    {
        if (location != null)
        {
            location.isVisited = true;
            locationsVisited++;
            playerScore += location.pointsValue;
            Debug.Log($"Visitada: {location.locationName} - Puntos: {location.pointsValue}");
        }
    }

    /// <summary>
    /// Navega a la siguiente locación
    /// </summary>
    public TouristLocation GetNextLocation()
    {
        if (touristLocations.Count == 0) return null;
        
        currentLocationIndex = (currentLocationIndex + 1) % touristLocations.Count;
        return touristLocations[currentLocationIndex];
    }

    /// <summary>
    /// Obtiene la locación actual
    /// </summary>
    public TouristLocation GetCurrentLocation()
    {
        if (touristLocations.Count == 0) return null;
        return touristLocations[currentLocationIndex];
    }

    /// <summary>
    /// Obtiene el progreso del jugador
    /// </summary>
    public float GetProgress()
    {
        if (touristLocations.Count == 0) return 0f;
        return (float)locationsVisited / touristLocations.Count * 100f;
    }

    public float GetPlayerScore() => playerScore;
    public int GetLocationsVisited() => locationsVisited;
}
