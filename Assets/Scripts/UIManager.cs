using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestor de interfaz de usuario para TourMaya
/// UI Manager for TourMaya
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Paneles UI")]
    [SerializeField] private GameObject locationInfoPanel;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject mapPanel;
    
    [Header("Textos de Información")]
    [SerializeField] private Text locationNameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text historicalInfoText;
    [SerializeField] private Text mayaInfoText;
    
    [Header("Textos de Puntuación")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text progressText;
    [SerializeField] private Text locationsVisitedText;
    
    [Header("Imagen de Locación")]
    [SerializeField] private Image locationImage;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        HideAllPanels();
        UpdateScore();
    }

    private void Update()
    {
        // Actualizar puntuación cada frame
        UpdateScore();
        
        // Toggle mapa con M
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }
    }

    /// <summary>
    /// Muestra información de una locación turística
    /// </summary>
    public void ShowLocationInfo(TouristLocation location)
    {
        if (location == null || locationInfoPanel == null) return;

        locationInfoPanel.SetActive(true);

        // Actualizar textos
        if (locationNameText != null)
            locationNameText.text = location.locationName;
        
        if (descriptionText != null)
            descriptionText.text = location.description;
        
        if (historicalInfoText != null)
            historicalInfoText.text = $"Historia: {location.historicalInfo}";
        
        if (mayaInfoText != null)
            mayaInfoText.text = $"Cultura Maya: {location.mayaInfo}";
        
        if (locationImage != null && location.locationImage != null)
        {
            locationImage.sprite = location.locationImage;
            locationImage.color = location.themeColor;
        }

        Debug.Log($"Mostrando información de: {location.locationName}");
    }

    /// <summary>
    /// Oculta el panel de información de locación
    /// </summary>
    public void HideLocationInfo()
    {
        if (locationInfoPanel != null)
            locationInfoPanel.SetActive(false);
    }

    /// <summary>
    /// Actualiza la visualización de puntuación
    /// </summary>
    private void UpdateScore()
    {
        if (GameManager.Instance == null) return;

        if (scoreText != null)
            scoreText.text = $"Puntos: {GameManager.Instance.GetPlayerScore():F0}";
        
        if (progressText != null)
            progressText.text = $"Progreso: {GameManager.Instance.GetProgress():F1}%";
        
        if (locationsVisitedText != null)
            locationsVisitedText.text = $"Visitadas: {GameManager.Instance.GetLocationsVisited()}";
    }

    /// <summary>
    /// Muestra/oculta el mapa
    /// </summary>
    public void ToggleMap()
    {
        if (mapPanel != null)
        {
            mapPanel.SetActive(!mapPanel.activeSelf);
        }
    }

    /// <summary>
    /// Oculta todos los paneles
    /// </summary>
    private void HideAllPanels()
    {
        if (locationInfoPanel != null)
            locationInfoPanel.SetActive(false);
        
        if (mapPanel != null)
            mapPanel.SetActive(false);
    }
}
