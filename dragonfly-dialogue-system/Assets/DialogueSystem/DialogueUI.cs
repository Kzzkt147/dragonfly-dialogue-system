using System;
using System.Collections;
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
    [SerializeField] private Image playerNamePanel;
    [SerializeField] private Image npcNamePanel;

    [Header("Dialogue")] 
    [SerializeField] private GameObject dialogueScreenObject;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choice")] 
    [SerializeField] private GameObject choiceScreenObject;
    [SerializeField] private Button[] choiceButtons;

    public void EnableDialogue(bool enable)
    {
        dialogueUIObject.SetActive(enable);
    }

    public void SetCurrentSpeaker(bool isPlayer)
    {
        if (isPlayer)
        {
            playerNamePanel.color = Color.green;
            npcNamePanel.color = Color.white;
        }
        else
        {
            playerNamePanel.color = Color.white;
            npcNamePanel.color = Color.green;
        }
    }

    public void SetSpeakerText(string playerName, string speakerName)
    {
        playerNameText.text = playerName;
        npcNameText.text = speakerName;
    }

    public void EnableDialogueScreen(bool enable)
    {
        dialogueScreenObject.SetActive(enable);
        choiceScreenObject.SetActive(!enable);
    }
    
    public void EnableChoiceScreen(bool enable, string choice0, string choice1, string choice2)
    {
        dialogueScreenObject.SetActive(!enable);
        choiceScreenObject.SetActive(enable);
        
        for (var i = 0; i < choiceButtons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    choiceButtons[i].UpdateButtonText(choice0);
                    break;
                case 1:
                    choiceButtons[i].UpdateButtonText(choice1);
                    break;
                case 2:
                    choiceButtons[i].UpdateButtonText(choice2);
                    break;
            }
        }
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

    public void SetDialogue(string dialogue, Action onFinishedTyping)
    {
        dialogueText.text = dialogue;
        onFinishedTyping?.Invoke();
    }

    public void SelectButton(int buttonIndex)
    {
        for (var i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SelectButton(i == buttonIndex);
        }
    }
}
