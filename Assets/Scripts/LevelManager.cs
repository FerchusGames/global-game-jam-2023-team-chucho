using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void LoadCurrentLevel()
    {
        if (PlayerPrefs.GetString("CurrentLevel") != "")
        {
            AudioManager.Instance.InlevelMusic();
            LoadLevel(PlayerPrefs.GetString("CurrentLevel"));
        }

        else
        {
            AudioManager.Instance.InlevelMusic();
            LoadLevel("Level1");
        }
    }

    public void LoadLevel(string levelName)
    {
        if (levelName == "WinScreen")
        {
            AudioManager.Instance.WinGameSong();
        }
        SceneManager.LoadScene(levelName);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        AudioManager.Instance.BackgroundMusic();
        SceneManager.LoadScene("Menus");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
