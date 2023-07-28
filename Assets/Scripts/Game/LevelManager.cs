using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class LevelManager : MonoBehaviour
{
    public static int CurrentLevel=1;
    
    private void Start()
    {
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevelKey",1);
        
    }
    public static void NextLevel()
    {
        
        CurrentLevel++;
        PlayerPrefs.SetInt("CurrentLevelKey", CurrentLevel);
        LoadLevel();
        
    }
    public static void LoadLevel()
    {
        Time.timeScale = 1;
        if (CurrentLevel >= SceneManager.sceneCountInBuildSettings)
        {
            CurrentLevel = 1;
            PlayerPrefs.SetInt("CurrentLevelKey", CurrentLevel);

        }
        SceneManager.LoadScene(CurrentLevel);
    }
}
