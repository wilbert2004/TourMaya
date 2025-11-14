using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PersonajeMovimiento : MonoBehaviour
{
    public float velocidad = 2f;
    Animator anim;
    CharacterController controller;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        if (controller == null) controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        if (dir.magnitude > 1) dir.Normalize();

        controller.Move(dir * velocidad * Time.deltaTime);

        // rotar hacia la dirección de movimiento
        if (dir != Vector3.zero)
            transform.forward = dir;

        // Actualizar el parámetro Speed del Animator
        anim.SetFloat("Speed", dir.magnitude);
    }
}
