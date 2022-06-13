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

### Creating a new conversation

Right click in your assets folder `Create/Conversation Graph`. Double click to open it.

You can right click in the graph editor to create a new node.

***Start*** - The Start Node indicateds to the graph where to begin from. You can also set the Player and Speaker Name here. It will also invoke the onDialogueStart unity event.

***Dialogue*** - The Dialogue Node will write out any string you input into the dialogue window. You can indicate whether it is the player speaking and how quickly the text should type out.

***Choice*** - The Choices Node will show a choice screen in the dialogue window. Add up to 3 choices - and connect each choice to something different if you wish.

***End*** - The End Node will close the dialogue. It will also invoke the onDialogueEnd unity event.

![ExampleNodes](https://user-images.githubusercontent.com/79820324/173321432-449eb468-8826-425e-9d9e-92b5c0a87bbe.PNG)


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

If you are using the example Player and NPC to start the dialogue, then drag in the Player Prefab and the NPC Prefab. Assign a layer to the NPC object and set that layer in the player's layermask field.

To disable player movment when the dialogue is active, call the player's DisableControl/EnableControl methods from the UnityEvents on the `DialogueManager`.


Changing the looks of the dialogue UI is just a matter of replacing images with your own UI assets.

<br>

## To-Do

- [X] This readme :)
- [X] Make dialogue system unable to start a new dialogue when dialogue is already active / (Move responsibility from GameManager/Player --> dialogue system)
- [ ] Refactor Code
- [ ] Strengthen with use of events to allow for more customization.
