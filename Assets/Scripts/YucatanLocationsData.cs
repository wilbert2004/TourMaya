using UnityEngine;

/// <summary>
/// Inicializador de locaciones turísticas de Yucatán
/// Yucatan tourist locations initializer
/// </summary>
public class YucatanLocationsData : MonoBehaviour
{
    /// <summary>
    /// Crea las locaciones turísticas predefinidas de Yucatán
    /// </summary>
    public static TouristLocation[] GetYucatanLocations()
    {
        return new TouristLocation[]
        {
            // Chichen Itzá
            new TouristLocation
            {
                locationName = "Chichén Itzá",
                description = "Una de las Siete Maravillas del Mundo Moderno. Ciudad maya icónica con la famosa pirámide de Kukulcán.",
                historicalInfo = "Fundada alrededor del año 525 d.C., fue uno de los centros políticos y económicos más importantes de la civilización maya.",
                mayaInfo = "El nombre significa 'Boca del pozo de los brujos de agua'. Durante los equinoccios, la luz solar crea la ilusión de una serpiente descendiendo por la pirámide.",
                locationType = LocationType.ZonaArqueologica,
                position = new Vector3(0, 0, 0),
                pointsValue = 200f,
                themeColor = new Color(0.8f, 0.6f, 0.2f)
            },

            // Uxmal
            new TouristLocation
            {
                locationName = "Uxmal",
                description = "Antigua ciudad maya conocida por su arquitectura Puuc. Patrimonio de la Humanidad por UNESCO.",
                historicalInfo = "Construida entre los años 700 y 1000 d.C., destaca por la Pirámide del Adivino y el Palacio del Gobernador.",
                mayaInfo = "Su nombre significa 'Construida Tres Veces'. Es un ejemplo excepcional de arquitectura maya del período Clásico Tardío.",
                locationType = LocationType.ZonaArqueologica,
                position = new Vector3(-50, 0, -30),
                pointsValue = 180f,
                themeColor = new Color(0.7f, 0.5f, 0.3f)
            },

            // Cenote Ik Kil
            new TouristLocation
            {
                locationName = "Cenote Ik Kil",
                description = "Impresionante cenote sagrado cerca de Chichén Itzá, con aguas cristalinas y vegetación exuberante.",
                historicalInfo = "Utilizado por los mayas para ceremonias religiosas y como fuente de agua dulce.",
                mayaInfo = "Los cenotes eran considerados puertas al inframundo maya (Xibalbá) y lugares sagrados para rituales.",
                locationType = LocationType.Cenote,
                position = new Vector3(5, 0, -15),
                pointsValue = 150f,
                themeColor = new Color(0.2f, 0.6f, 0.8f)
            },

            // Mérida
            new TouristLocation
            {
                locationName = "Mérida - La Ciudad Blanca",
                description = "Capital de Yucatán, conocida como la Ciudad Blanca por sus construcciones de piedra caliza.",
                historicalInfo = "Fundada en 1542 sobre las ruinas de la antigua ciudad maya T'ho. Centro cultural y económico de la región.",
                mayaInfo = "Construida sobre T'ho, una importante ciudad maya. Muchas construcciones coloniales utilizaron piedras de edificios mayas.",
                locationType = LocationType.Ciudad,
                position = new Vector3(-70, 0, 0),
                pointsValue = 120f,
                themeColor = new Color(0.9f, 0.9f, 0.9f)
            },

            // Cenote X'keken
            new TouristLocation
            {
                locationName = "Cenote X'keken (Dzitnup)",
                description = "Cenote subterráneo con formaciones rocosas espectaculares y un orificio que permite la entrada de luz natural.",
                historicalInfo = "Descubierto accidentalmente por un campesino siguiendo a un cerdo (x'keken en maya).",
                mayaInfo = "Este tipo de cenotes semiabiertos eran lugares de veneración y ofrenda a los dioses mayas del agua.",
                locationType = LocationType.Cenote,
                position = new Vector3(30, 0, -20),
                pointsValue = 140f,
                themeColor = new Color(0.3f, 0.7f, 0.9f)
            },

            // Ek Balam
            new TouristLocation
            {
                locationName = "Ek Balam",
                description = "Zona arqueológica maya con impresionantes esculturas de estuco y una acrópolis bien preservada.",
                historicalInfo = "Ciudad maya que alcanzó su apogeo entre 600-900 d.C. Destaca por sus frisos decorativos únicos.",
                mayaInfo = "El nombre significa 'Jaguar Negro'. La tumba del rey Ukit Kan Lek Tok fue encontrada aquí con impresionantes ofrendas.",
                locationType = LocationType.ZonaArqueologica,
                position = new Vector3(40, 0, 10),
                pointsValue = 170f,
                themeColor = new Color(0.6f, 0.4f, 0.2f)
            },

            // Celestún
            new TouristLocation
            {
                locationName = "Reserva de Celestún",
                description = "Reserva de la biósfera conocida por sus flamencos rosados y manglares.",
                historicalInfo = "Declarada Reserva de la Biósfera en 1979, protege uno de los ecosistemas de manglar más importantes de México.",
                mayaInfo = "Los mayas conocían esta área como lugar de abundante sal y aves sagradas.",
                locationType = LocationType.Reserva,
                position = new Vector3(-100, 0, 30),
                pointsValue = 130f,
                themeColor = new Color(1.0f, 0.6f, 0.7f)
            },

            // Izamal
            new TouristLocation
            {
                locationName = "Izamal - Ciudad Amarilla",
                description = "Pueblo Mágico conocido como la Ciudad de las Tres Culturas, con edificios coloniales pintados de amarillo.",
                historicalInfo = "Importante centro ceremonial maya convertido en ciudad colonial española en el siglo XVI.",
                mayaInfo = "Fue centro de adoración al dios Itzamná y al dios sol Kinich Kakmó. Tiene una de las pirámides mayas más grandes de Yucatán.",
                locationType = LocationType.Ciudad,
                position = new Vector3(-20, 0, 20),
                pointsValue = 140f,
                themeColor = new Color(1.0f, 0.9f, 0.3f)
            }
        };
    }
}
