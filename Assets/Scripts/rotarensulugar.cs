using UnityEngine;

public class RotarEnSuLugar : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float velocidadRotacion = 45f;

    void Update()
    {
        // Rota el objeto alrededor del eje Y
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
