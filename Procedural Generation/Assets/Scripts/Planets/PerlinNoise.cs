using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;  //<----- Pixel Width of the object
    public int height = 256; //<----- Pixel Height of the object

    public float scale = 20f;
    public float offsetX = 100f; //<-------------you can scroll trough the texture using theses offsets
    public float offsetY = 100f; //<-------------use for procedurally generating terrain

    void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f); //<------------Randomises the texture exerytime you start the game;
    }

    void Update()
    {
        offsetX = Random.Range(0f, 99999f) * Time.deltaTime;
        offsetY = Random.Range(0f, 99999f) * Time.deltaTime; //<----------Randomises the texture exery second of the game

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenrateTexture();
    }

    Texture2D GenrateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        //generate a perlin noise map for the texture
        for(int x = 0; x < width; x++) //<----------------for loop for the x axis
        {
            for(int y = 0; y < height; y++) //<-----------nested for loop for the y axis, this will cover the whole object
            {
                Color colour = CalculateColour(x, y); //<----------generating a random colour between black and white for each pixel
                texture.SetPixel(x, y, colour);
            }
        }
        texture.Apply(); //<----------------applying the texture to the object
        return texture;
    }

    Color CalculateColour(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX; //<------------ scale determines how zoomed into the texure you are
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord); //<-------generating a colour value using perlin noise, 0 = black, 1 = white etc.
        return new Color(sample, sample, sample); //<---------------RGB are all equal to the generated colour value
    }
}
