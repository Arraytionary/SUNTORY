using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Animator characterAnim;
    private Queue<Sentences> sentences;
    private Regex reg;

    void Start()
    {
        sentences = new Queue<Sentences>();
        string test = "*1* hello";
        reg = new Regex("[*](.*?)[*]");
        //Debug.Log(reg.Match(test));
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //characterAnim.SetBool("isEnd", false);

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();
        // foreach(int i in Progress.Instance.test){
        //      Debug.Log(i);
        // }
        Debug.Log(Progress.Instance.dict["demo"]);
       
        foreach (Sentences sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        characterAnim.SetInteger("animNum", 0);
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        //characterAnim.SetInteger("animNum", 1);
        if (sentences.Count == 0)
        {
            EnDialogue();
            return;
        }
        Sentences block = sentences.Dequeue();

        if (block.isChoices)
        {
            DisplayChoices(block.choices);
            return;
        }

        string sentence = block.sentence;
        int emote = block.emote;

        //sentence = DisPlayCharAnim(sentence);
        characterAnim.SetInteger("animNum", emote);

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

    public string DisPlayCharAnim(string sentence) {
        Match m = reg.Match(sentence);
        if (m.Success)
        {
            string animNum = m.Value.Substring(1, m.Value.Length - 2);
            Debug.Log(reg.Match(sentence));
            characterAnim.SetInteger("animNum", int.Parse(animNum));
        }
        
        //characterAnim.SetInteger("animNum", animNum);
        reg.Replace(sentence, "");
        return sentence;
    }

    void EnDialogue(){
        //characterAnim.SetInteger("animNum", 2);
        animator.SetBool("IsOpen", false);
        characterAnim.SetInteger("animNum", 9);
        characterAnim.SetBool("isEnd", true);
        Debug.Log("End of conversation");
    }

    void DisplayChoices(Choice[] choices)
    {
        EnDialogue();
        FindObjectOfType<ChoicesManager>().RenderChoices(choices);
    }
}
