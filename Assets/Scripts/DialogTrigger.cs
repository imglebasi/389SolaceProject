using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Dialogue
{
    public class DialogTrigger : MonoBehaviour
    {
        public DialogManager Manager;
        public Message[] messages;
        public Actor[] actors;

        public bool hasBeenStarted = false;

        //public bool requiresEToStart = true;

        public void StartDialogue(int scene) {
            Debug.Log("started dialogue!");
            Manager.OpenDialogue(messages, actors, scene);
        }
    }

    [System.Serializable]
    public class Message {
        public int actorID;
        [TextArea] public string message;
        public Sprite image;
    }

    [System.Serializable]
    public class Actor {
        public string name;
        public Sprite sprite;
    }
}
