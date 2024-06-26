using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{
    public GameObject targetObject; // 需要移动的对象

    void Start()
    {
        // 确保目标对象的初始位置在0
        targetObject.transform.position = new Vector3(0, 0, 0);

        // 在1-3秒内将对象移动到100
        LeanTween.moveLocalY(targetObject, 100, 2).setDelay(1).setEase(LeanTweenType.linear);

        // 在2-4秒内将对象从100再移动到200
        LeanTween.moveLocalY(targetObject, 300, 2).setDelay(2).setEase(LeanTweenType.linear);

        //transform.DOMoveY(100, 1).SetEase(Ease.Linear);
    }
}