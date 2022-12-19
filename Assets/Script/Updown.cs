using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updown : MonoBehaviour
{
    bool rotating;
    bool xrot;
    bool yrot;
    float rotateSpeed = 0.5f;
    float fixAngle = 30.0f;
    Vector3 mousePos, offset, rotation;

    void OnMouseDown()
    {
        rotating = true;

        mousePos = Input.mousePosition;
    }

    void CheckRotate()
    { 
       
    }

    void OnMouseUp()
    {
        rotating = false;

        float yAngle = ((int)this.transform.localEulerAngles.y / (int)fixAngle) * fixAngle; // 특정 각도로만 회전
        Vector3 localEulerAngles = this.transform.localEulerAngles;

        localEulerAngles.y = yAngle;
        this.transform.localEulerAngles = localEulerAngles;
    }

    void Update()
    {
        if (rotating)
        {
            offset = (Input.mousePosition - mousePos);

            rotation.x = -(offset.x + offset.y) * rotateSpeed;
            
            transform.Rotate(rotation);

            mousePos = Input.mousePosition;
        }
    }
}
