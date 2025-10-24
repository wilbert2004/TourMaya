using UnityEngine;
using UnityEditor;

/// <summary>
/// Editor personalizado para facilitar la configuración de TourMaya
/// Custom editor to facilitate TourMaya setup
/// </summary>
public class TourMayaEditorTools : EditorWindow
{
    [MenuItem("TourMaya/Setup Wizard")]
    public static void ShowWindow()
    {
        GetWindow<TourMayaEditorTools>("TourMaya Setup");
    }

    private void OnGUI()
    {
        GUILayout.Label("TourMaya Setup Wizard", EditorStyles.boldLabel);
        GUILayout.Space(10);

        EditorGUILayout.HelpBox(
            "Esta herramienta te ayudará a configurar los componentes básicos de TourMaya.",
            MessageType.Info
        );

        GUILayout.Space(10);

        if (GUILayout.Button("Crear GameManager", GUILayout.Height(30)))
        {
            CreateGameManager();
        }

        if (GUILayout.Button("Crear Player", GUILayout.Height(30)))
        {
            CreatePlayer();
        }

        if (GUILayout.Button("Crear UI Canvas", GUILayout.Height(30)))
        {
            CreateUICanvas();
        }

        if (GUILayout.Button("Crear Sistema de Audio", GUILayout.Height(30)))
        {
            CreateAudioSystem();
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Configuración Completa (Todo)", GUILayout.Height(40)))
        {
            CreateCompleteSetup();
        }

        GUILayout.Space(20);
        EditorGUILayout.HelpBox(
            "Después de crear los objetos, configura las referencias en el Inspector.",
            MessageType.Warning
        );
    }

    private void CreateGameManager()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager == null)
        {
            gameManager = new GameObject("GameManager");
            gameManager.AddComponent<GameManager>();
            Debug.Log("✓ GameManager creado");
        }
        else
        {
            Debug.LogWarning("GameManager ya existe en la escena");
        }
    }

    private void CreatePlayer()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "Player";
            player.transform.position = new Vector3(0, 1, 0);
            
            // Eliminar el collider default y agregar CharacterController
            DestroyImmediate(player.GetComponent<Collider>());
            player.AddComponent<CharacterController>();
            player.AddComponent<PlayerController>();

            // Crear cámara
            GameObject camera = new GameObject("PlayerCamera");
            camera.transform.SetParent(player.transform);
            camera.transform.localPosition = new Vector3(0, 0.5f, 0);
            Camera cam = camera.AddComponent<Camera>();
            cam.tag = "MainCamera";

            Debug.Log("✓ Player creado con cámara");
        }
        else
        {
            Debug.LogWarning("Player ya existe en la escena");
        }
    }

    private void CreateUICanvas()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            // Crear Canvas
            canvas = new GameObject("Canvas");
            Canvas canvasComponent = canvas.AddComponent<Canvas>();
            canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.AddComponent<UnityEngine.UI.CanvasScaler>();
            canvas.AddComponent<UnityEngine.UI.GraphicRaycaster>();

            // Crear EventSystem si no existe
            if (GameObject.Find("EventSystem") == null)
            {
                GameObject eventSystem = new GameObject("EventSystem");
                eventSystem.AddComponent<UnityEngine.EventSystems.EventSystem>();
                eventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
            }

            // Crear UIManager
            GameObject uiManager = new GameObject("UIManager");
            uiManager.AddComponent<UIManager>();

            Debug.Log("✓ Canvas y UIManager creados");
        }
        else
        {
            Debug.LogWarning("Canvas ya existe en la escena");
        }
    }

    private void CreateAudioSystem()
    {
        GameObject audioManager = GameObject.Find("AudioManager");
        if (audioManager == null)
        {
            audioManager = new GameObject("AudioManager");
            audioManager.AddComponent<AudioManager>();
            Debug.Log("✓ AudioManager creado");
        }
        else
        {
            Debug.LogWarning("AudioManager ya existe en la escena");
        }
    }

    private void CreateCompleteSetup()
    {
        Debug.Log("=== Iniciando configuración completa de TourMaya ===");
        
        CreateGameManager();
        CreatePlayer();
        CreateUICanvas();
        CreateAudioSystem();

        // Crear TutorialManager
        GameObject tutorialManager = GameObject.Find("TutorialManager");
        if (tutorialManager == null)
        {
            tutorialManager = new GameObject("TutorialManager");
            tutorialManager.AddComponent<TutorialManager>();
            Debug.Log("✓ TutorialManager creado");
        }

        // Crear MapSystem
        GameObject mapSystem = GameObject.Find("MapSystem");
        if (mapSystem == null)
        {
            mapSystem = new GameObject("MapSystem");
            mapSystem.AddComponent<MapSystem>();
            Debug.Log("✓ MapSystem creado");
        }

        // Crear luz direccional si no existe
        if (GameObject.Find("Directional Light") == null)
        {
            GameObject light = new GameObject("Directional Light");
            Light lightComponent = light.AddComponent<Light>();
            lightComponent.type = LightType.Directional;
            light.transform.rotation = Quaternion.Euler(50, -30, 0);
            Debug.Log("✓ Luz direccional creada");
        }

        Debug.Log("=== Configuración completa terminada ===");
        EditorUtility.DisplayDialog(
            "Configuración Completa",
            "Todos los componentes básicos han sido creados.\n\n" +
            "Por favor, configura las referencias en el Inspector de cada componente.",
            "OK"
        );
    }
}

#if UNITY_EDITOR
/// <summary>
/// Editor personalizado para GameManager
/// </summary>
[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameManager gameManager = (GameManager)target;

        EditorGUILayout.Space();
        EditorGUILayout.HelpBox(
            "Configura las locaciones turísticas usando los datos de YucatanLocationsData.",
            MessageType.Info
        );

        if (GUILayout.Button("Cargar Locaciones de Yucatán"))
        {
            // Aquí se podría implementar la carga automática de locaciones
            Debug.Log("Esta función cargará automáticamente las locaciones de Yucatán");
            EditorUtility.DisplayDialog(
                "Información",
                "Las locaciones de Yucatán están definidas en YucatanLocationsData.cs\n\n" +
                "Puedes crearlas manualmente o implementar un sistema de carga automática.",
                "OK"
            );
        }
    }
}
#endif
