using UnityEngine;

public class PipeScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayPipeSound();
            PipeCountManager.Instance.IncreasePipeCount();
            Destroy(gameObject);
        }
    }
}
