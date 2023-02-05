using UnityEngine;

public class HumanObjectController : MonoBehaviour
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
            if (collision.GetComponent<PlayerStateController>().IsHuman)
            {
                gameManager.AddHumanObjetcToCount();
                Destroy(gameObject);
            }
        }
    }
}
