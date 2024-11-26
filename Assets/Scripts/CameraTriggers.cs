using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    public CameraSmooth cam;

    public float offsetx;
    public float offsety;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //offset x = 0, y = 3 to frame scene better
            cam.ChangeOffset(offsetx,offsety);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //reset
            cam.ChangeOffset(0, 0);
        }
    }
}
