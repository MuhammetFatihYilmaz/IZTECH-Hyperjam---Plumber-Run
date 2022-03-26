using System.Collections;
using UnityEngine;
using TMPro;

public class IncreaseOrDecrease : MonoBehaviour
{
    [SerializeField] TMP_Text quantityChangerText;
    int rndNumber;
    //
    [SerializeField] TMP_Text addTimeText;

    void Start()
    {
        rndNumber = Random.Range(-10, 10);
        if (rndNumber > 0)
            quantityChangerText.text = "+" + rndNumber.ToString();
        else
            quantityChangerText.text = rndNumber.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeManager.Instance.AddTime(rndNumber);
            if (rndNumber > 0)
            {
                AudioManager.Instance.PlayIncreaseSound();
                addTimeText.color = Color.green;
                addTimeText.text = "+" + rndNumber.ToString();
            }
            else if (rndNumber < 0)
            {
                AudioManager.Instance.PlayDecreaseSound();
                addTimeText.color = Color.red;
                addTimeText.text = rndNumber.ToString();
            }
            else
                addTimeText.text = rndNumber.ToString();
            //
            StartCoroutine(ResetAddTimeText());
        }
    }

    IEnumerator ResetAddTimeText()
    {
        yield return new WaitForSeconds(2f);
        addTimeText.text = "";
    }
}
