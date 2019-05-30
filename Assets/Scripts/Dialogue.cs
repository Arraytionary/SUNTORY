using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public int nextScene;
    public bool fadeIn;
    //[TextArea(3, 10)]
    public Sentences[] sentences; 
}
