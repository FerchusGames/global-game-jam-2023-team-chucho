using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void LoadCurrentLevel()
    {
        if (PlayerPrefs.GetString("CurrentLevel") != "")
        {
            LoadLevel(PlayerPrefs.GetString("CurrentLevel"));
        }

        else
        {
            LoadLevel("Level1");
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menus");
    }
}
