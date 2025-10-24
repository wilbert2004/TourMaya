using UnityEngine;

/// <summary>
/// Representa una locación turística en Yucatán
/// Represents a tourist location in Yucatan
/// </summary>
[System.Serializable]
public class TouristLocation
{
    [Header("Información Básica")]
    public string locationName;
    [TextArea(3, 5)]
    public string description;
    public LocationType locationType;
    
    [Header("Información Cultural")]
    [TextArea(3, 5)]
    public string historicalInfo;
    [TextArea(2, 4)]
    public string mayaInfo;
    
    [Header("Configuración de Juego")]
    public Vector3 position;
    public float pointsValue = 100f;
    public bool isVisited = false;
    
    [Header("Visual")]
    public Sprite locationImage;
    public Color themeColor = Color.white;
}

/// <summary>
/// Tipos de locaciones turísticas en Yucatán
/// </summary>
public enum LocationType
{
    ZonaArqueologica,  // Archaeological Zone (Chichen Itza, Uxmal, etc.)
    Cenote,            // Cenote (natural sinkhole)
    Ciudad,            // Colonial City (Mérida, Valladolid)
    Playa,             // Beach
    Reserva,           // Nature Reserve
    Museo,             // Museum
    Hacienda           // Hacienda (historic estate)
}
