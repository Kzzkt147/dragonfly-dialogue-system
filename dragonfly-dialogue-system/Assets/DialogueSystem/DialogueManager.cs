using System;
using UnityEngine;

[RequireComponent(typeof(DialogueUI))]
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    public enum DialogueState{NoState, TextTyping, TextFinished, Choice}
    public DialogueState state;

    private Action _onFinishedTyping;

    private DialogueUI _dialogueUI;
    private ConversationGraph _activeConversation;

    private string _lastSavedDialogue;
    private bool _hasReadFirstDialogue = false;

    private void Awake()
    {
        Instance = this;
        _dialogueUI = GetComponent<DialogueUI>();

        _onFinishedTyping = FinishTyping;

        state = DialogueState.NoState;
    }

    public void StartConversation(ConversationGraph conversationGraph)
    {
        _hasReadFirstDialogue = false;
        GameManager.Instance.EnablePlayerController(false);
        
        _activeConversation = conversationGraph;
        _dialogueUI.EnableDialogue(true);
        _activeConversation.StartConversation();
    }

    public void EndConversation()
    {
        GameManager.Instance.EnablePlayerController(true);

        state = DialogueState.NoState;
        _dialogueUI.EnableDialogue(false);
        _activeConversation = null;
    }

    public void PlayDialogueLine(string dialogue, int lettersPerSecond)
    {
        _lastSavedDialogue = dialogue;
        
        StartCoroutine(_dialogueUI.TypeDialogue(dialogue, lettersPerSecond, _onFinishedTyping));
        state = DialogueState.TextTyping;
    }

    public void UpdateCurrentSpeaker(bool isPlayer)
    {
        _dialogueUI.SetCurrentSpeaker(isPlayer);
    }

    public void SetSpeakerText(string playerName, string speakerName)
    {
        _dialogueUI.SetSpeakerText(playerName, speakerName);
    }

    private void FinishTyping()
    {
        state = DialogueState.TextFinished;
    }

    private void Update()
    {
        switch (state)
        {
            case DialogueState.NoState:
                break;
            case DialogueState.TextTyping:
                if (Input.GetKeyDown(KeyCode.E) && _hasReadFirstDialogue)
                {
                    StopAllCoroutines();
                    _dialogueUI.SetDialogue(_lastSavedDialogue, _onFinishedTyping);
                }
                break;
            case DialogueState.TextFinished:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _hasReadFirstDialogue = true;
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
