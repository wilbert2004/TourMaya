# Configuración e Instalación de TourMaya

## Requisitos Previos

### Software Necesario
1. **Unity Hub** (Última versión)
   - Descargar de: https://unity.com/download

2. **Unity Editor 2022.3.10f1** (LTS)
   - Instalar a través de Unity Hub
   - Módulos necesarios:
     - Windows Build Support
     - WebGL Build Support (opcional)
     - Android Build Support (opcional)

3. **IDE (Uno de los siguientes)**
   - Visual Studio 2022 Community (Recomendado para Windows)
   - Visual Studio Code con extensión C#
   - JetBrains Rider

4. **Git**
   - Para clonar el repositorio
   - Descargar de: https://git-scm.com/

### Hardware Mínimo
- **CPU**: Intel Core i5 o AMD equivalente
- **RAM**: 8 GB (16 GB recomendado)
- **GPU**: Compatible con DirectX 11
- **Almacenamiento**: 5 GB libres

## Instalación Paso a Paso

### 1. Clonar el Repositorio

```bash
# Mediante HTTPS
git clone https://github.com/wilbert2004/TourMaya.git

# O mediante SSH (si tienes configuradas llaves SSH)
git clone git@github.com:wilbert2004/TourMaya.git
```

### 2. Abrir el Proyecto en Unity

1. Abrir **Unity Hub**
2. Hacer clic en **"Add"** (Agregar proyecto)
3. Navegar a la carpeta clonada `TourMaya`
4. Seleccionar la carpeta raíz del proyecto
5. El proyecto aparecerá en la lista de Unity Hub
6. Hacer clic en el proyecto para abrirlo

**Nota**: La primera vez que abras el proyecto, Unity generará archivos `.meta` y compilará los scripts. Este proceso puede tomar varios minutos.

### 3. Verificar la Configuración

Una vez abierto el proyecto:

1. **Verificar la Escena Principal**
   - En la ventana Project, navega a `Assets/Scenes/`
   - Doble clic en `MainScene.unity`

2. **Verificar los Scripts**
   - Navega a `Assets/Scripts/`
   - Verifica que no haya errores de compilación en la consola

3. **Configurar GameManager**
   - En la Hierarchy, crear un GameObject vacío llamado "GameManager"
   - Agregar el componente `GameManager.cs`
   - Configurar las locaciones turísticas en el Inspector

## Configuración de Componentes

### GameManager

El GameManager es el controlador principal del juego.

**Configuración:**
1. Crear GameObject vacío: `GameObject > Create Empty`
2. Renombrar a "GameManager"
3. Agregar componente: `Add Component > GameManager`
4. En el Inspector, configurar:
   - **Tourist Locations**: Lista de locaciones (usar datos de `YucatanLocationsData`)

### Player (Jugador)

**Configuración:**
1. Crear objeto del jugador:
   - `GameObject > 3D Object > Capsule`
   - Renombrar a "Player"
   - Posición: (0, 1, 0)
   
2. Agregar componente CharacterController:
   - `Add Component > Character Controller`
   - Height: 2
   - Radius: 0.5
   
3. Agregar PlayerController:
   - `Add Component > Player Controller`
   
4. Crear cámara:
   - Hacer clic derecho en Player > `3D Object > Camera`
   - Renombrar a "PlayerCamera"
   - Posición local: (0, 0.5, 0)
   - Arrastrar la cámara al campo `Camera Transform` del PlayerController

### UI Manager

**Configuración:**
1. Crear GameObject vacío: "UIManager"
2. Agregar componente: `Add Component > UI Manager`
3. Crear Canvas:
   - `GameObject > UI > Canvas`
   - Render Mode: Screen Space - Overlay
   
4. Crear paneles de UI (como hijos del Canvas):
   - Panel de Información de Locación
   - Panel de Puntuación
   - Panel de Mapa

### Audio Manager

**Configuración:**
1. Crear GameObject vacío: "AudioManager"
2. Agregar componente: `Add Component > Audio Manager`
3. Asignar clips de audio en el Inspector (cuando estén disponibles)

### Tutorial Manager

**Configuración:**
1. Crear GameObject vacío: "TutorialManager"
2. Agregar componente: `Add Component > Tutorial Manager`
3. Configurar paneles de UI para el tutorial

## Estructura de Carpetas Recomendada

```
Assets/
├── Scenes/
│   ├── MainScene.unity
│   └── MenuScene.unity (futuro)
│
├── Scripts/
│   ├── Managers/
│   │   ├── GameManager.cs
│   │   ├── UIManager.cs
│   │   ├── AudioManager.cs
│   │   └── TutorialManager.cs
│   ├── Player/
│   │   └── PlayerController.cs
│   ├── Locations/
│   │   ├── TouristLocation.cs
│   │   ├── LocationInteractable.cs
│   │   └── YucatanLocationsData.cs
│   └── Systems/
│       ├── MapSystem.cs
│       └── CameraController.cs
│
├── Prefabs/
│   ├── UI/
│   ├── Locations/
│   └── Player/
│
├── Materials/
│   ├── Terrain/
│   └── Buildings/
│
├── Textures/
│   ├── UI/
│   └── Environment/
│
├── Models/
│   ├── Monuments/
│   └── Environment/
│
├── Audio/
│   ├── Music/
│   ├── Ambience/
│   └── SFX/
│
└── Resources/
    └── Data/
```

## Crear Locaciones Interactuables

### Paso 1: Crear el Objeto

1. Crear un cubo o modelo 3D: `GameObject > 3D Object > Cube`
2. Renombrar según la locación (ej: "ChichenItza_Marker")
3. Posicionar en el mundo

### Paso 2: Configurar Componentes

1. Agregar Collider si no lo tiene
2. Agregar componente: `Add Component > Location Interactable`
3. En el Inspector, configurar:
   - Location Name: "Chichén Itzá"
   - Description: "Una de las Siete Maravillas..."
   - Location Type: ZonaArqueologica
   - Points Value: 200

### Paso 3: Registrar en GameManager

1. Seleccionar el GameManager
2. En Tourist Locations, agregar nueva entrada
3. Asignar el objeto LocationInteractable

## Controles de Testing

Durante el desarrollo en el Editor:

- **Play/Pause**: Barra espaciadora (con el cursor sobre Game view)
- **Game View**: Maximizar con Shift+Space
- **Console**: Ctrl+Shift+C (para ver logs)

## Solución de Problemas Comunes

### Error: "Scripts have compiler errors"

**Solución:**
1. Abrir la ventana Console (Window > General > Console)
2. Revisar los errores específicos
3. Asegurarse que todos los scripts están en `Assets/Scripts/`
4. Verificar que no falten referencias

### Error: "Missing references"

**Solución:**
1. Verificar que todos los GameObjects necesarios existen
2. Asignar referencias en el Inspector manualmente
3. Verificar nombres de componentes

### El jugador no se mueve

**Solución:**
1. Verificar que CharacterController está agregado
2. Verificar configuración de Input en ProjectSettings
3. Revisar la consola para errores

### UI no se muestra

**Solución:**
1. Verificar que Canvas existe
2. Verificar Event System (se crea automáticamente con Canvas)
3. Verificar que los paneles UI están asignados en UIManager

## Próximos Pasos

Después de la configuración inicial:

1. **Agregar Modelos 3D**
   - Importar modelos de edificios mayas
   - Configurar materiales y texturas

2. **Implementar Audio**
   - Agregar música de fondo
   - Agregar efectos de sonido
   - Configurar AudioManager

3. **Crear UI Completa**
   - Diseñar paneles informativos
   - Agregar imágenes de locaciones
   - Implementar sistema de navegación

4. **Testing y Optimización**
   - Probar todas las funcionalidades
   - Optimizar rendimiento
   - Corregir bugs

## Recursos Adicionales

- [Unity Learn](https://learn.unity.com/) - Tutoriales oficiales
- [Unity Documentation](https://docs.unity3d.com/) - Documentación
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/) - Guía de C#

## Soporte

Si encuentras problemas:
1. Revisar GAME_GUIDE.md para documentación detallada
2. Abrir un Issue en GitHub
3. Consultar la documentación de Unity

---

**¡Listo para comenzar el desarrollo!** 🎮🏛️
