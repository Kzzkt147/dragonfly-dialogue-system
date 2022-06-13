using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class BaseNode : Node 
{
	// ignore
	public override object GetValue(NodePort port) {
		return null; 
	}

	public abstract void ParseNode(ConversationGraph conversationGraph);
}