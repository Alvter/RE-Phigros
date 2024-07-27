using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class ReLoadChart : MonoBehaviour
{
    // 实例化
    private static ReLoadChart _instance;
    public static ReLoadChart Instance { get { return _instance; } }

    public bool isStart = false;
    public bool isOver = false;
    public UnityEvent ChartReLoadOver;

    public static List<List<Note>> noteList = new();

    public void Awake()
    {
        _instance = this;
    }

    public void Init(Chart chart)
    {
        for (int i = 0; i < chart.judgeLineList.Count; i++)
        {
            noteList.Add(new List<Note>());
        }

        //常规事件
        for (int i = 0; i < chart.judgeLineList.Count; i++)
        {
            for (int m = 0; m < chart.judgeLineList[i].eventLayers.Count; m++)
            {
                //alpha
                if (chart.judgeLineList[i].eventLayers[m].alphaEvents != null)
                {
                    for (int k = 0; k < chart.judgeLineList[i].eventLayers[m].alphaEvents.Count; k++)
                    {
                        var events = chart.judgeLineList[i].eventLayers[m].alphaEvents[k];

                        events.st = Function.Instance.bpmTime(events.startTime);
                        events.et = Function.Instance.bpmTime(events.endTime);
                        events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                        events.se = events.end - events.start;
                    }
                }

                //moveX
                if (chart.judgeLineList[i].eventLayers[m].moveXEvents != null)
                {
                    for (int k = 0; k < chart.judgeLineList[i].eventLayers[m].moveXEvents.Count; k++)
                    {
                        var events = chart.judgeLineList[i].eventLayers[m].moveXEvents[k];

                        events.st = Function.Instance.bpmTime(events.startTime);
                        events.et = Function.Instance.bpmTime(events.endTime);
                        events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                        events.se = events.end - events.start;
                    }
                }


                //moveY
                if (chart.judgeLineList[i].eventLayers[m].moveYEvents != null)
                {
                    for (int k = 0; k < chart.judgeLineList[i].eventLayers[m].moveYEvents.Count; k++)
                    {
                        var events = chart.judgeLineList[i].eventLayers[m].moveYEvents[k];

                        events.st = Function.Instance.bpmTime(events.startTime);
                        events.et = Function.Instance.bpmTime(events.endTime);
                        events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                        events.se = events.end - events.start;
                    }
                }

                //rotate
                if (chart.judgeLineList[i].eventLayers[m].rotateEvents != null)
                {
                    for (int k = 0; k < chart.judgeLineList[i].eventLayers[m].rotateEvents.Count; k++)
                    {
                        var events = chart.judgeLineList[i].eventLayers[m].rotateEvents[k];

                        events.st = Function.Instance.bpmTime(events.startTime);
                        events.et = Function.Instance.bpmTime(events.endTime);
                        events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                        events.se = events.end - events.start;
                    }
                }

                //speed
                if (chart.judgeLineList[i].eventLayers[m].speedEvents != null)
                {
                    for (int k = 0; k < chart.judgeLineList[i].eventLayers[m].speedEvents.Count; k++)
                    {
                        var events = chart.judgeLineList[i].eventLayers[m].speedEvents[k];

                        events.st = Function.Instance.bpmTime(events.startTime);
                        events.et = Function.Instance.bpmTime(events.endTime);
                        events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                        events.se = events.end - events.start;
                    }
                }
            }
        }

        for (int i = 0; i < chart.judgeLineList.Count; i++)
        {
            //sacleX
            if (chart.judgeLineList[i].extended.scaleXEvents != null)
            {
                for (int m = 0; m < chart.judgeLineList[i].extended.scaleXEvents.Count; m++)
                {
                    var events = chart.judgeLineList[i].extended.scaleXEvents[m];

                    events.st = Function.Instance.bpmTime(events.startTime);
                    events.et = Function.Instance.bpmTime(events.endTime);
                    events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                    events.se = events.end - events.start;
                }
            }

            //scaleY
            if (chart.judgeLineList[i].extended.scaleYEvents != null)
            {
                for (int m = 0; m < chart.judgeLineList[i].extended.scaleYEvents.Count; m++)
                {
                    var events = chart.judgeLineList[i].extended.scaleYEvents[m];

                    events.st = Function.Instance.bpmTime(events.startTime);
                    events.et = Function.Instance.bpmTime(events.endTime);
                    events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                    events.se = events.end - events.start;
                }
            }

            //color
            if (chart.judgeLineList[i].extended.colorEvents != null)
            {
                for (int m = 0; m < chart.judgeLineList[i].extended.colorEvents.Count; m++)
                {
                    var events = chart.judgeLineList[i].extended.colorEvents[m];

                    events.st = Function.Instance.bpmTime(events.startTime);
                    events.et = Function.Instance.bpmTime(events.endTime);
                    events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                    for (int c = 0; c < 3; c++)
                    {
                        events.se[c] = events.end[c] - events.start[c];
                    }
                }
            }

            //text
            if (chart.judgeLineList[i].extended.textEvents != null)
            {
                for (int m = 0; m < chart.judgeLineList[i].extended.textEvents.Count; m++)
                {
                    var events = chart.judgeLineList[i].extended.textEvents[m];

                    events.st = Function.Instance.bpmTime(events.startTime);
                    events.et = Function.Instance.bpmTime(events.endTime);
                    events.set = Function.Instance.bpmTime(events.endTime) - Function.Instance.bpmTime(events.startTime);
                }
            }
        }

        for (int i = 0; i < chart.judgeLineList.Count; i++)
        {
            if (chart.judgeLineList[i].notes == null) continue;
            for (int m = 0; m < chart.judgeLineList[i].notes.Count; m++)
            {
                var note = chart.judgeLineList[i].notes[m];

                note.st = Function.Instance.bpmTime(note.startTime);
                note.et = Function.Instance.bpmTime(note.endTime);
                note.set = Function.Instance.bpmTime(note.endTime) - Function.Instance.bpmTime(note.startTime);
                note.above = (note.above == 1) ? 1 : -1;
            }
        }

        for (int i = 0; i < noteList.Count; i++)
        {
            if (chart.judgeLineList[i].notes == null) continue;

            noteList[i] = chart.judgeLineList[i].notes.ToList();
            noteList[i].Sort((note1, note2) => note1.st.CompareTo(note2.st));
            chart.judgeLineList[i].notes = noteList[i];
        }
    }
}
