using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string characterName;

    public Dialogue[] dialogues;

    

    public void TriggerDialogue(string dialogueIdentifier)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            if (dialogue.identifier == dialogueIdentifier)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue, name: characterName);
                return;
            }
        }

        Debug.Log("No dialogue with identifier: " + dialogueIdentifier);
        
    }
}
