using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //
    public bool isGamePlayable { get; private set; }
    public bool isGameWinning { get; private set; }
    //
    [SerializeField] int requiredCorrectPuzzlePieceCount;
    [SerializeField] Button nextButton;
    [SerializeField] TMP_Text finishText;
    [SerializeField] GameObject puzzleObject;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject failedText;

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

    void Update()
    {
        if (requiredCorrectPuzzlePieceCount == 0 && !isGameWinning)
            GameWon();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void StartFirstLevelAgain()
    {
        SceneManager.LoadScene(0);
    }

    private void GameWon()
    {
        isGameWinning = true;
        TimeManager.Instance.AddTime(1);
        finishText.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        puzzleObject.SetActive(false);
        AudioManager.Instance.PlayWinSound();
    }

    public void TimeIsOver()
    {
        isGamePlayable = false;
        AudioManager.Instance.StopWalkingSound();
        failedText.SetActive(true);
        restartButton.SetActive(true);
        puzzleObject.SetActive(false);
    }

    public void SetGamePlayable()
    {
        isGamePlayable = true;
    }

    public void SetGameNotPlayable()
    {
        isGamePlayable = false;
    }

    public void DecreaseRequiredCorrectPuzzlePieceCount()
    {
        requiredCorrectPuzzlePieceCount--;
    }
}
