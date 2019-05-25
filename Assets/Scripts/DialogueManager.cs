using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();
        // foreach(int i in Progress.Instance.test){
        //      Debug.Log(i);
        // }
        Debug.Log(Progress.Instance.dict["demo"]);
       
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0)
        {
            EnDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
    void EnDialogue(){
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }
}
