using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Progress : Singleton<Progress> 
{
    // public int[] test;
    public IDictionary<string, int> dict = new Dictionary<string, int>(){
        {"demo", 0},
        {"a",0},
        {"b",0}
    };
    // dict.Add();
    // int res;
    // dict.TryGetValue("demo", out res);
    public static void nextScene(int scene){
        // Progress.GlobalMap(scene);
        print(Progress.Instance.dict["a"]);
        List<int> specialScene = new List<int>();
        switch (scene){
            case 11:
                if(Progress.Instance.dict["a"]>0){
                    loadScnene(11);
                }
                else loadScnene(12);
                break;
            case 16:
                if(Progress.Instance.dict["a"]>0) loadScnene(16);
                else loadScnene(17);
                break;
            default:
                loadScnene(scene);
                break;
        }
        
    }
    public static void loadScnene(int scene){
        SceneManager.LoadScene(scene);
    }
}
