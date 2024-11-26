using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Dialogue {
    public class NPC : MonoBehaviour
    {
        
        public bool canstartDialogue;
        public bool playerInTrigger;
        public bool needInput;
        public DialogTrigger trigger;

        public bool hasEffect;
        public Image effectOverlay;
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
                if (needInput)
                {
                    tooltip.text = "E";
                }
                playerInTrigger = true;
            }
            if (hasEffect)
            {
                effectOverlay.enabled = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerInTrigger = false;
                tooltip.text = "";

                //let u trigger events again
                canstartDialogue = true;
            }
            if (hasEffect)
            {
                effectOverlay.enabled = false;
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            tooltip.text = "";
            canstartDialogue = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInTrigger)
            {
                Debug.Log("Player in trigger");
                if (needInput)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        tooltip.text = "";
                        trigger.StartDialogue();
                        canstartDialogue = false;
                    }
                }
                else //do not need input
                {
                    Debug.Log("triggering w/o input");
                    if (canstartDialogue)
                    {
                        trigger.StartDialogue();
                        canstartDialogue = false;
                    }
                }
            }
        }
    }
}
