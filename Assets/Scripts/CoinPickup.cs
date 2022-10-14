using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip coinPickUpSFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<GameSession>().AddScore(100);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
