using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentences
{
    public int emote;
    public string name;
    [TextArea(3, 10)]
    public string sentence;

    public bool isChoices;
    public Choice[] choices;
}


[System.Serializable]
public class Choice
{
    public string element;
    public int scene;
    public ToIncrement[] toIncrement;
}

[System.Serializable]
public class ToIncrement{
    public string name;
    public int value;
}

