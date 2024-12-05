using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Dialogue {
    public class NPC : MonoBehaviour
    {
        private bool canStartDialogue;
        private bool playerInTrigger;
        
        //check if player needs to press E
        public bool needInput;
        public DialogTrigger trigger;

        //if some visual or sfx should play
        public bool hasEffect;
        public GameObject effectOverlay;
        public TextMeshProUGUI tooltip;

        //set this so diff things trigger
        public int sceneNum;

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
                Debug.Log("has effect, trigger it!");
                effectOverlay.SetActive(true);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerInTrigger = false;
                tooltip.text = "";

                //let u trigger events again
                canStartDialogue = true;
            }
            if (hasEffect)
            {
                effectOverlay.SetActive(false);
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            tooltip.text = "";
            canStartDialogue = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInTrigger)
            {
                //Debug.Log("Player in trigger");
                if (needInput)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        tooltip.text = "";
                        trigger.StartDialogue(sceneNum);
                        canStartDialogue = false;
                    }
                }
                else //do not need input
                {
                    //Debug.Log("triggering w/o input");
                    if (canStartDialogue)
                    {
                        trigger.StartDialogue(sceneNum);
                        canStartDialogue = false;
                    }
                }
            }
        }
    }
}
