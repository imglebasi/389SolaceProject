using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace Dialogue
{
    public class DialogManager : MonoBehaviour
    {
        //public Canvas canvas;
        public Image actorImage;
        public TextMeshProUGUI actorName;
        public TextMeshProUGUI messageText;
        public RectTransform backgroundBox;

        Message[] currentMessages;
        Actor[] currentActors;
        int activeMessage = 0;
        public static bool isActive = false;

        public void OpenDialogue(Message[] messages, Actor[] actors)
        {
            currentMessages = messages;
            currentActors = actors;
            activeMessage = 0;
            isActive = true;

            DisplayMessage();
            backgroundBox.LeanScale(Vector3.one, 0.5f);
        }

        void DisplayMessage()
        {
            Message messageToDisplay = currentMessages[activeMessage];
            messageText.text = messageToDisplay.message;

            Actor actorToDisplay = currentActors[messageToDisplay.actorID];
            actorName.text = actorToDisplay.name;
            actorImage.sprite = actorToDisplay.sprite;

            AnimateTextColor();
        }
        public void NextMessage()
        {
            activeMessage++;
            if (activeMessage < currentMessages.Length)
            {
                DisplayMessage();
            }
            else { Debug.Log("convo ended");
            isActive = false;
                backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }
        }

        void AnimateTextColor()
        {
            LeanTween.textAlpha(messageText.rectTransform, 0, 0);
            LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //have box closed
            backgroundBox.transform.localScale = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isActive == true) {
                NextMessage();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(isActive);
            }

            /*if (!isActive)
            {
                canvas.enabled = false;
            }
            else { canvas.enabled = true; }*/
        }
    }
}
