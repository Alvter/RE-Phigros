using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    // 实例化
    private static Updater _instance;
    public static Updater Instance { get { return _instance; } }

    public bool isStart = false;
    public float realTime = 0;

    public void Awake() { _instance = this; }

    public void Init()
    {
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) return;

        realTime += Time.deltaTime;
    }
}
