using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : BaseNode
{
    [Output] public int exit;

    [SerializeField] private string playerName;
    [SerializeField] private string speakerName;
    
    public override void ParseNode(ConversationGraph conversationGraph)
    {
        DialogueManager.Instance.SetSpeakerText(playerName, speakerName);
        conversationGraph.NextNode("exit");
    }
}
