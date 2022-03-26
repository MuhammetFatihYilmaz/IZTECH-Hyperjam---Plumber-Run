using UnityEngine;
using DG.Tweening;

public class MovingIncreaseOrDecrease : MonoBehaviour
{

    void Start()
    {
        transform.DOMoveX(2, 2, false).SetLoops(-1, LoopType.Yoyo);
    }

}
