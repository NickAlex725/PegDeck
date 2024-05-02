using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General
{
    public static Color GetModifiedAlpha(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }
}
