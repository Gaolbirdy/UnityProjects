using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour 
{
    static public ProjectileLine S; // 单例对象
    // 在Unity检视面板中设置的字段
    public float minDist = 0.1f;
    public bool _____________________;

    // 在代码中动态设置的字段
    public LineRenderer line;
    public List<Vector3> points;    // = new List<Vector3>();

    private GameObject _poi;

    private void Awake()
    {
        S = this;   // 设置单例对象
        // 获取对线渲染器的引用
        line = GetComponent<LineRenderer>();
        // 在需要使用LineRenderer之前，将其禁用
        line.enabled = false;
        // 初始化三维向量点的List
        points = new List<Vector3>();
    }

    // 这是一个属性，即伪装成字段的方法
    public GameObject poi
    {
        get
        {
            return (_poi);
        }
        set
        {
            _poi = value;
            if (_poi != null)
            {
                // 当把_poi设置为新对象时，将复位其所有内容
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint(); // 没必要？
            }
        }
    }

    // 这个函数用于直接清除线条
    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        // 用于在线条上添加一个点
        Vector3 pt = _poi.transform.position;   // 兴趣点当前的位置

        if (points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            // 如果该点与上一个点的位置不够远，则返回
            return;
        }
        if (points.Count == 0)
        {
            // 如果当前是发射点
            Vector3 launchPos = SlingShot.S.launchPoint.transform.position; // 发射点位置
            Vector3 launchPosDiff = pt - launchPos; // 发射点离兴趣点的距离(可以视为pt相对于launchPos的位置坐标)
            //Debug.DrawLine(pt, launchPos);
            //Debug.Break();
            // ……则增加一根线条，帮助之后瞄准
            points.Add(pt + launchPosDiff); // 第0个点 在pt拉弓方向的后侧
            points.Add(pt); // 第1个点
            line.positionCount = 2;
            // 设置前两个点
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            // 启用线渲染器
            line.enabled = true;
        }
        else
        {
            // 正常加点的操作
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }
    }

    public Vector3 lastPoint
    {
        get
        {
            if(points == null)
            {
                // 如果当前还没有点，返回Vector3.zero
                return (Vector3.zero);
            }
            return (points[points.Count - 1]);
        }
    }

    private void FixedUpdate()
    {
        if (poi == null)
        {
            // 如果兴趣点不存在，则找出一个
            if (FollowCam.S.poi != null)
            {
                if (FollowCam.S.poi.tag == "Projectile")
                {
                    poi = FollowCam.S.poi;
                }
                else
                {
                    return; // 如果未找到兴趣的，则返回
                }
            }
            else
            {
                return; // 如果未找到兴趣的，则返回
            }
        }
        // 如果存在兴趣点，则在FixedUpdate中在其位置上增加一个点
        AddPoint();
        if (poi.GetComponent<Rigidbody>().IsSleeping())
        {
            // 当兴趣点静止时，将其清空（设置为null)
            poi = null;
        }
    }
}
