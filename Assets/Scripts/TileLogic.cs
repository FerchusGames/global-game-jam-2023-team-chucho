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
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (turnCount < 1)
            {
                turnCount++;
            }
            else
            {
                spriteRenderer.color = Color.red;
                tileCollider.enabled = false;
                turnCount = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            spriteRenderer.color = Color.red;
            tileCollider.enabled = false;
        }
    }

}
