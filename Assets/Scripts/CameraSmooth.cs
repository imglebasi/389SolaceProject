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
    private float currentSize;

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
    public IEnumerator ChangeSize(float size, bool doChangeCam, float time)
    {
        currentSize = cam.orthographicSize;

        if (doChangeCam)
        {
            float elapsed = 0;
            while (elapsed <= time)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / time);
                Debug.Log("started cam change process");
                cam.orthographicSize = Mathf.Lerp(currentSize, size, Time.deltaTime);
                yield return null;
            }
        }
        else { Debug.Log("reset"); cam.orthographicSize = defaultCamSize; }
    }
}
