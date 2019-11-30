using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMeshLandscape : AbstractGenerator{

	[SerializeField]private int xResolution = 200;
	[SerializeField]private int zResolution = 200;
	
	public int meshScale = 10;
	[SerializeField]private float yScale = 1;
	
    
	[SerializeField, Range(1, 8)]private int octaves = 1;
	[SerializeField]private float lacunarity = 2;
	[SerializeField, Range(0,1)]private float gain = 0.5f; // in between 0 and 1 so each octave contributes less to the final shape
	[SerializeField]private float perlinScale = 1;

    [SerializeField]private float uvScale = 1;

    [SerializeField]private FallOffType type;
	public float falloffsize = 109;
    [SerializeField] private float seaLevel = -7;
	
	[SerializeField]private float xoffset = 0;
	[SerializeField]private float zoffset = 0;


    private void Start()
    {
        meshScale = Random.Range(10, 40);
        //falloffsize = Random.Range(109, 125);

        xResolution = Random.Range(200, 300);
        zResolution = Random.Range(200, 300);
    }
    protected override void SetMeshNums (){
		numVertices = (xResolution + 1) *  (zResolution + 1); // number of vertices in x direction multiplied by number in z
		 // This is 3 ints per geometric triangle * 2 geometric triangles per square
         // * num of triangles needed in x direct * triangles needed in z direct
		numTriangles = 6 * xResolution * zResolution;
	}

	protected override void SetVertices (){
		float xx, y, zz = 0;
		Vector3[] vs = new Vector3[numVertices];
		
		NoiseGenerator noise = new NoiseGenerator(octaves, lacunarity, gain, perlinScale);
        for (int z = 0; z <= zResolution; z++)
        {

            for (int x = 0; x <= xResolution; x++)
            {

                xx = (((float)x / (xResolution)) * meshScale);
                zz = ((float)z / (zResolution)) * meshScale;

                y = yScale * noise.GetFractalNoise(xx - 100, zz - 100);//(FRACTAL NOISE) .GetPerlinNoise(x, 0); (PERLIN NOISE) //.GetValueNoise();
                y = FallOff((float)x + xoffset, y, (float)z + zoffset);


                vertices.Add(new Vector3(xx, y, zz));

            }

        }
        
    }
	
	private float FallOff(float x, float height, float z){
		//shift the corrdinates to the center
		x = (x - xResolution / 2f);
		z = (z - zResolution / 2f);
		
		float falloff = 0;
		
		switch(type){
			case FallOffType.None:
				return height;
			case FallOffType.Circular:
				falloff = Mathf.Sqrt(x * x + z * z) / falloffsize;
				return GetHeight(falloff, height);
			case FallOffType.RoundedSquare:
				falloff = Mathf.Sqrt(x*x*x*x + z*z*z*z) / falloffsize;
				return GetHeight(falloff, height);
			default:
				Debug.Log("Unrecognized FallOff Type: " + type);
				return height;
		}
	}
	
	private float GetHeight(float fallOff, float height){
		//falloff is 0,0 at the center and then increases outwards
		if(fallOff < 1){
			//make gradient softer
			fallOff = fallOff * fallOff * (3 - 2 * fallOff);
			
			//gradient the height
			height = height - fallOff * (height - seaLevel);
		}
		else{
			height = seaLevel;
		}
		return height;
	}
	
	protected override void SetTriangles (){
		int triCount = 0;
		for(int z = 0; z < zResolution; z++){
			
			for(int x = 0; x < xResolution; x++){
				
				//bottom-left triangle
				triangles.Add(triCount);
				triangles.Add(triCount + xResolution + 1);
				triangles.Add(triCount + 1);
				
				//top-right triangle
				triangles.Add(triCount + 1);
				triangles.Add(triCount + xResolution + 1);
				triangles.Add(triCount + xResolution + 2);
				
				triCount++;
				
			}
			
			triCount++;
			
		}
	}

	protected override void SetUVs (){
        for (int z = 0; z <= zResolution; z++)
        {

            for (int x = 0; x <= xResolution; x++)
            {

                uvs.Add(new Vector2(x / (uvScale * xResolution), z / (uvScale * zResolution)));

            }


        }
    }

	protected override void SetNormals (){}
	protected override void SetTangents (){}
	protected override void SetVertexColors (){}
    protected override float changeHeights(int yVal)
    {
        return 0;
    }
}
