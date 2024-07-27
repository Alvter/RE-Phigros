using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

[System.Serializable]
    public class BPMData
    {
        public float bpm;
        public int[] startTime;
    }

    [System.Serializable]
    public class AlphaControl
    {
        public float alpha;
        public int easing;
        public float x;
    }

    [System.Serializable]
    public class EventLayer
    {
        public List<AlphaEvent> alphaEvents;
        public List<MoveXEvent> moveXEvents;
        public List<MoveYEvent> moveYEvents;
        public List<RotateEvent> rotateEvents;
        public List<SpeedEvent> speedEvents;
        public float alpha = 0;
        public float posx = 0;
        public float posy = 0;
        public float rotate = 0;
    }

    [System.Serializable]
    public class Extended
    {
        public List<ScaleXEvents> scaleXEvents;
        public List<ScaleYEvents> scaleYEvents;
        public List<InclineEvents> inclineEvents;
        public List<TextEvents> textEvents;
        public List<ColorEvents> colorEvents;
    }

    [System.Serializable]
    public class AlphaEvent
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class MoveXEvent
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class MoveYEvent
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class RotateEvent
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class SpeedEvent
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class InclineEvents
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class ScaleXEvents
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class ScaleYEvents
    {
        public int easingType;
        public float end;
        public int[] endTime;
        public int linkgroup;
        public float start;
        public int[] startTime;
        public string condition = "undo";
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class TextEvents
    {
        public int easingType;
        public string end;
        public int[] endTime;
        public int linkgroup;
        public string start;
        public int[] startTime;
        public string condition = "undo";
        public string font;
        public float st;
        public float et;
        public float set;
        public float se;
    }

    [System.Serializable]
    public class ColorEvents
    {
        public int easingType;
        public float[] end;
        public int[] endTime;
        public int linkgroup;
        public float[] start;
        public int[] startTime;
        public string condition = "undo";
        public string font;
        public float st;
        public float et;
        public float set;
        public float[] se = new float[3] { 255f ,255f, 255f};
    }

    [System.Serializable]
    public class JudgeLine
    {
        public int Group;
        public string Name;
        public string Texture;
        public List<AlphaControl> alphaControl;
        public float bpmfactor;
        public List<EventLayer> eventLayers;
        public List<Note> notes;
        public Extended extended;
        public int father;
        public float alpha = 0;
        public float posx = 0;
        public float posy = 0;
        public float speed = 0;
        public float rotate = 0;
        public float incline = 0;
        public float objScaleX;
        public float objScaleY;
        public float scaleX = 1;
        public float scaleY = 1;
        public string text;
        public float[] color = new float[3] { 254f, 255f, 169f };
    }

    [System.Serializable]
    public class Note
    {
        public int above;
        public float alpha;
        public int[] endTime;
        public int isFake;
        public float positionX;
        public float size;
        public float speed;
        public int[] startTime;
        public int type;
        public float visibleTime;
        public float yOffset;
        public bool isPlay = false;
        public bool isPlayAudio = false;
        public float st;
        public float et;
        public float set;
        public bool isAdd = false;
    }

    [System.Serializable]
    public class METAData
    {
        public int RPEVersion;
        public string background;
        public string charter;
        public string composer;
        public string id;
        public string level;
        public string name;
        public int offset;
        public string song;
    }

    [System.Serializable]
    public class Chart
    {
        public List<BPMData> BPMList;
        public METAData META;
        public string[] judgeLineGroup;
        public List<JudgeLine> judgeLineList;
        public string multiLineString;
        public float multiScale;
    }

public class LoadChart : MonoBehaviour
{
    // 实例化
    private static LoadChart _instance;
    public static LoadChart Instance { get { return _instance; } }


    public  string chartName = "arc";
    public Chart chart;
    public TextAsset textAsset;
    public string json;
    public UnityEvent ChartLoadOver;
    public bool isOver = false;

    async void Awake()
    {
        _instance = this;

        Application.targetFrameRate = 250;
        // 使应用程序在后台运行
        Application.runInBackground = true;

        await Load();
    }

    async UniTask Load()
    {
        textAsset = Resources.Load<TextAsset>("Chart/" + chartName + "/chart");
        json = textAsset.text;
        chart = JsonConvert.DeserializeObject<Chart>(json);
        await UniTask.WaitUntil(() => chart != null);

        LoadEvent.Instance.Init(chart);
        Function.Instance.Init(chart);
        ReLoadChart.Instance.Init(chart);

        GameController.Instance.ScriptStart();
    }

}
