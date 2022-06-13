using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class ConversationGraph : NodeGraph
{
	public BaseNode currentNode;

	public void StartConversation()
	{
		// set current node to the start node
		foreach (var node in nodes.OfType<StartNode>())
		{
			currentNode = node;
			break;
		}
		// run start node's setup method
		currentNode.ParseNode(this);
	}
	

	public void NextNode(string portFieldName)
	{
		// find the port that matches the given name and set the connected node to the current node
		foreach (var port in currentNode.Ports)
		{
			if (port.fieldName != portFieldName) continue;
			currentNode = port.Connection.node as BaseNode;
			if (currentNode is null) return;
			
			// setup the new node
			currentNode.ParseNode(this);
			break;
		}
	}
}