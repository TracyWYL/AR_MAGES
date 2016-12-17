using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AndroidUtils
{
    public static Quaternion AndroidAltQuatMult()
    {
        Quaternion quatMult = Quaternion.identity;

        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            quatMult = new Quaternion(0f, 0f, 0.7071f, -0.7071f);
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            quatMult = new Quaternion(0f, 0f, -0.7071f, -0.7071f);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            quatMult = new Quaternion(0f, 0f, 0f, 1f);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            quatMult = new Quaternion(0f, 0f, 1f, 0f);
        }

        return (quatMult);
    }
}
