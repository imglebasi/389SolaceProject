using UnityEngine;

namespace Dialogue
{

    public class ClickToMove : MonoBehaviour
    {
        //public DialogManager DM;

        public float speed = 5f;
        public GameObject Player;
        //private Rigidbody2D rb;
        private Vector3 target;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            target = transform.position;
            //rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (DialogManager.isActive) return;

            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;

            }

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
