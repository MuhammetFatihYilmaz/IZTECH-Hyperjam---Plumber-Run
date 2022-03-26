using UnityEngine;

public class BackgroundSoundManager : MonoBehaviour
{
    public static BackgroundSoundManager instance;

    private AudioSource mainBackgroundSound;

    void Awake()
    {

        if (instance == null && instance != this)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        mainBackgroundSound = GetComponent<AudioSource>();
    }
}
