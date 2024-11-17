using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    public Vector3 midpos;
    public GameObject Player1;
    public GameObject Player2;

    void Start()
    {
        Vector2 midpos = (Player1.transform.position + Player2.transform.position) / 2.0f;
        offset = transform.position - Player1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        midpos = (Player1.transform.position + Player2.transform.position) / 2.0f;

        transform.position = offset + Player1.transform.position;
    }
}
