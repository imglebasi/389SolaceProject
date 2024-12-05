using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Door _door;
    public bool playerNearIndicator;

    private void Start()
    {
        playerNearIndicator = false;
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("touched key");
            playerNearIndicator = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearIndicator = false;
        }
    }
    public void Update()
    {
        if (playerNearIndicator)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("inspected");
                _door.AddKeyFrag();
                DestroyMe();
                playerNearIndicator = false;
            }
        }
    }
}
