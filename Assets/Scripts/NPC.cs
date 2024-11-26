using UnityEngine;
using TMPro;

namespace Dialogue {
    public class NPC : MonoBehaviour
    {
        
        public bool startDialogue;
        public bool playerInTrigger;
        public DialogTrigger trigger;

        public TextMeshProUGUI tooltip;

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
      /*  private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                trigger.StartDialogue();
            }
        }*/
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                tooltip.text = "E";
                playerInTrigger = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerInTrigger = false;
                tooltip.text = "";
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            tooltip.text = "";
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInTrigger)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    tooltip.text = "";
                    trigger.StartDialogue();
                }
            }
        }
    }
}
