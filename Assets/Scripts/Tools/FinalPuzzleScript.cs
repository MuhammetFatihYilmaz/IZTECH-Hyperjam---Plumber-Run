using UnityEngine;

public class FinalPuzzleScript : MonoBehaviour
{
    [SerializeField] GameObject puzzleObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            puzzleObject.SetActive(true);
            GameManager.Instance.SetGameNotPlayable();
        }
    }
}
