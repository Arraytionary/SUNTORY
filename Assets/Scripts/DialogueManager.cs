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
    public Button continueButton;

    void Start()
    {
        sentences = new Queue<Sentences>();
        string test = "*1* hello";
        reg = new Regex("[*](.*?)[*]");
        //Debug.Log(reg.Match(test));
    }

    /*
     *start the dialogue by putting sentence from dialogue into sentence queue 
    */ 
    public void StartDialogue (Dialogue dialogue)
    {
        //characterAnim.SetBool("isEnd", false);

        animator.SetBool("IsOpen", true);
        //nameText.text = dialogue.name;
        

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

    /*
     * fetch sentences queue and display the dialogue
    */ 
    public void DisplayNextSentence(){
        //characterAnim.SetInteger("animNum", 1);
        if (sentences.Count == 0)
        {
            EnDialogue();
            return;
        }
        continueButton.gameObject.SetActive(false);
        Sentences block = sentences.Dequeue();

        if (block.isChoices)
        {
            EnDialogue();
            DisplayChoices(block.choices);
            return;
        }

        string name = block.name;

        //make this looks nicer
        MatchTextColor(name);


        string sentence = block.sentence;
        int emote = block.emote;


        //sentence = DisPlayCharAnim(sentence);
        characterAnim.SetInteger("animNum", emote);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    /*
     *animate text in dialogue box one by one 
    */ 
    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        continueButton.gameObject.SetActive(true);
    }

    /*
     * play character animation 
    */
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

    /*
    *end the dialogue in the scene
    *animate out the dialogue box & character
    */
    void EnDialogue(){
        //characterAnim.SetInteger("animNum", 2);
        animator.SetBool("IsOpen", false);
        characterAnim.SetInteger("animNum", 9);
        characterAnim.SetBool("isEnd", true);
        Debug.Log("End of conversation");
    }

    void DisplayChoices(Choice[] choices)
    {
        FindObjectOfType<ChoicesManager>().RenderChoices(choices);
    }

    /*
     *match the dialogue text to the speaker 
    */
    void MatchTextColor(string name)
    {
        if (name != "")
        {
            dialogueText.color = new Color(1f, 189f / 255f, 234f / 255f);
        }
        else dialogueText.color = new Color(1f, 1f, 1f);
        nameText.text = name;
    }
}
