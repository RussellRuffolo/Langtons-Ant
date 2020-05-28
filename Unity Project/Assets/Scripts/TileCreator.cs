using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

//Tile creator is used to create and render a tile mesh centered on its parent GameObject
public class TileCreator : MonoBehaviour
{
    //List of the mesh's vertices
    private static List<Vector3> _tileVertices = new List<Vector3>
    {
        new Vector3 (.5f, 0, -.5f),
        new Vector3 (-.5f, 0, -.5f),
        new Vector3 (-.5f, 0, .5f),
        new Vector3 (.5f, 0, .5f)
    };

    //List of the order the vertices are connected in to form the triangles of the mesh
    private static List<int> _tileTriangles = new List<int>
    {
        0,1,2,
        0,2,3
    };

    //List of the normal vector of each vertice. The tiles sit in the xz plane so their normals are positive y
    private static List<Vector3> _faceNormals = new List<Vector3>
    {
        Vector3.up,Vector3.up,Vector3.up,
        Vector3.up
    };

    //List of uv's (texture coordinates) for each vertice. 
    private static List<Vector2> _uvList = new List<Vector2>
    {
        new Vector2(0, 0),
        new Vector2(1, 0),
        new Vector2(1, 1),
        new Vector2(0, 1)
    };
 

    // Start is called before the first frame update
    private void Start()
    {
        //The mesh filter we will apply our mesh to
        var mFilter = GetComponent<MeshFilter>();    

        //The mesh we are creating
        var mesh = new Mesh();

        //Here we set all the aspects of the mesh to create a 1x1 textured tile
        mesh.subMeshCount = 1;
        mesh.SetVertices(_tileVertices);      
        mesh.SetTriangles(_tileTriangles, 0);        
        mesh.SetNormals(_faceNormals);
        mesh.SetUVs(0, _uvList);

        //Apply the mesh to our mesh filter
        mFilter.mesh = mesh;
    }


    
}
