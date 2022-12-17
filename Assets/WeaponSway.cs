using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Pos")]
    public float intensity;
    public float maxIntensity;
    public float smooth;
    private Vector3 initialPosition;

    [Header("Sway Rotation")]
    public float rotIntensity;
    public float maxRotAmount;
    public float rotSmooth;
    private Quaternion initialRotation;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        CalcSway();
        SwayMove();
        SwayTilt();
    }

    private void CalcSway()
    {
        mouseX = -Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");
    }

    private void SwayMove()
    {
        float moveX = Mathf.Clamp(mouseX * intensity, -maxIntensity, maxIntensity);
        float moveY = Mathf.Clamp(mouseY * intensity, -maxIntensity, maxIntensity);

        Vector3 targetPosition = new Vector3(moveX, moveY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition + initialPosition, Time.deltaTime * smooth);
    }

    private void SwayTilt()
    {
        Quaternion weaponAdjustX = Quaternion.AngleAxis(rotIntensity * mouseX, Vector3.up);
        Quaternion weaponAdjustY = Quaternion.AngleAxis(rotIntensity * mouseY, Vector3.up);
        Quaternion targetRotation = initialRotation * weaponAdjustX * weaponAdjustY;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotSmooth); 
    }
}
