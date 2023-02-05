using UnityEngine;

public class TileLogic : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = default;
    private PolygonCollider2D tileCollider = default;
    private int turnCount = 0;

    private void Awake()
    {
        tileCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        turnCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered collision with tile in position: " + collision.collider.transform.position);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (turnCount < 1)
            {
                spriteRenderer.color = Color.red;
                turnCount++;
            }
            else
            {
                DisableTile();
                GameManager.Instance.GameOver();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exited Collision");

        if (collision.collider.CompareTag("Player"))
        {
            DisableTile();
        }
    }

    private void DisableTile()
    {
        spriteRenderer.enabled = false;
        tileCollider.enabled = false;
    }
}
