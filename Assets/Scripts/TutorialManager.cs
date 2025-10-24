using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sistema de tutorial y ayuda para TourMaya
/// Tutorial and help system for TourMaya
/// </summary>
public class TutorialManager : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private Text tutorialText;
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private Text helpText;

    [Header("Configuración")]
    [SerializeField] private bool showTutorialOnStart = true;
    [SerializeField] private float tutorialDisplayTime = 5f;

    private bool tutorialCompleted = false;
    private float tutorialTimer = 0f;

    private readonly string[] tutorialMessages = new string[]
    {
        "¡Bienvenido a TourMaya! Explora las maravillas de Yucatán.",
        "Usa W, A, S, D para moverte por el mundo.",
        "Mueve el mouse para mirar alrededor.",
        "Presiona E para interactuar con objetos turísticos.",
        "Presiona M para abrir el mapa de locaciones.",
        "¡Disfruta tu recorrido por Yucatán!"
    };

    private int currentMessageIndex = 0;

    private void Start()
    {
        if (showTutorialOnStart)
        {
            StartTutorial();
        }

        // Configurar texto de ayuda
        SetupHelpText();
        
        if (helpPanel != null)
            helpPanel.SetActive(false);
    }

    private void Update()
    {
        // Toggle ayuda con F1
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleHelp();
        }

        // Avanzar tutorial con espacio
        if (tutorialPanel != null && tutorialPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                NextTutorialMessage();
            }

            // Auto-avanzar después de tiempo
            tutorialTimer += Time.deltaTime;
            if (tutorialTimer >= tutorialDisplayTime)
            {
                NextTutorialMessage();
            }
        }
    }

    /// <summary>
    /// Inicia el tutorial
    /// </summary>
    public void StartTutorial()
    {
        if (tutorialPanel == null) return;

        currentMessageIndex = 0;
        tutorialPanel.SetActive(true);
        ShowCurrentTutorialMessage();
    }

    /// <summary>
    /// Muestra el mensaje actual del tutorial
    /// </summary>
    private void ShowCurrentTutorialMessage()
    {
        if (tutorialText != null && currentMessageIndex < tutorialMessages.Length)
        {
            tutorialText.text = tutorialMessages[currentMessageIndex];
            tutorialTimer = 0f;
        }
    }

    /// <summary>
    /// Avanza al siguiente mensaje del tutorial
    /// </summary>
    private void NextTutorialMessage()
    {
        currentMessageIndex++;
        
        if (currentMessageIndex >= tutorialMessages.Length)
        {
            CompleteTutorial();
        }
        else
        {
            ShowCurrentTutorialMessage();
        }
    }

    /// <summary>
    /// Completa el tutorial
    /// </summary>
    private void CompleteTutorial()
    {
        tutorialCompleted = true;
        if (tutorialPanel != null)
            tutorialPanel.SetActive(false);
        
        Debug.Log("Tutorial completado");
    }

    /// <summary>
    /// Muestra/oculta el panel de ayuda
    /// </summary>
    public void ToggleHelp()
    {
        if (helpPanel != null)
        {
            bool isActive = !helpPanel.activeSelf;
            helpPanel.SetActive(isActive);
            
            // Pausar juego cuando la ayuda está activa
            Time.timeScale = isActive ? 0f : 1f;
        }
    }

    /// <summary>
    /// Configura el texto de ayuda
    /// </summary>
    private void SetupHelpText()
    {
        if (helpText == null) return;

        string help = @"<b>CONTROLES DE TOURMAYA</b>

<b>Movimiento:</b>
W, A, S, D - Mover personaje
Mouse - Rotar cámara
Espacio - Saltar
C - Cambiar modo de cámara

<b>Interacción:</b>
E - Interactuar con objetos
M - Abrir/Cerrar mapa
ESC - Mostrar/Ocultar cursor

<b>Interfaz:</b>
F1 - Mostrar/Ocultar ayuda

<b>Objetivo:</b>
Explora las locaciones turísticas de Yucatán, aprende sobre la cultura maya
y acumula puntos visitando diferentes lugares.

<b>Locaciones disponibles:</b>
• Chichén Itzá (Zona Arqueológica)
• Uxmal (Zona Arqueológica)
• Ek Balam (Zona Arqueológica)
• Cenote Ik Kil
• Cenote X'keken
• Mérida (Ciudad Colonial)
• Izamal (Pueblo Mágico)
• Reserva de Celestún

¡Disfruta tu recorrido virtual por Yucatán!";

        helpText.text = help;
    }

    public bool IsTutorialCompleted()
    {
        return tutorialCompleted;
    }
}
