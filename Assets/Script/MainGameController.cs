using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using TMPro;

public class MainGameController : MonoBehaviour
{
    //singleton
    public static MainGameController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public int gold
    {
        get { return _gold;  }
        set
        {
            _gold = value;
            goldText.text = "Fish: " + _gold;
        }
    }

    public int life
    {
        get { return _life; }
        set
        {
            _life = value;
            {
                _life = value;
                lifeText.text = "Life : " + _life;
                if(life == 0) //for GAME OVER UI
                {
                    gameOverUi.SetActive(true);
                    isEndGame = true;
                }
            }
        }
    }

    public int enemyCount{
        get{return _enemyCount;}
        set{
            _enemyCount = value;
            if(_enemyCount == 0 && enemySpawner.isWaveEnd)
            {
                WinUi.SetActive(true);
                PlayerPrefs.SetInt("LevelPassed", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
                isEndGame = true;
            }
        }
    }
   

    private int _gold = 20;
    private int _life = 5;

    private int _enemyCount = 0;

    public bool isEndGame = false;

    public TMP_Text goldText; //UI
    public TMP_Text lifeText;

    public GameObject gameOverUi;
    public GameObject WinUi;

    public EnemySpawner enemySpawner;
    public NodeUiController nodeUi;

    public void OnRetryBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnExitBtnClik()
    {
        SceneManager.LoadScene(0);
    }

    public void OnNextLevelBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
