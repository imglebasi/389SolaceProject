using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Door _door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Softbodies>(out var script))
        {
            Debug.Log("touched key");
            _door.AddKeyFrag();
            DestroyMe();

        }
    }
}
