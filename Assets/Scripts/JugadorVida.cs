using UnityEngine;
using UnityEngine.UI;

public class JugadorVida : MonoBehaviour
{
    public float vidaMax = 100f;
    public float vidaActual;

    public Slider barraVida;

    public Transform villano;
    public float distanciaParaRegenerar = 10f;

    public float velocidadRegeneracion = 5f;

    void Start()
    {
        vidaActual = vidaMax;

        if (barraVida != null)
        {
            barraVida.maxValue = vidaMax;
            barraVida.value = vidaActual;
        }
    }

    void Update()
    {
        // Calcula distancia al villano
        if (villano != null)
        {
            float dist = Vector3.Distance(transform.position, villano.position);

            // Si el villano está lejos → regenerar vida
            if (dist > distanciaParaRegenerar)
            {
                vidaActual += velocidadRegeneracion * Time.deltaTime;
                vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);

                if (barraVida != null)
                    barraVida.value = vidaActual;
            }
        }
    }

    public void TomarDaño(float daño)
    {
        vidaActual -= daño;

        if (barraVida != null)
            barraVida.value = vidaActual;

        EfectoGolpe();  // <-- efectos visuales

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("El jugador murió");
    }

    // Aquí irá el efecto o animación
    void EfectoGolpe()
    {
        Debug.Log("Jugador recibió daño");
    }


    public Image damageImage;
    public float tiempoDesvanecer = 0.4f;

    void EfectoGolpe()
    {
        StopAllCoroutines();
        StartCoroutine(EfectoSangre());
    }

    System.Collections.IEnumerator EfectoSangre()
    {
        damageImage.color = new Color(1, 0, 0, 0.6f); // rojo fuerte

        yield return new WaitForSeconds(tiempoDesvanecer);

        damageImage.color = new Color(1, 0, 0, 0f); // desaparece
    }

}
