﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;


    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh; //<---- setting mesh variable to be the mesh filter on the game object

        CreateShape();
        UpdateMesh();
    }

    void Update()
    {

    }



    private void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)]; //<---- Calculating the amount of vertices based on the size of the mesh
        
        for(int i = 0, z = 0; z <= zSize; z++) //<----- putting the vertices in the scene
        {
            for (int x = 0; x <= zSize; x++) 
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }


        triangles = new int[6];
        triangles[0] = 0;
        triangles[1] = xSize + 1;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = xSize + 1;
        triangles[5] = xSize + 2;
    }

    private void UpdateMesh() //<-------- put in update for audio visualizer
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) //<-----if there are no vertices dont run the code
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f); //<---- Display the vertices in the scene view as small spheres
        }
    }
}