using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Found another SaveManager instance");
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void ResetSave()
    {
        PlayerPrefs.SetString("CurrentLevel", "Level1");
    }

    public void StartAgain()
    {
        ResetSave();
        LevelManager.Instance.LoadMenu();
    }
}
