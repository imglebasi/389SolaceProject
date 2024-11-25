using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace Dialogue
{
    public class DialogManager : MonoBehaviour
    {
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
        }

        void DisplayMessage()
        {
            Message messageToDisplay = currentMessages[activeMessage];
            messageText.text = messageToDisplay.message;

            Actor actorToDisplay = currentActors[messageToDisplay.actorID];
            actorName.text = actorToDisplay.name;
            actorImage.sprite = actorToDisplay.sprite;
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
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

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
        }
    }
}
