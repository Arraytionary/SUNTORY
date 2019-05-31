using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // public Button startButton;
    // public Button LoadButton;
    public void startGame(){
        Progress.nextScene(0);
    }
    public void loadGame(){
        Debug.Log("load game");
    }
}
