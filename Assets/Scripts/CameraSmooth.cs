using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public float offsetx;
    public float offsety;

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3
        (target.position.x, target.position.y,
        transform.position.z);

        transform.position = Vector3.Lerp
        (transform.position,
        new Vector3(targetPosition.x + offsetx, targetPosition.y + offsety, targetPosition.z), smoothing * Time.deltaTime);
    }

    public void ChangeOffset(float x, float y)
    {
        offsetx = x;
        offsety = y;
    }
}
