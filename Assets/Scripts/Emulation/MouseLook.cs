using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    private float rotationX;
    private float rotationY;

    const float MIN_X = 0.0f;
    const float MAX_X = 360.0f;
    const float MIN_Y = -90.0f;
    const float MAX_Y = 90.0f;

    public float Sensitivity = 300;

    void Awake()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        rotationX = euler.x;
        rotationY = euler.y;
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        if (rotationX < MIN_X) rotationX += MAX_X;
        else if (rotationX > MAX_X) rotationX -= MAX_X;
        rotationY -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);
        if (rotationY < MIN_Y) rotationY = MIN_Y;
        else if (rotationY > MAX_Y) rotationY = MAX_Y;

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0.0f);
    }
}