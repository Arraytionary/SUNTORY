using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoicesManager : MonoBehaviour
{
    public Button[] buttons;
    private int[] sceneSlots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RenderChoices(Choice[] choices)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < choices.Length )
            {
                buttons[i].gameObject.SetActive(true);
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i].element;
                //Debug.Log(choices[i].scene);
                // foreach(ToIncrement el in choices[i].toIncrement){
                //     Progress.Instance.dict[el.name] += el.value;
                // }
                // Debug.Log(Progress.Instance.dict["demo"]);
                int scene = choices[i].scene;
                ToIncrement[] tic = choices[i].toIncrement;
                buttons[i].onClick.AddListener(() => ChangeScene(scene, tic));
            }
            else break;
        }
    }

    private void ChangeScene(int scene, ToIncrement[] tic)
    {   
        foreach(ToIncrement el in tic){
                    Progress.Instance.dict[el.name] += el.value;
                }
        Progress.Instance.dict["crrSentences"] = 0;
        Progress.nextScene(scene);
        // Progress.GlobalMap(2);
    }
}
