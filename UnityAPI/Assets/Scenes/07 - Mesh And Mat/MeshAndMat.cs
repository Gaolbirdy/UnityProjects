using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAndMat : MonoBehaviour 
{
    public Mesh mesh;

    private Material mat;

    private void Start()
    {
        //GetComponent<MeshFilter>().mesh = mesh;
        //GetComponent<MeshFilter>().sharedMesh = mesh;
        //Debug.Log(GetComponent<MeshFilter>().sharedMesh == mesh);

        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        mat.color = Color.Lerp(mat.color, Color.red, Time.deltaTime);
    }
}
