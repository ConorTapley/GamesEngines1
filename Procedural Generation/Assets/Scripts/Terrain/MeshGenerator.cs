using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    public AudioPeer audioInput;
    public float audioScale = 2f;

    Vector3[] vertices; //<--the points evenly spaces throughout the grid
    int[] triangles; //<-----the triangles that make up the grid
    //Vector2[] uvs; //<--------makes points to map textures

    public float noise = 0.3f;
    public float noise2 = 2f;

    Color[] colours; 
    public Gradient gradient;

    public int xSize = 20;
    public int zSize = 20;

    public int textureWidth = 1024;
    public int textureHeight = 1024;

    public float noise01Scale = 2f;
    public float noise01Amp = 2f;

    public float noise02Scale = 4f;
    public float noise02Amp = 4f;

    public float noise03Scale = 6f;
    public float noise03Amp = 6f;

    [SerializeField]
    private float minTerrainHeight;
    [SerializeField]
    private float maxTerrainHeight;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh; //<---- setting mesh variable to be the mesh filter on the game object

        CreateShape();
    }

    void Update()
    {
        CreateShape();
        UpdateMesh();
    }



    private void CreateShape()
    {

        vertices = new Vector3[(xSize + 1) * (zSize + 1)]; //<---- Calculating the amount of vertices based on the size of the mesh
        
        for(int i = 0, z = 0; z <= zSize; z++) //<----- putting the vertices in the scene
        {
            for (int x = 0; x <= zSize; x++) 
            {
                //float y = GetNoiseSample(x, z);
                //float y = Mathf.PerlinNoise(x * noise, z * noise) * noise2; //<------------------------------------------------------------------------------PUT VISUALIZER HERE!!! ------------- y = height
                float y = AudioPeer.samples[i] * audioScale;
                vertices[i] = new Vector3(x, y, z); //<---------y = height of the vertices

                if (y > maxTerrainHeight)
                    maxTerrainHeight = y; //<-----------always calculating the maximum terrain height

                if (y < minTerrainHeight)
                    minTerrainHeight = y; //<-----------always calculating the minimum terrain height

                i++;
            }
        }




        triangles = new int[xSize * zSize * 6];
        int vert = 0; //vertices
        int tris = 0; //triangles

        for (int z = 0; z < zSize; z++)//<--------- Creating the triangles
        {
            for (int x = 0; x < xSize; x++) 
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }


        //uvs = new Vector2[vertices.Length]; //<------make this array the same size of the vertices array
        colours = new Color[vertices.Length]; //<------make this array the same size of the vertices array
        for (int i = 0, z = 0; z <= zSize; z++) //<----- putting the vertices in the scene
        {
            for (int x = 0; x <= zSize; x++)
            {
                //uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);

                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);  //<---------calculate the height off the vetice using an inverse lerp to give a value between 0 and 1
                colours[i] = gradient.Evaluate(height); //<---------use a gradient to determine the colour based on the height of the vertice
                i++;
            }
        }
    }







    private void UpdateMesh() //<-------- put in update for audio visualizer
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.uv = uvs;
        mesh.colors = colours;

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
