using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    public CameraSmooth cam;

    public float offsetx;
    public float offsety;
    public float camSize;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //offset x = 0, y = 3 to frame scene better
            cam.ChangeOffset(offsetx,offsety);
            cam.ChangeSize(camSize, true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //reset
            cam.ChangeOffset(0, 0);
            if(camSize > 0)
            {
                cam.ChangeSize(camSize, false);
            }
        }
    }
}
