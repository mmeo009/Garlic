using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform cameraLocation;


    float xRotation = 90f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.position = cameraLocation.position;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        transform.position = cameraLocation.position;
    }
    public void Knock(float power)
    {
        Vector3 dir = Random.insideUnitCircle * power;
        dir.z = Random.Range(-10f, 10f) * power;
        cameraLocation.localEulerAngles += dir;
    }
}
