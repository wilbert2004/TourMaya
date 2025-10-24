# TourMaya - Recorrido Virtual por Yucatán

![Unity](https://img.shields.io/badge/Unity-2022.3.10f1-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-9.0-blue?logo=csharp)
![License](https://img.shields.io/badge/License-Educational-green)

## 📖 Descripción

**TourMaya** es un videojuego educativo desarrollado en Unity que permite explorar virtualmente los principales destinos turísticos, arqueológicos y culturales de Yucatán, México. Este proyecto universitario combina tecnología de motores de videojuegos con patrimonio cultural maya.

### 🎯 Objetivos del Proyecto
- Desarrollar un juego educativo usando el motor Unity
- Promover el turismo y cultura de Yucatán
- Preservar digitalmente el patrimonio maya
- Proporcionar una experiencia de aprendizaje interactivo

## ✨ Características

### 🏛️ Locaciones Turísticas
- **Zonas Arqueológicas**: Chichén Itzá, Uxmal, Ek Balam
- **Cenotes**: Ik Kil, X'keken (Dzitnup)
- **Ciudades Coloniales**: Mérida (Ciudad Blanca), Izamal (Ciudad Amarilla)
- **Reservas Naturales**: Celestún

### 🎮 Mecánicas de Juego
- Sistema de exploración en primera persona
- Interacción con objetos turísticos
- Sistema de puntuación y progreso
- Información cultural e histórica detallada
- Mapa interactivo de navegación

### 🛠️ Tecnología
- **Motor**: Unity 2022.3.10f1
- **Lenguaje**: C# 9.0
- **Arquitectura**: Singleton pattern, Component-based
- **Sistemas**: GameManager, UIManager, PlayerController

## 📁 Estructura del Proyecto

```
TourMaya/
├── Assets/
│   ├── Scenes/          # Escenas del juego
│   ├── Scripts/         # Scripts C# del juego
│   ├── Prefabs/         # Prefabs reutilizables
│   ├── Materials/       # Materiales 3D
│   └── Resources/       # Recursos del juego
├── ProjectSettings/     # Configuración de Unity
├── Packages/           # Dependencias
├── GAME_GUIDE.md       # Guía completa de desarrollo
└── README.md           # Este archivo
```

## 🚀 Inicio Rápido

### Requisitos
- Unity Hub
- Unity 2022.3.10f1 o superior
- Visual Studio 2022 o VS Code
- 8 GB RAM mínimo
- 2 GB espacio en disco

### Instalación
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/wilbert2004/TourMaya.git
   ```

2. Abrir Unity Hub y agregar el proyecto

3. Abrir con Unity 2022.3.10f1

4. Abrir la escena `Assets/Scenes/MainScene.unity`

5. Configurar GameManager y Player según la guía

## 🎮 Controles

| Acción | Control |
|--------|---------|
| Movimiento | W/A/S/D |
| Cámara | Mouse |
| Saltar | Espacio |
| Interactuar | E |
| Mapa | M |
| Menú | ESC |

## 📚 Documentación

Para información detallada sobre:
- Configuración del proyecto
- Guías de desarrollo
- Arquitectura del código
- Sistema de locaciones

Consultar: [GAME_GUIDE.md](GAME_GUIDE.md)

## 🏗️ Scripts Principales

### GameManager.cs
Gestor principal del juego. Controla:
- Sistema de locaciones turísticas
- Puntuación del jugador
- Progreso del tour
- Estado del juego

### PlayerController.cs
Controlador del jugador. Implementa:
- Movimiento en primera persona
- Control de cámara
- Sistema de interacción
- Teletransportación

### TouristLocation.cs
Clase de datos para locaciones. Incluye:
- Información básica
- Datos históricos
- Información cultural maya
- Configuración de juego

### UIManager.cs
Gestor de interfaz. Maneja:
- Paneles de información
- Sistema de puntuación
- Mapa interactivo
- HUD del juego

## 🌍 Locaciones Destacadas

### Chichén Itzá 🏛️
Una de las Siete Maravillas del Mundo Moderno. Incluye la icónica pirámide de Kukulcán con el fenómeno de luz del equinoccio.

### Cenote Ik Kil 💧
Cenote sagrado maya con aguas cristalinas, considerado puerta al inframundo maya (Xibalbá).

### Mérida 🏛️
La Ciudad Blanca, capital de Yucatán, fusión de cultura maya y colonial española.

## 🎓 Aspectos Educativos

El juego proporciona:
- ✅ Información histórica verificada
- ✅ Datos culturales de la civilización maya
- ✅ Contexto arqueológico auténtico
- ✅ Patrimonio UNESCO
- ✅ Biodiversidad de Yucatán

## 🔮 Desarrollo Futuro

- [ ] Modelos 3D de monumentos
- [ ] Sonido ambiental y música regional
- [ ] Narración en español y maya
- [ ] Sistema de misiones
- [ ] Soporte VR
- [ ] Modo multijugador
- [ ] Quiz cultural interactivo

## 🤝 Contribución

Las contribuciones son bienvenidas. Por favor:
1. Fork el proyecto
2. Crear una rama feature (`git checkout -b feature/NuevaCaracteristica`)
3. Commit cambios (`git commit -m 'Agregar nueva característica'`)
4. Push a la rama (`git push origin feature/NuevaCaracteristica`)
5. Abrir Pull Request

## 📄 Licencia

Proyecto educativo con fines académicos. Desarrollado para promover la cultura maya y el patrimonio de Yucatán.

## 👥 Créditos

### Información Cultural
- INAH (Instituto Nacional de Antropología e Historia)
- UNESCO World Heritage Sites
- Gobierno del Estado de Yucatán

### Desarrollo
- Proyecto universitario de Unity
- Especialidad: Motor de videojuegos
- Región: Yucatán, México

## 📧 Contacto

- GitHub: [@wilbert2004](https://github.com/wilbert2004)
- Repositorio: [TourMaya](https://github.com/wilbert2004/TourMaya)

---

**Desarrollado con ❤️ para preservar y promover la cultura maya de Yucatán** 
