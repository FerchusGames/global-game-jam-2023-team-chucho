using UnityEngine;

public class TileLogic : MonoBehaviour
{
    [SerializeField] private bool _isOnCollision;
    public int TurnCount { get; private set; }

    private SpriteRenderer spriteRenderer = default;
    private PolygonCollider2D tileCollider = default;

    private void Awake()
    {
        tileCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        TurnCount = 0;
        _isOnCollision = false;
    }

    public void Turn()
    {
        spriteRenderer.color = Color.red;
        TurnCount++;       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
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
