using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // 实例化
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    public Updater Updater{ get; private set;}
    public LoadChart LoadChart{ get; private set;}
    public ReLoadChart ReLoadChart{ get; private set;}
    public LoadEvent LoadEvent{ get; private set;}


    public void Awake()
    {
        _instance = this;
    }

    public void ScriptStart()
    {
        Updater = Updater.Instance;
        LoadChart = LoadChart.Instance;
        ReLoadChart = ReLoadChart.Instance;
        LoadEvent = LoadEvent.Instance;

        Init();
    }

    void Init()
    {
        
    }
}
