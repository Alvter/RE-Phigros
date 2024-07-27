using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class easingFunction : MonoBehaviour
{
    public UnityEvent myevent;
    public static float Curve(int id, float x)
    {
        return id switch
        {
            1 => LineX(x),
            2 => OutSine(x),
            3 => InSine(x),
            4 => OutQuad(x),
            5 => InQuad(x),
            6 => InOutSine(x),
            7 => InOutQuad(x),
            8 => OutCubic(x),
            9 => InCubic(x),
            10 => OutQuart(x),
            11 => InQuart(x),
            12 => InOutCubic(x),
            13 => InOutQuart(x),
            14 => OutQuint(x),
            15 => InQuint(x),
            16 => OutExpo(x),
            17 => InExpo(x),
            18 => OutCirc(x),
            19 => InCirc(x),
            20 => OutBack(x),
            21 => InBack(x),
            22 => InOutCirc(x),
            23 => InOutBack(x),
            24 => OutElastic(x),
            25 => InElastic(x),
            26 => OutBounce(x),
            27 => InBounce(x),
            28 => InOutBounce(x),
            29 => InOutElastic(x),
            _ => x,// 默认情况下返回 x
        };
    }

    public static float LineX(float x)
    {
        return x;
    }

    public static float OutSine(float x)
    {
        return (float)Math.Sin((x * Math.PI) / 2);
    }

    public static float InSine(float x)
    {
        return 1 - (float)Math.Cos((x * Math.PI) / 2);
    }

    public static float OutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }

    public static float InQuad(float x)
    {
        return x * x;
    }

    public static float InOutSine(float x)
    {
        return -(float)(Math.Cos(Math.PI * x) - 1) / 2;
    }

    public static float InOutQuad(float x)
    {
        if (x < 0.5f)
        {
            return 2 * x * x;
        }
        else
        {
            return 1 - (float)Math.Pow(-2 * x + 2, 2) / 2;
        }
    }

    public static float OutCubic(float x)
    {
        return 1 - (float)Math.Pow(1 - x, 3);
    }

    public static float InCubic(float x)
    {
        return (float)Math.Pow(x, 3);
    }

    public static float OutQuart(float x)
    {
        return 1 - (float)Math.Pow(1 - x, 4);
    }

    public static float InQuart(float x)
    {
        return (float)Math.Pow(x, 4);
    }

    public static float InOutCubic(float x)
    {
        if (x < 0.5f)
        {
            return 4 * (float)Math.Pow(x, 3);
        }
        else
        {
            return 1 - (float)Math.Pow(-2 * x + 2, 3) / 2;
        }
    }

    public static float InOutQuart(float x)
    {
        if (x < 0.5f)
        {
            return 8 * (float)Math.Pow(x, 4);
        }
        else
        {
            return 1 - (float)Math.Pow(-2 * x + 2, 4) / 2;
        }
    }

    public static float OutQuint(float x)
    {
        return 1 - (float)Math.Pow(1 - x, 5);
    }

    public static float InQuint(float x)
    {
        return (float)Math.Pow(x, 5);
    }

    public static float OutExpo(float x)
    {
        if (x == 1)
        {
            return 1;
        }
        else
        {
            return 1 - (float)Math.Pow(2, -10 * x);
        }
    }

    public static float InExpo(float x)
    {
        if (x == 0)
        {
            return 0;
        }
        else
        {
            return (float)Math.Pow(2, 10 * x - 10);
        }
    }

    public static float OutCirc(float x)
    {
        return (float)Math.Sqrt(1 - Math.Pow(x - 1, 2));
    }

    public static float InCirc(float x)
    {
        return 1 - (float)Math.Sqrt(1 - Math.Pow(x, 2));
    }

    public static float OutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * (float)Math.Pow(x - 1, 3) + c1 * (float)Math.Pow(x - 1, 2);
    }

    public static float InBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return c3 * x * x * x - c1 * x * x;
    }

    public static float InOutCirc(float x)
    {
        if (x < 0.5f)
        {
            return (1 - (float)Math.Sqrt(1 - Math.Pow(2 * x, 2))) / 2;
        }
        else
        {
            return ((float)Math.Sqrt(1 - Math.Pow(-2 * x + 2, 2)) + 1) / 2;
        }
    }

    public static float InOutBack(float x)
    {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;

        if (x < 0.5f)
        {
            return (float)(Math.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2;
        }
        else
        {
            return (float)(Math.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }
    }

    public static float OutElastic(float x)
    {
        float c4 = (2 * (float)Math.PI) / 3;

        if (x == 0)
        {
            return 0;
        }
        else if (x == 1)
        {
            return 1;
        }
        else
        {
            return (float)(Math.Pow(2, -10 * x) * Math.Sin((x * 10 - 0.75) * c4) + 1);
        }
    }

    public static float InElastic(float x)
    {
        float c4 = (2 * (float)Math.PI) / 3;

        if (x == 0)
        {
            return 0;
        }
        else if (x == 1)
        {
            return 1;
        }
        else
        {
            return (float)(-Math.Pow(2, 10 * x - 10) * Math.Sin((x * 10 - 10.75) * c4));
        }
    }

    public static float OutBounce(float x)
    {
        float n1 = 7.5625f;
        float d1 = 2.75f;

        if (x < 1 / d1)
        {
            return n1 * x * x;
        }
        else if (x < 2 / d1)
        {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        else if (x < 2.5 / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        else
        {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }

    public static float InBounce(float x)
    {
        return 1 - OutBounce(1 - x);
    }

    public static float InOutBounce(float x)
    {
        if (x < 0.5f)
        {
            return (1 - OutBounce(1 - 2 * x)) / 2;
        }
        else
        {
            return (1 + OutBounce(2 * x - 1)) / 2;
        }
    }

    public static float InOutElastic(float x)
    {
        float c5 = (2 * (float)Math.PI) / 4.5f;

        if (x == 0)
        {
            return 0;
        }
        else if (x == 1)
        {
            return 1;
        }
        else if (x < 0.5f)
        {
            return -(float)(Math.Pow(2, 20 * x - 10) * Math.Sin((20 * x - 11.125) * c5)) / 2;
        }
        else
        {
            return (float)(Math.Pow(2, -20 * x + 10) * Math.Sin((20 * x - 11.125) * c5)) / 2 + 1;
        }
    }
}
