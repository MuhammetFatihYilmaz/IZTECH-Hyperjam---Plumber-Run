using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PipeCountManager.Instance.DecreasePipeCount();
    }

}
