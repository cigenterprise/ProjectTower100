using System;
using System.Collections.Generic;
using UnityEngine;

public static class DIRECTION
{
    public static Vector2 LEFT_VEC2 = new Vector2( -1, 0 );
    public static Vector2 TOP_VEC2 = new Vector2( 0, 1 );
    public static Vector2 RIGHT_VEC2 = new Vector2( 1, 0 );
    public static Vector2 BOTTOM_VEC2 = new Vector2( 0, -1 );

    public const int LEFT = 0;
    public const int TOP = 1;
    public const int RIGHT = 2;
    public const int BOTTOM = 3;
    public const int LTRB_INDEX_MAX = 4;
}

public static class LAYERZ
{
    public const float FLOOR = 0.0f;
    public const float ACTOR = -0.1f;
}