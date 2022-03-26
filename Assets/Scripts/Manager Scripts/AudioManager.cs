using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    //
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource walkingSound;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip pipeSound;
    [SerializeField] AudioClip obstacleSound;
    [SerializeField] AudioClip increaseSound;
    [SerializeField] AudioClip decreaseSound;
    [SerializeField] AudioClip correctPuzzlePieceSound;

    private void Awake()
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


    public void PlayWalkingSound()
    {
        walkingSound.Play();
    }

    public void StopWalkingSound()
    {
        walkingSound.Stop();
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlayPipeSound()
    {
        audioSource.PlayOneShot(pipeSound);
    }

    public void PlayObstackleSound()
    {
        audioSource.PlayOneShot(obstacleSound);
    }

    public void PlayIncreaseSound()
    {
        audioSource.PlayOneShot(increaseSound);
    }

    public void PlayDecreaseSound()
    {
        audioSource.PlayOneShot(decreaseSound);
    }

    public void PlayCorrectPuzzlePieceSound()
    {
        audioSource.PlayOneShot(correctPuzzlePieceSound);
    }
}
