using UnityEngine;
using DG.Tweening;

public class RotateObjectScript : MonoBehaviour
{

    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }
}
