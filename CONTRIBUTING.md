# Guía de Contribución - TourMaya

¡Gracias por tu interés en contribuir a TourMaya! Este documento proporciona pautas para contribuir al proyecto.

## Código de Conducta

### Nuestro Compromiso

Nos comprometemos a hacer de la participación en este proyecto una experiencia libre de acoso para todos, independientemente de la edad, tamaño corporal, discapacidad, etnia, identidad de género, nivel de experiencia, nacionalidad, apariencia personal, raza, religión o identidad y orientación sexual.

### Nuestros Estándares

**Comportamiento que contribuye a crear un ambiente positivo:**
- Usar lenguaje acogedor e inclusivo
- Ser respetuoso con diferentes puntos de vista
- Aceptar críticas constructivas
- Enfocarse en lo mejor para la comunidad
- Mostrar empatía hacia otros miembros

**Comportamiento inaceptable:**
- Uso de lenguaje o imágenes sexualizadas
- Comentarios insultantes o despectivos (trolling)
- Acoso público o privado
- Publicar información privada de otros
- Cualquier conducta inapropiada en un entorno profesional

## Cómo Contribuir

### Reportar Bugs

Si encuentras un bug, por favor:

1. **Verifica** que no haya sido reportado antes en [Issues](https://github.com/wilbert2004/TourMaya/issues)
2. **Abre un nuevo issue** con:
   - Título descriptivo
   - Pasos para reproducir el bug
   - Comportamiento esperado vs actual
   - Screenshots (si aplica)
   - Versión de Unity
   - Sistema operativo

**Template de Bug Report:**
```markdown
## Descripción del Bug
[Descripción clara del problema]

## Pasos para Reproducir
1. Paso 1
2. Paso 2
3. ...

## Comportamiento Esperado
[Qué debería pasar]

## Comportamiento Actual
[Qué está pasando]

## Screenshots
[Si aplica]

## Entorno
- Unity Version: [ej. 2022.3.10f1]
- OS: [ej. Windows 11, macOS 13]
- Hardware: [si es relevante]
```

### Sugerir Mejoras

Para sugerir nuevas características:

1. **Verifica** que no exista una sugerencia similar
2. **Abre un issue** con tag `enhancement`
3. **Describe** la característica en detalle
4. **Explica** por qué sería útil

**Template de Feature Request:**
```markdown
## Descripción de la Característica
[Descripción clara de la característica propuesta]

## Problema que Resuelve
[Qué problema o necesidad aborda]

## Solución Propuesta
[Cómo funcionaría la característica]

## Alternativas Consideradas
[Otras formas de resolver el problema]

## Contexto Adicional
[Screenshots, mockups, referencias]
```

### Proceso de Pull Request

1. **Fork** el repositorio
2. **Crea** una rama desde `main` o `develop`:
   ```bash
   git checkout -b feature/mi-nueva-caracteristica
   # o
   git checkout -b fix/correccion-bug
   ```

3. **Realiza** tus cambios siguiendo las guías de estilo

4. **Commit** con mensajes descriptivos:
   ```bash
   git commit -m "Add: Sistema de logros para locaciones visitadas"
   ```

5. **Push** a tu fork:
   ```bash
   git push origin feature/mi-nueva-caracteristica
   ```

6. **Abre** un Pull Request con:
   - Título descriptivo
   - Descripción detallada de cambios
   - Referencias a issues relacionados
   - Screenshots/videos (si hay cambios visuales)

### Convenciones de Código

#### Nomenclatura

**Clases y Structs:**
```csharp
public class GameManager { }
public struct LocationData { }
```

**Métodos:**
```csharp
public void VisitLocation() { }
private void UpdateScore() { }
```

**Variables:**
```csharp
// Privadas con prefijo
private float moveSpeed;
private int currentIndex;

// Públicas sin prefijo
public string locationName;
public Vector3 position;

// Constantes en MAYÚSCULAS
private const float MAX_SPEED = 10f;
```

**Propiedades:**
```csharp
public int Score { get; private set; }
public bool IsActive { get; set; }
```

#### Formato de Código

**Indentación:**
- Usar 4 espacios (no tabs)
- Llaves en nueva línea (estilo Allman)

```csharp
public class Example
{
    public void Method()
    {
        if (condition)
        {
            // código
        }
    }
}
```

**Comentarios:**
```csharp
/// <summary>
/// Descripción detallada del método en español
/// Detailed method description in English
/// </summary>
/// <param name="parameter">Descripción del parámetro</param>
/// <returns>Descripción del valor de retorno</returns>
public int MethodName(string parameter)
{
    // Comentario inline cuando sea necesario
    return 0;
}
```

**Organización de Clase:**
```csharp
public class MyClass : MonoBehaviour
{
    // 1. Variables serializadas
    [Header("Configuración")]
    [SerializeField] private float speed;
    
    // 2. Variables públicas
    public static MyClass Instance;
    
    // 3. Variables privadas
    private int currentValue;
    
    // 4. Propiedades
    public int Value { get; set; }
    
    // 5. Unity callbacks
    private void Awake() { }
    private void Start() { }
    private void Update() { }
    
    // 6. Métodos públicos
    public void PublicMethod() { }
    
    // 7. Métodos privados
    private void PrivateMethod() { }
}
```

#### Buenas Prácticas

**Usar SerializeField en lugar de public:**
```csharp
// Preferido
[SerializeField] private float speed;

// Evitar
public float speed;
```

**Usar Headers para organizar en Inspector:**
```csharp
[Header("Movimiento")]
[SerializeField] private float moveSpeed;
[SerializeField] private float jumpForce;

[Header("Cámara")]
[SerializeField] private float mouseSensitivity;
```

**Null checks:**
```csharp
if (gameObject != null)
{
    // código
}
```

**Singleton pattern:**
```csharp
public static MyClass Instance { get; private set; }

private void Awake()
{
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
```

### Contribuciones de Contenido

#### Información Cultural

Si contribuyes con información sobre Yucatán o cultura maya:

1. **Verifica** la exactitud con fuentes confiables:
   - INAH (Instituto Nacional de Antropología e Historia)
   - UNESCO
   - Investigaciones académicas
   
2. **Cita** las fuentes cuando sea posible

3. **Respeta** la cultura y patrimonio maya

4. **Escribe** en español e inglés cuando sea posible

#### Assets (Modelos, Texturas, Audio)

1. **Asegúrate** de tener derechos para compartir el asset
2. **Usa** formatos compatibles con Unity:
   - Modelos: .fbx, .obj
   - Texturas: .png, .jpg
   - Audio: .wav, .mp3, .ogg
   
3. **Optimiza** los assets:
   - Texturas: tamaño apropiado (potencias de 2)
   - Modelos: poly count razonable
   - Audio: bitrate apropiado

4. **Documenta** el uso y atribución

### Testing

Antes de enviar un PR:

1. **Prueba** tu código en Unity Editor
2. **Verifica** que no hay errores en Console
3. **Asegúrate** que no rompe funcionalidad existente
4. **Documenta** cómo probar tus cambios

### Documentación

Si actualizas funcionalidad:

1. **Actualiza** README.md si es necesario
2. **Actualiza** GAME_GUIDE.md para cambios significativos
3. **Agrega** comentarios XML a métodos públicos
4. **Documenta** nuevas características

## Estructura de Ramas

- `main` - Rama principal estable
- `develop` - Rama de desarrollo activo
- `feature/*` - Ramas para nuevas características
- `fix/*` - Ramas para corrección de bugs
- `docs/*` - Ramas para documentación

## Proceso de Revisión

1. Al menos un mantenedor debe revisar el PR
2. Se pueden solicitar cambios
3. CI/CD debe pasar (cuando esté configurado)
4. Una vez aprobado, se hará merge

## Reconocimientos

Los contribuyentes serán reconocidos en:
- README.md (sección de contribuyentes)
- Créditos del juego (para contribuciones significativas)

## Preguntas

Si tienes preguntas sobre cómo contribuir:
- Abre un issue con tag `question`
- Consulta la documentación existente

## Licencia

Al contribuir, aceptas que tus contribuciones se licenciarán bajo la misma licencia del proyecto.

---

**¡Gracias por contribuir a preservar y promover la cultura maya de Yucatán!** 🏛️💚
