# TourMaya - Guía de Desarrollo

## Descripción del Proyecto
TourMaya es un videojuego educativo desarrollado en Unity que permite a los jugadores explorar virtualmente los principales destinos turísticos y arqueológicos de Yucatán, México. El juego combina entretenimiento con aprendizaje cultural sobre la civilización maya y el patrimonio de la región.

## Características Principales

### 1. Sistema de Recorrido Turístico
- **GameManager**: Gestiona el flujo del juego y el progreso del jugador
- **Sistema de Puntuación**: Los jugadores ganan puntos al visitar locaciones
- **Progreso de Tour**: Seguimiento de locaciones visitadas

### 2. Locaciones Turísticas de Yucatán
El juego incluye las siguientes locaciones auténticas:

#### Zonas Arqueológicas
- **Chichén Itzá**: Una de las Siete Maravillas del Mundo Moderno
- **Uxmal**: Ciudad maya con arquitectura Puuc
- **Ek Balam**: Conocida por sus esculturas de estuco

#### Cenotes
- **Cenote Ik Kil**: Cenote sagrado cerca de Chichén Itzá
- **Cenote X'keken (Dzitnup)**: Cenote subterráneo con formaciones rocosas

#### Ciudades Coloniales
- **Mérida**: La Ciudad Blanca, capital de Yucatán
- **Izamal**: La Ciudad Amarilla, Pueblo Mágico

#### Reservas Naturales
- **Celestún**: Reserva de la Biósfera con flamencos rosados

### 3. Sistema de Jugador
- **Movimiento First-Person**: Control WASD para movimiento
- **Cámara FPS**: Control con mouse
- **Sistema de Interacción**: Tecla E para interactuar con objetos
- **Teletransportación**: Entre diferentes locaciones

### 4. Interfaz de Usuario
- **Panel de Información**: Muestra detalles culturales e históricos
- **Sistema de Puntuación**: Visualización de puntos y progreso
- **Mapa Interactivo**: Navegación entre locaciones (Tecla M)

## Estructura del Proyecto

```
Assets/
├── Scenes/
│   └── MainScene.unity          # Escena principal del juego
├── Scripts/
│   ├── GameManager.cs           # Gestor principal del juego
│   ├── TouristLocation.cs       # Clase de datos de locaciones
│   ├── PlayerController.cs      # Controlador del jugador
│   ├── LocationInteractable.cs  # Sistema de interacción
│   ├── UIManager.cs             # Gestor de interfaz
│   └── YucatanLocationsData.cs  # Datos de locaciones de Yucatán
├── Prefabs/                     # Prefabs reutilizables
├── Materials/                   # Materiales para objetos 3D
└── Resources/                   # Recursos del juego

ProjectSettings/
├── ProjectSettings.asset        # Configuración del proyecto
└── ProjectVersion.txt           # Versión de Unity

Packages/
└── manifest.json                # Dependencias del proyecto
```

## Controles del Juego

### Movimiento
- **W/A/S/D**: Movimiento del personaje
- **Mouse**: Rotación de cámara
- **Espacio**: Saltar
- **Shift**: Correr (si está implementado)

### Interacción
- **E**: Interactuar con objetos turísticos
- **M**: Abrir/Cerrar mapa
- **ESC**: Mostrar/Ocultar cursor

### UI
- **Información automática**: Al interactuar con locaciones
- **Puntuación**: Se actualiza en tiempo real

## Requisitos Técnicos

### Software
- Unity 2022.3.10f1 o superior
- Visual Studio 2022 o VS Code con extensión de C#
- Git para control de versiones

### Hardware Recomendado
- Procesador: Intel Core i5 o equivalente
- RAM: 8 GB mínimo
- Gráficos: Compatible con DirectX 11
- Espacio en disco: 2 GB

## Configuración del Proyecto

### 1. Abrir el Proyecto
1. Abrir Unity Hub
2. Hacer clic en "Add" y seleccionar la carpeta del proyecto
3. Abrir con Unity 2022.3.10f1

### 2. Configurar Escena Principal
1. Abrir `Assets/Scenes/MainScene.unity`
2. Crear un GameObject vacío llamado "GameManager"
3. Agregar el componente `GameManager.cs`
4. Configurar las locaciones turísticas en el Inspector

### 3. Configurar Jugador
1. Crear un GameObject Capsule para el jugador
2. Agregar el componente `PlayerController.cs`
3. Crear una cámara como hijo del jugador
4. Asignar la cámara al campo `cameraTransform`

### 4. Crear Objetos Interactuables
1. Crear GameObjects para representar locaciones
2. Agregar el componente `LocationInteractable.cs`
3. Configurar los datos de locación usando `YucatanLocationsData`

## Sistema de Tipos de Locaciones

```csharp
public enum LocationType
{
    ZonaArqueologica,  // Sitios arqueológicos mayas
    Cenote,            // Cenotes naturales
    Ciudad,            // Ciudades coloniales
    Playa,             // Playas y costas
    Reserva,           // Reservas naturales
    Museo,             // Museos
    Hacienda           // Haciendas históricas
}
```

## Información Cultural

Cada locación incluye:
- **Nombre**: Nombre oficial del lugar
- **Descripción**: Descripción general del sitio
- **Información Histórica**: Contexto histórico
- **Información Maya**: Relevancia cultural maya
- **Tipo**: Categoría de la locación
- **Puntos**: Valor en puntos del juego

## Desarrollo Futuro

### Características Planeadas
- [ ] Modelos 3D de monumentos y edificios
- [ ] Sonido ambiental y música regional
- [ ] Narración en español y maya
- [ ] Sistema de misiones y desafíos
- [ ] Modo multijugador
- [ ] Realidad Virtual (VR) support
- [ ] Quiz cultural sobre Yucatán
- [ ] Galería fotográfica virtual
- [ ] Sistema de clima dinámico
- [ ] Ciclo día/noche

### Mejoras Técnicas
- [ ] Optimización de rendimiento
- [ ] Sistema de guardado de progreso
- [ ] Integración con base de datos
- [ ] Analytics de jugadores
- [ ] Localización multiidioma

## Aspectos Educativos

El juego está diseñado para:
- Promover el turismo cultural de Yucatán
- Educar sobre la civilización maya
- Preservar el patrimonio cultural
- Fomentar el aprendizaje interactivo
- Conectar a estudiantes con su herencia cultural

## Contribución

### Cómo Contribuir
1. Fork el repositorio
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

### Estándares de Código
- Usar comentarios en español e inglés
- Seguir las convenciones de C# y Unity
- Documentar funciones públicas
- Incluir información cultural auténtica

## Licencia y Créditos

### Información Cultural
Los datos históricos y culturales son basados en:
- INAH (Instituto Nacional de Antropología e Historia)
- UNESCO World Heritage Sites
- Gobierno del Estado de Yucatán
- Investigación académica sobre cultura maya

### Desarrollo
- Proyecto universitario de desarrollo de videojuegos
- Especialidad: Motor de Unity
- Enfoque regional: Yucatán, México

## Contacto y Soporte

Para preguntas sobre el proyecto:
- Repository: [GitHub - TourMaya](https://github.com/wilbert2004/TourMaya)
- Issues: Use el sistema de issues de GitHub

---

**Nota**: Este es un proyecto educativo desarrollado con fines académicos para promover el conocimiento de la cultura maya y el patrimonio de Yucatán.
