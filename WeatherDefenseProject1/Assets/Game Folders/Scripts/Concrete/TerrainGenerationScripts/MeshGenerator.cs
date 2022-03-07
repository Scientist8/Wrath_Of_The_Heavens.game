using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh _mesh;
    Renderer _renderer;

    Vector3[] _vertices;
    int[] _triangles;

    public int _xSize = 20;
    public int _zSize = 20;

    public float _yHeight = 2f;

    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

        //StartCoroutine(CreateShape());
        CreateShape();

    }

    void Update()
    {
        UpdateMesh();
    }

    void CreateShape()
    {

        _vertices = new Vector3[(_xSize + 1) * (_zSize + 1)];

        for (int i = 0, z = 0; z <= _zSize; z++)
        {
            for (int x = 0; x <= _xSize; x++)
            {
                //Applying perlin noise, making heights
                float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * _yHeight;
                _vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        //Drawing the triangles
        _triangles = new int[_xSize * _zSize * 6];

        int vert = 0;
        int trias = 0;

        for (int z = 0; z < _zSize; z++)
        {
            for (int x = 0; x < _xSize; x++)
            {
                _triangles[trias + 0] = vert + 0;
                _triangles[trias + 1] = vert + _xSize + 1;
                _triangles[trias + 2] = vert + 1;
                _triangles[trias + 3] = vert + 1;
                _triangles[trias + 4] = vert + _xSize + 1;
                _triangles[trias + 5] = vert + _xSize + 2;

                vert++;
                trias += 6;


                //yield return new WaitForSeconds(0.01f);
            }
            vert++; //Becuase the triangles are connecting each other in a weird way
        }
        

    }

    void UpdateMesh()
    {
        _mesh.Clear();

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;

        _mesh.RecalculateNormals(); //For lighting purposes
    }

    private void OnDrawGizmos()
    {
        if (_vertices == null)
            return;

        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i], 0.1f);
        }
    }
}
