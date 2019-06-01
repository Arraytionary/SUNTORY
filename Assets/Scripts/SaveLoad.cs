using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class SaveLoad : MonoBehaviour
{
    public Text saveStatus;
    public Text loadStatus;


    public void Save()
    {
        SaveSystem.SaveProgress(Progress.Instance.dict);
        saveStatus.text = "Game Saved";
    }
    public void load(){
        if(SaveSystem.LoadProgress()){
            loadStatus.text = "Load successfully";
        }
        else{
            loadStatus.text = "Save file not Found";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Application.persistentDataPath);
    }
}
