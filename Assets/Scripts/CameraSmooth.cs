using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSmooth : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public float smoothing;
    public float offsetx;
    public float offsety;
    public float defaultCamSize;

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3
        (target.position.x, target.position.y,
        transform.position.z);

        transform.position = Vector3.Lerp
        (transform.position,
        new Vector3(targetPosition.x + offsetx, targetPosition.y + offsety, targetPosition.z), smoothing * Time.deltaTime);
    }

    private void Start()
    {
        cam.orthographicSize = defaultCamSize;
    }

    public void ChangeOffset(float x, float y)
    {
        offsetx = x;
        offsety = y;
    }
    public void ChangeSize(float size, bool doChangeCam)
    {
        if (doChangeCam)
        {
            cam.orthographicSize = size;
        }
        else { cam.orthographicSize = defaultCamSize; }
    }
}
