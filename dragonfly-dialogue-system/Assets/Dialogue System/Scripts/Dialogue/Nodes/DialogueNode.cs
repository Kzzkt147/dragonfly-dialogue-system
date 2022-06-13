using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : BaseNode
{
    [Input] public int entry;
    
    [SerializeField] private bool isPlayerSpeaking;
    
    [TextArea]
    [SerializeField] private string dialogue;

    [SerializeField] private int lettersPerSecond = 25;
    
    [Output] public int exit;
    
    public override void ParseNode(ConversationGraph conversationGraph)
    {
        DialogueManager.Instance.UpdateCurrentSpeaker(isPlayerSpeaking);
        DialogueManager.Instance.PlayDialogueLine(dialogue, lettersPerSecond);
    }
}
