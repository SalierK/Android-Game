using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    
    public static Vector2 lastCheckPointPos = new Vector2(-3,0);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;

    public static void ResetPosition()
    {
        lastCheckPointPos = new Vector2(-3, 0);

    }

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player= Instantiate(playerPrefabs[characterIndex],lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;

    }
    

    void Update()
    {

        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
