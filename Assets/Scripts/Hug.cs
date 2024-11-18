using UnityEngine;

public class Hug : MonoBehaviour
{
    public bool isSafe;

    void Start()
    {
        isSafe = false;
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hug>(out var otherHug))
        {
            isSafe = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Hug>(out var otherHug))
        {
            isSafe = false;
        }
    }
}
