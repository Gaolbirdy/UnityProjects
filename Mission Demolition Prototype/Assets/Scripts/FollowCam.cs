using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour 
{
    static public FollowCam S; // FollowCam的单例对象

    // 在Unity检视面板中设置的字段
    public float easing = 0.05f;
    public Vector2 minXY;
    public bool __________________;

    // 动态设置的字段
    public GameObject poi; // 兴趣点(poi)
    public float camZ; // 摄像机的Z坐标

    private float cameraMinSize;

    private void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
        cameraMinSize = this.GetComponent<Camera>().orthographicSize;
    }

    private void FixedUpdate()
    {
        Vector3 destination;
        // 如果兴趣点不存在，返回到P:[0,0,0]
        if (poi == null)
        {
            destination = Vector3.zero;
            //return;
        }
        else
        {
            // 获取兴趣点的位置
            destination = poi.transform.position;
            // 如果兴趣点是一个Projectile实例，检查它是否已经静止
            if (poi.tag == "Projectile")
            {
                // 如果它处于sleeping状态（即未移动）
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {
                    // 返回到默认视图
                    poi = null;
                    // 在下一次更新时
                    return;
                }
            }
        }
        // 限定x和y的最小值
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        // 在摄像机当前位置和目标位置之间增添插值，最终两个位置会相同而摄像机停止运动
        destination = Vector3.Lerp(transform.position, destination, easing);
        // 保持destination.z的值为camZ
        destination.z = camZ;
        // 将摄像机位置设置到destination
        transform.position = destination;
        // 设置摄像机的orthographicSize，使地面始终处于画面之中，当destination.y大于0以后
        this.GetComponent<Camera>().orthographicSize = destination.y + cameraMinSize;
    }
}
