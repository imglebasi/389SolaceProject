using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3 (0,0,-15);
    public GameObject midEmpty;
    public Vector3 midpos;
    public GameObject Player1;
    public GameObject Player2;

    void Start()
    {
        Vector2 midpos = (Player1.transform.position + Player2.transform.position) / 2.0f;
        //offset = transform.position - Player1.transform.position;
    }
    void Update()
    {
        Vector3 midpos = (Player1.transform.position + Player2.transform.position) / 2.0f;
        Vector3 distanceDiff = Player1.transform.position - Player2.transform.position;
        Debug.Log(distanceDiff);
        if (Mathf.Abs(distanceDiff.x) > 15 || Mathf.Abs(distanceDiff.y) > 10)
        {
            GetComponent<Camera>().orthographicSize = 10;
        }
        else
        {
            GetComponent<Camera>().orthographicSize = 6;
        }
        midEmpty.transform.position = midpos;

        UpdateCamPos(midpos);
        
    }
    void UpdateCamPos(Vector3 newmidpos)
    {
        Debug.Log("updated cam pos");
        midEmpty.transform.position = newmidpos;
        transform.position = newmidpos + offset;
    }
}
