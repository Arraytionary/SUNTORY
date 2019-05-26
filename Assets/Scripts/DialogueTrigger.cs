using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool isTrigg;

    public void Start()
    {
        isTrigg = false;
    }
    public void Update()
    {
        if (!isTrigg)
        {
            TriggerDialogue();
            isTrigg = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
