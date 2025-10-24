using UnityEngine;

/// <summary>
/// Sistema de audio para ambientación de Yucatán
/// Audio system for Yucatan ambience
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Clips")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip archaeologicalSiteAmbience;
    [SerializeField] private AudioClip cenoteAmbience;
    [SerializeField] private AudioClip cityAmbience;
    [SerializeField] private AudioClip beachAmbience;
    [SerializeField] private AudioClip interactionSound;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource ambienceSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Configuración")]
    [SerializeField] private float musicVolume = 0.6f;
    [SerializeField] private float ambienceVolume = 0.4f;
    [SerializeField] private float sfxVolume = 0.8f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudioSources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioSources()
    {
        // Crear AudioSources si no existen
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true;
            musicSource.volume = musicVolume;
        }

        if (ambienceSource == null)
        {
            ambienceSource = gameObject.AddComponent<AudioSource>();
            ambienceSource.loop = true;
            ambienceSource.volume = ambienceVolume;
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.volume = sfxVolume;
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    /// <summary>
    /// Reproduce la música de fondo
    /// </summary>
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    /// <summary>
    /// Cambia la ambientación según el tipo de locación
    /// </summary>
    public void PlayAmbienceForLocation(LocationType locationType)
    {
        AudioClip ambienceClip = null;

        switch (locationType)
        {
            case LocationType.ZonaArqueologica:
                ambienceClip = archaeologicalSiteAmbience;
                break;
            case LocationType.Cenote:
                ambienceClip = cenoteAmbience;
                break;
            case LocationType.Ciudad:
                ambienceClip = cityAmbience;
                break;
            case LocationType.Playa:
                ambienceClip = beachAmbience;
                break;
            default:
                ambienceClip = archaeologicalSiteAmbience;
                break;
        }

        if (ambienceClip != null && ambienceSource != null)
        {
            if (ambienceSource.clip != ambienceClip)
            {
                ambienceSource.clip = ambienceClip;
                ambienceSource.Play();
            }
        }
    }

    /// <summary>
    /// Reproduce sonido de interacción
    /// </summary>
    public void PlayInteractionSound()
    {
        if (interactionSound != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(interactionSound);
        }
    }

    /// <summary>
    /// Detiene toda la música
    /// </summary>
    public void StopAllMusic()
    {
        if (musicSource != null) musicSource.Stop();
        if (ambienceSource != null) ambienceSource.Stop();
    }

    /// <summary>
    /// Ajusta el volumen de la música
    /// </summary>
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
            musicSource.volume = musicVolume;
    }

    /// <summary>
    /// Ajusta el volumen de efectos
    /// </summary>
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        if (sfxSource != null)
            sfxSource.volume = sfxVolume;
    }
}
