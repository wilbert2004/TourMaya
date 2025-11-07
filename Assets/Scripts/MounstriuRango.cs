using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class MounstriuRango : MonoBehaviour
{
    public NavMeshAgent monstruo;
    public float velocidad;
    public bool persiguiendo;
    public float Rango;
    public float Distancia;

    public Transform objetivo;

    [Header("Animaciones")]
    public Animation Anim;
    public string NombreAnimacionCaminar;
    public string NombreAnimacionQuieto;

    private void Update()
    {
        Distancia = Vector3.Distance(monstruo.transform.position, objetivo.position);

        if (Distancia < Rango)
        {
            persiguiendo = true;
        }
        else if (Distancia > Rango + 3)
        {
            persiguiendo = false;
        }

        if (persiguiendo == false)
        {
            monstruo.speed = 0;
            if (Anim != null && !string.IsNullOrEmpty(NombreAnimacionQuieto))
                Anim.CrossFade(NombreAnimacionQuieto);
        }
        else if (persiguiendo == true)
        {
            monstruo.speed = velocidad;
            if (Anim != null && !string.IsNullOrEmpty(NombreAnimacionCaminar))
                Anim.CrossFade(NombreAnimacionCaminar);

            monstruo.SetDestination(objetivo.position);
        }

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(monstruo.transform.position, Rango);
    }

}
