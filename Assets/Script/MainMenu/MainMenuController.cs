using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public bool clearSaveData;
    public GameObject levelSelectUI;
    public Button[] levelBtns = new Button[0];

    public int levelPassed = 0;

    public void OnStartBtnClick()
    {
        levelSelectUI.SetActive(true);

        if(clearSaveData)
        {
            PlayerPrefs.DeleteAll();
        }

        if(!PlayerPrefs.HasKey("LevelPassed")) //check key ..first time
        {
            PlayerPrefs.SetInt("LevelPassed", 0);
            PlayerPrefs.Save();
        }
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        for(int i = 0; i < levelBtns.Length; i++)
        {
            if( i <= levelPassed)
            {
                levelBtns[i].interactable = true;
            }
            else
            {
                levelBtns[i].interactable = false;
            }
        }
    }

    public void OnBackBtnLevelselectClick()
    {
        levelSelectUI.SetActive(false);
    }

    public void OnLevelBtnClick(int level)
    {
        SceneManager.LoadScene(level);
    }
}
