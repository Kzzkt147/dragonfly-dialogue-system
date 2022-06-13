using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(DialogueUI))]
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    public enum DialogueState{NoState, TextTyping, TextFinished, Choice}
    public DialogueState state;

    [SerializeField] private UnityEvent onDialogueStart;
    [SerializeField] private UnityEvent onDialogueEnd;

    private Action _onFinishedTyping;

    private DialogueUI _dialogueUI;
    private ConversationGraph _activeConversation;

    private string _lastSavedDialogue;
    private bool _hasReadFirstDialogue = false;

    private int _selectedButtonIndex = 0;

    private void Awake()
    {
        Instance = this;
        _dialogueUI = GetComponent<DialogueUI>();

        _onFinishedTyping = FinishTyping;

        state = DialogueState.NoState;
    }

    public void StartConversation(ConversationGraph conversationGraph)
    {
        if (state != DialogueState.NoState) return;
        _hasReadFirstDialogue = false;
        onDialogueStart?.Invoke();
        
        _activeConversation = conversationGraph;
        _dialogueUI.EnableDialogue(true);
        _activeConversation.StartConversation();
    }

    public void EndConversation()
    {
        onDialogueEnd?.Invoke();
        state = DialogueState.NoState;
        _dialogueUI.EnableDialogue(false);
        _activeConversation = null;
    }

    public void PlayDialogueLine(string dialogue, int lettersPerSecond)
    {
        _lastSavedDialogue = dialogue;
        _dialogueUI.EnableDialogueScreen(true);
        
        state = DialogueState.TextTyping;
        StartCoroutine(_dialogueUI.TypeDialogue(dialogue, lettersPerSecond, _onFinishedTyping));
    }

    public void UpdateCurrentSpeaker(bool isPlayer)
    {
        _dialogueUI.SetCurrentSpeaker(isPlayer);
    }

    public void SetSpeakerText(string playerName, string speakerName)
    {
        _dialogueUI.SetSpeakerText(playerName, speakerName);
    }

    public void StartChoice(List<string> choices)
    {
        _dialogueUI.EnableChoiceScreen(true, choices);
        _selectedButtonIndex = 0;
        _dialogueUI.SelectButton(_selectedButtonIndex);
        UpdateCurrentSpeaker(true);
        state = DialogueState.Choice;
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
                HandleChoice();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void HandleChoice()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            var choiceNode = _activeConversation.currentNode as ChoiceNode;
            var numberOfButtons = choiceNode.choices.Count;
            
            if (_selectedButtonIndex >= numberOfButtons - 1) return;
            _selectedButtonIndex += 1;
            _dialogueUI.SelectButton(_selectedButtonIndex);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (_selectedButtonIndex <= 0) return;
            _selectedButtonIndex -= 1;
            _dialogueUI.SelectButton(_selectedButtonIndex);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _activeConversation.NextNode("choices " + _selectedButtonIndex);
        }
    }
}
