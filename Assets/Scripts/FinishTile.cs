using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTile : MonoBehaviour
{
    [SerializeField] private string _nextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objectiveCount = GameManager.Instance.HumanObjectCounter + GameManager.Instance.MonkeyObjectCounter;

        if (collision.CompareTag("Player") && objectiveCount > 1)
        {
            AudioManager.Instance.WinLevelSound();
            GameManager.Instance.ResetObjectCount();
            PlayerPrefs.SetString("CurrentLevel", _nextLevelName);
            Debug.Log("Saved level " + PlayerPrefs.GetString("CurrentLevel") + " in PlayerPrefs");
            LevelManager.Instance.LoadLevel(_nextLevelName);
        }
    }
}
