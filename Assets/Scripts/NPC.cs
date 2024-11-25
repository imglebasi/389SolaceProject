using UnityEngine;

namespace Dialogue {
    public class NPC : MonoBehaviour
    {
        
        public bool startDialogue;
        public DialogTrigger trigger;


        /* private void OnTriggerEnter2D(Collider2D collision)
         {
             if (collision.gameObject.CompareTag("Player"))
             {
                 startDialogue = true;
                 Debug.Log("player in trigger, start dualogue!!");
                 if (startDialogue)
                 {
                     trigger.StartDialogue();
                     startDialogue = false;
                 }
             }
         }*/
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                trigger.StartDialogue();
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
