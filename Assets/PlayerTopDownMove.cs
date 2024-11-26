using UnityEngine;

namespace Dialogue
{
    public class PlayerTopDownMove : MonoBehaviour
    {
        public DialogManager DM;
        public float playerSpeed;
        public Rigidbody2D rb;
        private Vector2 playerDirection;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (DialogManager.isActive) return;
            Debug.Log("accepting input!");
            float directionX = Input.GetAxisRaw("Horizontal");
            float directionY = Input.GetAxisRaw("Vertical");
            playerDirection = new Vector2(directionX, directionY).normalized;
        }
        void FixedUpdate()
        {
            if (DialogManager.isActive) return;
            rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
        }
    }
}
