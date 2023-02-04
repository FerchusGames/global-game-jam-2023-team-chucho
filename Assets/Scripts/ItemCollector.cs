using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int bananas = 0;
    [SerializeField] TextMeshProUGUI bananaText = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MonkeyObject"))
        {
            Destroy(collision.gameObject);
            bananas++;
            bananaText.text = bananas.ToString();
        }
    }
}
