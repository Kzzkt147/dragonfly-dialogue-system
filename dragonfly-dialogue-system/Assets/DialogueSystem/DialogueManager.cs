using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(DialogueUI))]
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    public enum DialogueState{TextTyping, TextFinished, Choice}
    public DialogueState state;

    private Action _onFinishedTyping;

    private DialogueUI _dialogueUI;
    private ConversationGraph _activeConversation;

    private void Awake()
    {
        Instance = this;
        _dialogueUI = GetComponent<DialogueUI>();

        _onFinishedTyping = FinishTyping;

        state = DialogueState.TextTyping;
    }

    public void StartConversation(ConversationGraph conversationGraph)
    {
        GameManager.Instance.EnablePlayerController(false);
        
        _activeConversation = conversationGraph;
        _dialogueUI.EnableDialogue(true);
        _activeConversation.StartConversation();
    }

    public void EndConversation()
    {
        GameManager.Instance.EnablePlayerController(true);
        
        _dialogueUI.EnableDialogue(false);
        _activeConversation = null;
    }

    public void PlayDialogueLine(string dialogue, int lettersPerSecond)
    {
        state = DialogueState.TextTyping;
        StartCoroutine(_dialogueUI.TypeDialogue(dialogue, lettersPerSecond, _onFinishedTyping));
    }

    private void FinishTyping()
    {
        state = DialogueState.TextFinished;
    }

    private void Update()
    {
        switch (state)
        {
            case DialogueState.TextTyping:
                break;
            case DialogueState.TextFinished:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _activeConversation.NextNode("exit");
                }
                break;
            case DialogueState.Choice:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
