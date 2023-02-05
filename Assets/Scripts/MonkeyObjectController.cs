using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyObjectController : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<PlayerStateController>().IsHuman)
            {
                gameManager.AddMonkeyObjetcToCount();
                Destroy(gameObject);
            }
        }
    }
}
