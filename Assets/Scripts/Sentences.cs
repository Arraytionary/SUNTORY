using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentences
{
    public int emote;
    public bool isChoices;
    public Choice[] choices;
    public string name;
    [TextArea(3, 10)]
    public string sentence;

}


[System.Serializable]
public class Choice
{
    public string element;
    public int scene;
}

