using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceNode : BaseNode
{
    [Input] public int entry;

    /*
    [TextArea] public string choiceOne;
    [Output] public int exit0;
    
    [TextArea] public string choiceTwo;
    [Output] public int exit1;
    
    [TextArea] public string choiceThree;
    [Output] public int exit2;
    */

    [TextArea]
    [Output(dynamicPortList = true)] public List<string> choices;
    
    public override void ParseNode(ConversationGraph conversationGraph)
    {
        DialogueManager.Instance.StartChoice(choices);
    }

    private void Awake()
    {
        if (choices == null) return;
        if (choices.Count > 3)
        {
            choices.RemoveRange(3, choices.Count - 3);
        }
    }
}
