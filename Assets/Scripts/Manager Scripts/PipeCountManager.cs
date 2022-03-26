using UnityEngine;
using TMPro;

public class PipeCountManager : MonoBehaviour
{
    public static PipeCountManager Instance { get; private set; }

    [SerializeField] TMP_Text pipeCountText;
    private int totalPipeCount = 0;
    //
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
        pipeCountText.text = ": " + totalPipeCount.ToString();
    }

    public void DecreasePipeCount()
    {
        if(totalPipeCount>0)
        {
            AudioManager.Instance.PlayObstackleSound();
            totalPipeCount--;
            pipeCountText.text = ": " + totalPipeCount.ToString();
        }
    }

    public void IncreasePipeCount()
    {   
        totalPipeCount++;
        pipeCountText.text = ": " + totalPipeCount.ToString();
    }
}
