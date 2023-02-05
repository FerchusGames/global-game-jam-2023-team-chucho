using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private string currentLevel = "Level1";

    public string CurrentLevel { get { return currentLevel; } set { currentLevel = value; } }

    public void LoadCurrentLevel()
    {
        LoadLevel(currentLevel);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
