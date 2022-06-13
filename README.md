# Dragonfly Dialogue System

A node-based branching dialogue system for creating custom dialogue with branching options from player responses. Create your own conversation graphs and add dialogue nodes and choice nodes.

![Dialogue Graph](https://user-images.githubusercontent.com/79820324/173307069-80d6342b-6b04-47e7-ba17-14083107f8fb.PNG)

## Download
<details>

<summary>Download & Installation</summary>
<br>
  
[Download](https://github.com/Kzzkt147/dragonfly-dialogue-system/releases)
  
### Installation
Download the unity package and install into your unity project. If your project does not have TextMeshPro installed - it will prompt you to install it whenever text should appear on screen.
  
</details>

<br>

## How it works

### Example Scene

In the example scene, there is a `DialogueManager`, `PlayerController`, and `NPC`.

`PlayerController` will handle movement and interacting with things with the NPC with 'E'.

`NPC` will start the dialogue system by calling the `DialogueManager.Instance.StartConversation(conversationGraph)`, passing in a refernce to a conversation graph.

**NOTE: The player will only interact with NPC's that are on the same layer sepcified in the inspector - you may wish to make sure this is set / change it if you are importing into a fresh project**


### If you wish to create this in your own scene

Drag in the `Dialogue System` prefab into your heirarchy. This will control all of the dialogue.

To start the dialogue system in script, simply call 
```cs
DialogueManager.Instance.StartConversation(conversationGraph)
```
You may want to do this on your own NPC script and give that script a reference to a `ConversationGraph` via the inspector.

(If you are creating your own player scripts and interaction system, you should disable movement and interaction via the UnityEvents on the `DialogueManager`.

Changing the looks of the dialogue UI is just a matter of replacing images with your own UI assets.

<br>

## To-Do

- [ ] Make dialogue system unable to start a new dialogue when dialogue is already active / (Move responsibility from player/manager --> dialogue system)
- [ ] Refactor Code
