using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : BaseNode
{
    [Output] public int exit;
    
    public override void ParseNode(ConversationGraph conversationGraph)
    {
        conversationGraph.NextNode("exit");
    }
}
