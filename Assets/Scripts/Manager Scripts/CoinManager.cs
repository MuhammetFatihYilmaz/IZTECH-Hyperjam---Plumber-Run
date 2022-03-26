using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] TMP_Text coinText;
    private int totalCoinCount = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        coinText.text = ": " + totalCoinCount.ToString();
    }

    public void IncreaseCoinCount()
    {
        totalCoinCount += 1;
        coinText.text = ": " + totalCoinCount.ToString();
    }
}
