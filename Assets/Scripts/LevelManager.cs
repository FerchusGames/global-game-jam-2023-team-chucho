using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{

    public void LoadCurrentLevel()
    {
        LoadLevel(PlayerPrefs.GetString("CurrentLevel"));
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
