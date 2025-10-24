using UnityEngine;
//usamos las librerias de ui
using UnityEngine.UI;

//usamos la librerias de sounds 
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainPanel : MonoBehaviour
{
    [Header("Options")]

    public Slider volumeFX;
    public Slider volumeMaster;

    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsource;
    public AudioClip clicksound;
    private float lastvolumen;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    //agregamos un pane de credits 
    public GameObject creditsPanel;
    public GameObject levelsPanel;

    // Método que se ejecuta al inicio del juego
    void Start()
    {
        // Al iniciar, solo mostramos el panel principal
        OpenPanel(mainPanel);

        // Conectamos la función de mute al toggle
        mute.onValueChanged.AddListener(SetMute);
    }

    //agregaremos una funcion para intercambiar los paneles 
    public void OpenPanel(GameObject panel)
    {
        //desactivamos todos los paneles
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        levelsPanel.SetActive(false);

        //activamos el panel que se ha pasado como parametro
        panel.SetActive(true);
        //llamamos la funcion de sonido 
        PlaySoundButton();

    }


    //crearemos una funcion awake 
    public void Awake()
    {
        //cuando cambies el valor del slaider  llame a esa funcion y dentro de esa funcion vamos a cambiar el volumen 
        volumeFX.onValueChanged.AddListener(ChangeVolumenFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumenMaster);
    }

    //agregamos la funcione nivel 
    public void PlayLevel(string levelName)
    {
        //cargamos la escena
        SceneManager.LoadScene(levelName);
    }

    //la funcion para salir del juego
    public void ExitGame()
    {
        //si estamos en el editor de unity
        Application.Quit();
    }
    //creamos la funcion para mutear el sonido
    public void SetMute(bool isMuted)
    {
        if (isMuted)
        {
            //guardamos el ultimo volumen 
            mixer.GetFloat("VolMaster", out lastvolumen);
            //si esta muteado ponemos el volumen a -80
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            //si no esta muteado volvemos al ultimo volumen 
            mixer.SetFloat("VolMaster", lastvolumen);
        }
    }
    ///creamos una funcion para controlar el volumen del master 
    public void ChangeVolumenMaster(float volumen)
    {
        mixer.SetFloat("VolMaster", volumen);

    }
    //creamos una funcion para controlar el volumen del fx
    public void ChangeVolumenFX(float volumen)
    {
        mixer.SetFloat("VolFx", volumen);
    }

    public void PlaySoundButton()
    {
        fxsource.PlayOneShot(clicksound);
    }

}
