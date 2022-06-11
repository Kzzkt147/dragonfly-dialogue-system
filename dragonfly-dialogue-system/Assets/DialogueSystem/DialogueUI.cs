using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("UI")] [SerializeField] 
    private GameObject dialogueUIObject;

    [Header("Names")]
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI npcNameText;

    [Header("Dialogue")] 
    [SerializeField] private GameObject dialogueScreenObject;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choice")] 
    [SerializeField] private GameObject choiceScreenObject;

    public void EnableDialogue(bool enable)
    {
        dialogueUIObject.SetActive(enable);
    }

    public void EnableDialogueScreen(bool enable)
    {
        dialogueScreenObject.SetActive(enable);
        choiceScreenObject.SetActive(!enable);
    }
    
    public void EnableChoiceScreen(bool enable)
    {
        dialogueScreenObject.SetActive(!enable);
        choiceScreenObject.SetActive(enable);
    }

    public IEnumerator TypeDialogue(string dialogue, int lettersPerSecond, Action onFinishedTyping)
    {
        dialogueText.text = "";
        
        foreach (var letter in dialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        onFinishedTyping?.Invoke();
    }

    public void SetText(string dialogue)
    {
        dialogueText.text = dialogue;
    }
}
