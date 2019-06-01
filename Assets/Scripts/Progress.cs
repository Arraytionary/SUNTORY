using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class Progress : Singleton<Progress> 
{
    // public int[] test;
    public IDictionary<string, int> dict = new Dictionary<string, int>(){
        {"demo", 0},
        {"a",0},
        {"b",0},
        {"c",0},
        {"se1",0},
        {"se2",0},
        {"se3",0},
        {"see",0},
        {"sp1",0},
        {"sp2",0},
        {"crrSentences",0},
        {"crrScene", 0}
    };
    // dict.Add();
    // int res;
    // dict.TryGetValue("demo", out res);
    public static void nextScene(int scene){
        
        // Progress.GlobalMap(scene);
        //print(Progress.Instance.dict["a"]);
        List<int> specialScene = new List<int>();
        print("scene"+scene);
        print("c "+Progress.Instance.dict["c"]);
        switch (scene){
            case 11:
                if(Progress.Instance.dict["se3"]>0) loadScene(57);
                else if(Progress.Instance.dict["se2"]>0) loadScene(36); //fix this
                else if(Progress.Instance.dict["se1"]>0) loadScene(22);
                else if(Progress.Instance.dict["a"]>0) loadScene(11);
                else loadScene(12);
                break;

            case 16:
                if(Progress.Instance.dict["a"]>0) loadScene(16);
                else loadScene(17);
                break;

            case 18:
                if(Progress.Instance.dict["b"]>1) loadScene(18);
                else loadScene(8);
                break;
                
            case 19:
                if(Progress.Instance.dict["b"]>2) loadScene(19);
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
                if(Progress.Instance.dict["b"]<2){
                    Progress.Instance.dict["se2"] += 1;
                    loadScene(8);
                }
                else if(Progress.Instance.dict["sp1"]>0) {
                    Progress.Instance.dict["sp2"] += 1;
                    loadScene(32);
                }
                else {
                    Progress.Instance.dict["b"] += 1;
                    loadScene(33);
                }
                break;

            case 34:
                if(Progress.Instance.dict["c"]>2) {
                    Progress.Instance.dict["c"] += 2;
                    loadScene(34);
                }
                else {
                    Progress.Instance.dict["c"] += 1;
                    loadScene(35);
                }
                break;
            
            case 36:
                if(Progress.Instance.dict["se3"]>0) loadScene(57);
                else if(Progress.Instance.dict["see"]<1) {
                    loadScene(36);
                }
                else {
                    // Progress.Instance.dict["c"] += 1;
                    loadScene(57); //load Endscene
                }
                break;

            case 38:
                print("sp1"+Progress.Instance.dict["sp1"]);
                if(Progress.Instance.dict["sp1"] > 0){
                    if(Progress.Instance.dict["sp2"] > 0) loadScene(38);
                    else loadScene(39);
                }
                else {
                    loadScene(40);
                }
                break;

            case 41:
                if(Progress.Instance.dict["demo"] > 2) {
                    loadScene(41);
                }
                else {
                    loadScene(47);
                }
                break;

            case 44:
                if(Progress.Instance.dict["c"] > 0) {
                    if(Progress.Instance.dict["c"] > 3) loadScene(44);
                    else loadScene(45);
                }
                else {
                    loadScene(46); //TODO: fix this
                }
                break;

            case 46:
                if(Progress.Instance.dict["b"] > 0 && Progress.Instance.dict["sp1"] > 0) {
                    loadScene(46);
                }
                else {
                    loadScene(57); //TODO: load Ending scene
                }
                break;

            case 48: //if never hazing load hazingN
                if(Progress.Instance.dict["c"]>1){
                    loadScene(48);
                }
                else{
                    Progress.Instance.dict["see"] += 1;
                    print("fuq dis"+Progress.Instance.dict["see"]);
                    loadScene(35);
                }
                break;

            case 49:
                if(Progress.Instance.dict["c"] > 3) {
                    loadScene(49);
                }
                else {
                    nextScene(46); //call scene 46 from with nextScene function
                }
                break;

            case 52:
                Progress.Instance.dict["se3"]+=1;
                if(Progress.Instance.dict["b"] < 1) {
                    loadScene(8);
                }
                else if(Progress.Instance.dict["b"] < 3){
                    nextScene(32);
                }
                else {
                    loadScene(52);
                }
                break;

            case 53:
                if(Progress.Instance.dict["sp1"] < 1) {
                    loadScene(53);
                }
                else {
                    loadScene(56);
                }
                break;

            case 55:
                if(Progress.Instance.dict["sp1"] < 1) {
                    loadScene(55);
                }
                else {
                    nextScene(56);
                }
                break;
            default:
                loadScene(scene);
                break;
        }
        
    }
    public static void loadScene(int scene){
        scene+=1;
        SceneManager.LoadScene(scene);
    }
}
