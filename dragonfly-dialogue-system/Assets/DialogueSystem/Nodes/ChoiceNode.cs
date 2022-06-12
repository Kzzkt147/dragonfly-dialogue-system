using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceNode : BaseNode
{
    [Input] public int entry;

    [TextArea] public string choiceOne;
    [Output] public int exit0;
    
    [TextArea] public string choiceTwo;
    [Output] public int exit1;
    
    [TextArea] public string choiceThree;
    [Output] public int exit2;
    
    public override void ParseNode(ConversationGraph conversationGraph)
    {
        DialogueManager.Instance.StartChoice(choiceOne, choiceTwo, choiceThree);
    }
}
