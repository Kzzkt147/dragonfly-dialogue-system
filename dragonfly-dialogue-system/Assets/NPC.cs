using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private ConversationGraph conversationGraph;
    
    public void Interact()
    {
        DialogueManager.Instance.StartConversation(conversationGraph);
    }
}
