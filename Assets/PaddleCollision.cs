using UnityEngine;
using TMPro;

public class PaddleCollision : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int debrisCleared = 0;

    void Start()
    {
        Debug.Log("PaddleCollision script initialized");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            debrisCleared += 1;
            Debug.Log($"Debris cleared: {debrisCleared}");
            if (scoreText != null)
                scoreText.text = $"Debris Cleared: {debrisCleared}";
            else
                Debug.LogWarning("ScoreText not assigned in Inspector");
        }
        else
        {
            Debug.Log($"Non-Block collision, Tag: {collision.gameObject.tag}");
        }
    }
}