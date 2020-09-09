using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    private float currentZoom = 10f;

    public float pitch = 2f;

    public float yawSpeed = 100f;
    //public float pitchSpeed = 100f;

    private float currentYaw = 0f;
    private float currentPitch = 0f;

    public float minPitch = -30f;
    public float maxPitch = 25f;

void Update()
{
    currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

    currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

    //currentPitch += Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
    //currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
}

void LateUpdate()
{
    transform.position = target.position - offset * currentZoom;
    transform.LookAt(target.position + Vector3.up * pitch);

    transform.RotateAround(target.position, Vector3.up, currentYaw);
    transform.RotateAround(target.position, Vector3.right, currentPitch);
}

}
