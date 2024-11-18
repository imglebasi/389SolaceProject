using UnityEngine;
using Unity.UI;

public class Door : MonoBehaviour
{
    public bool isLocked;
    public int keyFrag = 0;
    public int keysRequired = 3;
    private Color opaque = new Color(255, 255, 255, 50);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddKeyFrag()
    {
        keyFrag++;
        DestroyDoor(keyFrag);
    }

    public void DestroyDoor(int pieces)
    {
        Debug.Log("tried to destroy door");
        if (pieces > keysRequired - 1)
        {
            isLocked = false;
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<SpriteRenderer>().color = opaque;
        }
        else
        {
            Debug.Log("not enough key frags!");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
