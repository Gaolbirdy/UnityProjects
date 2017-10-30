using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour 
{
    static public FollowCam S; // FollowCam的单例对象

    // 在Unity检视面板中设置的字段
    public float easing = 0.05f;
    public bool __________________;

    // 动态设置的字段
    public GameObject poi; // 兴趣点(poi)
    public float camZ; // 摄像机的Z坐标

    private void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }

    private void Update()
    {
        if (poi == null)
            return; // 如果兴趣点不存在，则返回

        // 获取兴趣点的位置
        Vector3 destination = poi.transform.position;
        // 在摄像机当前位置和目标位置之间增添插值
        destination = Vector3.Lerp(transform.position, destination, easing);
        // 保持destination.z的值为camZ
        destination.z = camZ;
        // 将摄像机位置设置到destination
        transform.position = destination;
    }
}
