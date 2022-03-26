using System.Collections;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    //
    [SerializeField] TMP_Text timeText;
    [SerializeField] int dueTime;

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
        timeText.text = ": " + dueTime.ToString();
    }

    void Update()
    {
        CheckDueTimeIfZero();
    }

    public IEnumerator CountDown()
    {
        while (dueTime > 0 && !GameManager.Instance.isGameWinning)
        {
            yield return new WaitForSeconds(1);
            dueTime--;
            timeText.text = ": " + dueTime.ToString();
        }
        CheckDueTimeIfZero();
    }

    private void CheckDueTimeIfZero()
    {
        if (dueTime <= 0)
        {
            dueTime = 0;
            timeText.text = ": " + dueTime.ToString();
            GameManager.Instance.TimeIsOver();
        }
    }

    public void AddTime(int addTimeCount)
    {
        dueTime += addTimeCount;
        timeText.text = ": " + dueTime.ToString();
    }

}
