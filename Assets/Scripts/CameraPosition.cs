using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private float sensative;
    [SerializeField] private float maxYAngle;

    private float rotationX = 0.0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * sensative);

        rotationX -= mouseY * sensative;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);

    }
}
