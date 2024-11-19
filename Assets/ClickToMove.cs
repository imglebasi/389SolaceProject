using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float speed = 5f;
    public GameObject CenterPoint;
    private Rigidbody2D rb;
    private Vector3 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = CenterPoint.transform.position;
        rb = CenterPoint.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

        }

        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(target.x * speed, target.y * speed);
    }
}
