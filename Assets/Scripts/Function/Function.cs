using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadChart;

public class Function : MonoBehaviour
{
    // 实例化
    private static Function _instance;
    public static Function Instance { get { return _instance; } }

    public List<BPMData> bpmList;

    public int[] speedIndex;

    private Chart chart;

    void Awake() { _instance = this; }

    public void Init(Chart chart)
    {
        this.chart = chart;
        
        bpmList = chart.BPMList;

        for (int i = 0; i < chart.judgeLineList.Count; i++)
        {
            speedIndex = new int[chart.judgeLineList.Count];
            speedIndex[i] = 0;
        }
    }

    /*public static float BpmTime(int[] x)
    {
        float time = (x[0] + (float)x[1] / x[2])*60/startGame.bpm;
        return time;

    }*/

    public float bpmTime(int[] x)
    {

        float beat = x[0] + (float)x[1] / x[2];

        if (bpmList.Count == 1)
        {
            return (float)beat * 60 / bpmList[0].bpm;
        }
        for (int i = 0; i < bpmList.Count; i++)
        {

            float time = 0;

            if (beat >= bpmBeat(i))
            {
                return addTime(beat, time, i);
            }
        }
        return 0;

    }

    public float addTime(float beat,float time,int i)
    {
        for (int m = 0; m < i; m++)
        {
            time += (bpmBeat(m + 1) - bpmBeat(m)) * (float)60 / bpmList[m].bpm;
        }
        time += (beat - bpmBeat(i)) * (float)60 / bpmList[i].bpm;
        return time;
    }

    public float bpmBeat(int x)
    {
        return bpmList[x].startTime[0] + (float)bpmList[x].startTime[1] / bpmList[x].startTime[2];
    }

    public List<SpeedEvent> speedEvent;
    public float noteYpos(int m,float t)
    {
        speedEvent = chart.judgeLineList[m].eventLayers[0].speedEvents;
        int index = speedIndex[m];

        float posy = 0;//y坐标

        for (int i = index; i < speedEvent.Count; i++)
        {
            float startTime = speedEvent[i].st;//事件开始时间
            float _startTime = startTime;

            float endTime = speedEvent[i].et;//事件结束时间
            float _endTime = endTime;

            float startSpeed = speedEvent[i].start;//事件开始速度
            float endSpeed = speedEvent[i].end;//事件结束速度

            float noteTime = t;//note开始时间

            float edTime = speedEvent[index].et;

            if (Updater.Instance.realTime > edTime && speedEvent[index].condition != "done")
            {
                speedEvent[index].condition = "done";
                if (index < speedEvent.Count - 1) speedIndex[m]++;
            }

            if (Updater.Instance.realTime < endTime)
            {
                if (Updater.Instance.realTime > startTime)
                {
                    startTime = Updater.Instance.realTime;
                    startSpeed = (float)Mathf.Lerp(startSpeed, endSpeed, (Updater.Instance.realTime - _startTime) / (_endTime - _startTime));
                }
                if (endTime > noteTime)
                {
                    endSpeed = (float)Mathf.Lerp(startSpeed, endSpeed, (noteTime - _startTime) / (_endTime - _startTime));
                    endTime = noteTime;
                }
                if (startTime > noteTime)
                {
                    return posy;
                }
                posy += (startSpeed + endSpeed) * (float)(endTime - startTime) / 2;
            }

        }
        return posy;
    }

    

    // public static float NoteYpos(int m, int[] t)
    // {
    //     SpeedEvent[] speedEvent = chart.judgeLineList[m].eventLayers[0].speedEvents;
    //     Note[] note = chart.judgeLineList[m].notes;

    //     float posY = 0;

    //     for (int i = 0; i < speedEvent.Count; i++)
    //     {
    //         float startTime = bpmTime(speedEvent[i].startTime);
    //         float endTime = bpmTime(speedEvent[i].endTime);
    //         float startSpeed = speedEvent[i].start;
    //         float endSpeed = speedEvent[i].end;
    //         float noteTime = bpmTime(t);

    //         if (gameTime < endTime)
    //         {
    //             startTime = Mathf.Max(0, Mathf.Min(gameTime, startTime));
    //             endTime = Mathf.Min(gameTime, endTime);
    //             startSpeed = Mathf.Lerp(startSpeed, endSpeed, (gameTime - startTime) / (endTime - startTime));
    //             endSpeed = Mathf.Lerp(startSpeed, endSpeed, (noteTime - startTime) / (endTime - startTime));
    //             posY += (startSpeed + endSpeed) * (endTime - startTime) / 2;
    //         }
    //     }
    //     return posY;
    // }


    
}
