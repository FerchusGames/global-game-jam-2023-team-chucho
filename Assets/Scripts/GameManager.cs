using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int humanObjectCounter = default;
    private int monkeyObjectCounter = default;

    public int HumanObjectCounter { get { return humanObjectCounter; } }
    public int MonkeyObjectCounter { get { return monkeyObjectCounter; } }

    public void AddHumanObjetcToCount()
    {
        humanObjectCounter++;
    }

    public void AddMonkeyObjetcToCount()
    {
        monkeyObjectCounter++;
    }
}

