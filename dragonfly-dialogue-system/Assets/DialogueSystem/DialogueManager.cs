using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private ConversationGraph _activeConversation;

    private void Awake()
    {
        Instance = this;
    }

    public void StartConversation(ConversationGraph conversationGraph)
    {
        _activeConversation = conversationGraph;
        _activeConversation.StartConversation();
    }

    public void PlayDialogueLine()
    {
        
    }
}
