using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class TileCreator : MonoBehaviour
{

    private Vector3[] _tileVertices = new[]
    {
        new Vector3 (.5f, 0, -.5f),
        new Vector3 (-.5f, 0, -.5f),
        new Vector3 (-.5f, 0, .5f),
        new Vector3 (.5f, 0, .5f),
    };

    private int[] _tileTriangles = new[]
    {
        0,1,2,
        0,2,3
    };

    private static Vector3[] _faceNormals = new[]
    {
        Vector3.up,Vector3.up,Vector3.up,
        Vector3.up
    };


    MeshFilter mFilter;
    MeshRenderer mRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        mFilter = GetComponent<MeshFilter>();
        mRenderer = GetComponent<MeshRenderer>();

        var vertices = new List<Vector3>();

        var normals = new List<Vector3>();

        var uvList = new List<Vector3>();

        var triangleList = new List<int>();

 

        foreach (var vert in _tileVertices)
            vertices.Add(vert);

        uvList.Add(new Vector2(0, 0));
        uvList.Add(new Vector2(1, 0));

        uvList.Add(new Vector2(1, 1));
        uvList.Add(new Vector2(0, 1));

        foreach (var normal in _faceNormals)
            normals.Add(normal);

        foreach (var tri in _tileTriangles)
            triangleList.Add(tri);

        var mesh = new Mesh();
        mesh.subMeshCount = 1;
        mesh.SetVertices(vertices);
      
        mesh.SetTriangles(triangleList, 0);
        
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvList);
        mFilter.mesh = mesh;
    }


    
}
