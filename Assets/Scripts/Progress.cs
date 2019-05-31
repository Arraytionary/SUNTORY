using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Progress : Singleton<Progress> 
{
    // public int[] test;
    public IDictionary<string, int> dict = new Dictionary<string, int>(){
        {"demo", 0},
        {"a",0},
        {"b",0},
        {"c",0},
        {"se1",0},
        {"sp1",0},
        {"sp2",0}
    };
    // dict.Add();
    // int res;
    // dict.TryGetValue("demo", out res);
    public static void nextScene(int scene){
        // Progress.GlobalMap(scene);
        //print(Progress.Instance.dict["a"]);
        List<int> specialScene = new List<int>();
        switch (scene){
            case 11:
                if(Progress.Instance.dict["se1"]>0) loadScene(22); //fix this
                else if(Progress.Instance.dict["a"]>0) loadScene(11);
                else loadScene(12);
                break;

            case 16:
                if(Progress.Instance.dict["a"]>0) loadScene(16);
                else loadScene(17);
                break;

            case 18:
                if(Progress.Instance.dict["b"]>0) loadScene(18);
                else loadScene(8);
                break;
                
            case 19:
                if(Progress.Instance.dict["b"]>1) loadScene(19);
                else loadScene(22);
                break;

            case 22:
                if(Progress.Instance.dict["b"]>1) loadScene(22);
                else loadScene(23);
                break;

            case 24:
                if(Progress.Instance.dict["a"]>0) loadScene(24);
                else loadScene(25);
                break;

            case 26:
                if(Progress.Instance.dict["demo"]>1) loadScene(26);
                else loadScene(27);
                break;

            case 29:
                if(Progress.Instance.dict["demo"]>2) loadScene(29);
                else loadScene(30);
                break;

            case 32:
                if(Progress.Instance.dict["sp1"]>0) {
                    Progress.Instance.dict["sp2"] += 1;
                    loadScene(32);
                }
                else {
                    Progress.Instance.dict["b"] += 1;
                    loadScene(33);
                }
                break;

            case 34:
                if(Progress.Instance.dict["c"]>1) {
                    Progress.Instance.dict["c"] += 2;
                    loadScene(34);
                }
                else {
                    Progress.Instance.dict["c"] += 1;
                    loadScene(35);
                }
                break;

                case 38:
                if(Progress.Instance.dict["sp1"] > 0) {
                    if(Progress.Instance.dict["sp2"] > 0) loadScene(38);
                    else loadScene(39);
                }
                else {
                    loadScene(39);
                }
                break;

                default:
                loadScene(scene);
                break;
        }
        
    }
    public static void loadScene(int scene){
        SceneManager.LoadScene(scene);
    }
}
