using UnityEngine;

public class TileLogic : MonoBehaviour
{
    [SerializeField] private bool _isOnCollision;
    [SerializeField] private int _turnCount = 0;

    private SpriteRenderer spriteRenderer = default;
    private PolygonCollider2D tileCollider = default;

    private void Awake()
    {
        tileCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _turnCount = 0;
        _isOnCollision = false;
    }

    public void Turn()
    {
            if (_turnCount < 1)
            {
                spriteRenderer.color = Color.red;
                _turnCount++;
            }
            else
            {
                DisableTile();
            }
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
