using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPerspectiveCamera : MonoBehaviour
{
    public bool tPerson = true;

    [Header("Objetivos de cámara")]
    public Transform tpTarget;
    public Transform fpTarget;

    [Header("Visibilidad de Jugador")]
    public bool disablePlayerMesh = true;
    public GameObject playerMesh;

    private Vector2 angle = new Vector2(90 * Mathf.Deg2Rad, 0);
    private Camera cam;
    private Vector2 nearPlaneSize;
    private Transform follow;
    private float defaultDistance;
    private float newDistance;

    [Header("Ajustes de Cámara")]
    public float maxDistance = 7f;
    public float minDistance = 2f;
    public int zoomVelocity = 300;
    public float zoomSmooth = 0.1f;
    public Vector2 sensitivity = new Vector2(1, 1);

    [Header("Tecla para cambiar perspectiva")]
    public KeyCode keyCode = KeyCode.Q;


    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("No se encontró componente Camera en el objeto.");
            return;
        }

        ChangePerspective(tPerson);

        defaultDistance = (maxDistance + minDistance) / 2f;
        newDistance = defaultDistance;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CalculateNearPlaneSize();
    }

    void ChangePerspective(bool thirdPerson)
    {
        tPerson = thirdPerson;
        follow = thirdPerson ? tpTarget : fpTarget;

        if (disablePlayerMesh && playerMesh != null)
            playerMesh.SetActive(thirdPerson);
    }

    void CalculateNearPlaneSize()
    {
        float height = Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad / 2f) * cam.nearClipPlane;
        float width = height * cam.aspect;
        nearPlaneSize = new Vector2(width, height);
    }

    Vector3[] GetCameraCollisionPoints(Vector3 direction)
    {
        Vector3 center = follow.position + direction * (cam.nearClipPlane + 0.4f);
        Vector3 right = transform.right * nearPlaneSize.x;
        Vector3 up = transform.up * nearPlaneSize.y;

        return new Vector3[]
        {
            center - right + up,
            center + right + up,
            center - right - up,
            center + right - up
        };
    }

    void Update()
    {
        angle.x += Input.GetAxis("Mouse X") * Mathf.Deg2Rad * sensitivity.x;
        angle.y += Input.GetAxis("Mouse Y") * Mathf.Deg2Rad * sensitivity.y;
        angle.y = Mathf.Clamp(angle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);

        if (tPerson)
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            newDistance -= scrollDelta * Time.deltaTime * zoomVelocity;
            newDistance = Mathf.Clamp(newDistance, minDistance, maxDistance);
            defaultDistance = Mathf.Lerp(defaultDistance, newDistance, zoomSmooth);
        }
        else
        {
            defaultDistance = 0.1f;
        }

        if (Input.GetKeyDown(keyCode))
        {
            ChangePerspective(!tPerson);
        }
    }

    void LateUpdate()
    {
        Vector3 direction = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
        );

        float distance = defaultDistance;
        foreach (Vector3 point in GetCameraCollisionPoints(direction))
        {
            if (Physics.Raycast(point, direction, out RaycastHit hit, defaultDistance))
            {
                distance = Mathf.Min((hit.point - follow.position).magnitude, distance);
            }
        }

        transform.position = follow.position + direction * distance;
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }
}