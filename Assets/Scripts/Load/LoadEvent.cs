using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Events;

public class LoadEvent : MonoBehaviour
{
    // 实例化
    private static LoadEvent _instance;
    public static LoadEvent Instance { get { return _instance; } }


    private List<SpeedEvent> speedEvent;

    public UnityEvent EventLoadOver;

    public void Awake() { _instance = this; }

    public void Init(Chart chart)
    {
        List<JudgeLine> tempJudgeLineList = chart.judgeLineList;
        for (int i = 0; i < tempJudgeLineList.Count; i++)
        {
            speedEvent = chart.judgeLineList[i].eventLayers[0].speedEvents;
            List<SpeedEvent> tempSpeedList = new();
            SpeedEvent lastSpeedeEvent = new();

            for (int m = 0; m < speedEvent.Count; m++)
            {
                SpeedEvent tempSpeedEvent = new SpeedEvent();
                tempSpeedList.Add(speedEvent[m]);
                if (m < speedEvent.Count - 1)
                {
                    tempSpeedEvent.startTime = speedEvent[m].endTime;
                    tempSpeedEvent.endTime = speedEvent[m + 1].startTime;
                    tempSpeedEvent.start = speedEvent[m].end;
                    tempSpeedEvent.end = speedEvent[m].end;
                    if (!isEqual(tempSpeedEvent.startTime, tempSpeedEvent.endTime))
                    {
                        tempSpeedList.Add(tempSpeedEvent);
                    }
                }
                int[] lastTime = new int[] { 99999, 0, 1 };

                lastSpeedeEvent.startTime = speedEvent[m].endTime;
                lastSpeedeEvent.endTime = lastTime;
                lastSpeedeEvent.start = speedEvent[m].end;
                lastSpeedeEvent.end = speedEvent[m].end;

            }
            tempSpeedList.Add(lastSpeedeEvent);
            tempJudgeLineList[i].eventLayers[0].speedEvents = tempSpeedList;

        }
        chart.judgeLineList = tempJudgeLineList;
    }

    public static bool isEqual(int[] a, int[] b)//两个数组是否相等
    {
        return a.SequenceEqual(b);
    }
}
