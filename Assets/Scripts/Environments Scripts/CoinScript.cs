using UnityEngine;

public class CoinScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayCoinSound();
            CoinManager.Instance.IncreaseCoinCount();
            Destroy(gameObject);
        }

    }
}
