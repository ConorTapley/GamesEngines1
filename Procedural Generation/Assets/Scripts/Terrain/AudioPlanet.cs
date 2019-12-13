using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlanet : MonoBehaviour
{
    Mesh mesh;

    public NewColourSettings colourSettings;

    [Range(2, 256)]
    public int resolution = 10;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    AudioTFace[] terrainFaces;
    public float intensity = 2f;
    public float audioStartSize = 2f;
    public float audioScale = 2f;


    Vector3[] vertices; //<--the points evenly spaces throughout the grid
    int[] triangles; //<-----the triangles that make up the grid
    //Vector2[] uvs; //<--------makes points to map textures
    

    Color[] colours;
    public Gradient gradient;

    public int meshSize = 20;
    private int xSize;
    private int zSize;

    [SerializeField]
    private float minTerrainHeight = 0f;
    [SerializeField]
    private float maxTerrainHeight = 5.2f;

    
    private void OnValidate()
    {
        Initialize();
        GenerateMesh();
        GenerateColours();
    }


    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh; //<---- setting mesh variable to be the mesh filter on the game object
        xSize = meshSize;
        zSize = meshSize;
    }

    void Update()
    {
        GenerateMesh();
        GenerateColours();
    }

    void Initialize()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new AudioTFace[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colourSettings.planetMaterial;

            terrainFaces[i] = new AudioTFace(meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void GenerateMesh()
    {
        foreach (AudioTFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    void GenerateColours()
    {
        foreach (MeshFilter m in meshFilters)
        {
            m.GetComponent<MeshRenderer>().sharedMaterial.color = colourSettings.planetColour; //change the colour of the planet
        }
    }

    public void OnColourSettingsUpdated()
    {
        Initialize();
        GenerateColours();
    }
}
