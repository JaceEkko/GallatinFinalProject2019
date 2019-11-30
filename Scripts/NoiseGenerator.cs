using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    private int octaves; // can also be called layers. Increasing this increases the detail in the terrain
    private float lacunarity;
    private float gain;
    private float perlinScale;

    //public NoiseGenerator() { }

    public NoiseGenerator(int octaves, float lacunarity, float gain, float perlinScale)
    {
        this.octaves = octaves;
        this.lacunarity = lacunarity;
        this.gain = gain;
        this.perlinScale = perlinScale;
    }

    public float GetValueNoise()
    {
        return Random.value;
    }

    public float GetPerlinNoise(float x, float z)
    {
        //gives a float between 0 and 1. For better fractal terrain, change this to values between 0 and 2
        return (2 * Mathf.PerlinNoise(x, z) - 1);
    }

    public float GetFractalNoise(float x, float z)
    {
        float fractalNoise = 0;

        float amplitude = 1;
        float frequency = 1;

        for (int i = 0; i < octaves; i++)
        {
            float xVal = x * frequency * perlinScale;
            float zVal = z * frequency * perlinScale;

            fractalNoise += amplitude * GetPerlinNoise(xVal, zVal);

            frequency *= lacunarity;
            amplitude *= gain;
        }

        return fractalNoise;
    }


}
