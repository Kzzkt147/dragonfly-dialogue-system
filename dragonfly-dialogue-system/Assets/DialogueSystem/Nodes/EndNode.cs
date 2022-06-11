using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : BaseNode
{
    [Input] public int exit;
    
    public override void ParseNode(ConversationGraph conversationGraph)
    {
        DialogueManager.Instance.EndConversation();
    }
}
