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
        Progress.loadScene(0);
    }
}
