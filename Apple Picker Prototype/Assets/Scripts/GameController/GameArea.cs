using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea
 {
    // 底部，游戏对象掉落出去就会销毁自身
    public static float bottomY = -20f;

    // 宽度，苹果树的活动区域，到达边界时则改变方向
    public static float leftAndRightEdge = 10f;
}
