using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer), typeof(MeshCollider))]
[ExecuteInEditMode] //Calls the Update method when something happens to the scene
public abstract class AbstractGenerator : MonoBehaviour {

    public bool running = true;

	[SerializeField] protected Material material;

	protected List<Vector3> vertices;
	protected List<int> triangles;

	protected List<Vector3> normals;
	protected List<Vector4> tangents;
	protected List<Vector2> uvs;
	protected List<Color32> vertexcolors;

	protected int numVertices;
	protected int numTriangles;

	private Mesh mesh;
	private MeshRenderer meshrenderer;
	private MeshFilter meshfilter;
	private MeshCollider meshcollider;

    private GameObject controller;
    private int frameCount = 0; // frames till this program stops looping
    private int tillLoopEnds = 1;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller");
        running = controller.GetComponent<SpawnMountain>().isRunning;
    }

    void Update(){
        if (running)
        {
            meshfilter = GetComponent<MeshFilter>();
            meshrenderer = GetComponent<MeshRenderer>();
            meshcollider = GetComponent<MeshCollider>();

            meshrenderer.material = material;

            //intialize
            //vertices = new List<Vector3>();
            //triangles = new List<int>();

            InitMesh();
            SetMeshNums();

            CreateMesh();

            //running = false;

            
            if (frameCount == tillLoopEnds)
            {
                running = false;
                frameCount = 0;
            }
            else {
                frameCount++;
            }
            
        }
	}

	protected abstract void SetMeshNums ();

	private bool ValidateMesh(){
		//build a string containing errors
		string errorStr = "";

		//check there are the correct number of vertices and triangles
		errorStr += vertices.Count == numVertices ? "" : "Should be " + numVertices +
			" vertices, but there are " + vertices.Count + ". ";
		errorStr += triangles.Count == numTriangles ? "" : "Should be " + numTriangles +
			" triangles, but there are " + triangles.Count + ". ";

		//Check there are the correct number of normals - there should be the same number of normals as there are vertices
		//If we're not manually calculating normals, there will be 0. Similarly for tangents, uvs, and vertex colors
		errorStr += (normals.Count == numVertices || normals.Count == 0) ? "" : "Should be " + numVertices +
			" vertices, but there are " + normals.Count + ". ";
		errorStr += (tangents.Count == numVertices || tangents.Count == 0) ? "" : "Should be " + numVertices +
			" vertices, but there are " + tangents.Count + ". ";
		errorStr += (uvs.Count == numVertices || uvs.Count == 0) ? "" : "Should be " + numVertices +
			" vertices, but there are " + uvs.Count + ". ";
		errorStr += (vertexcolors.Count == numVertices || vertexcolors.Count == 0) ? "" : "Should be " + numVertices +
			" vertices, but there are " + vertexcolors.Count + ". ";

		bool isValid = string.IsNullOrEmpty (errorStr);

		if (!isValid) {
			Debug.LogError ("Not Drawing Mesh. " + errorStr);
		}

		return isValid;
	}

	private void InitMesh(){

		vertices = new List<Vector3> ();
		triangles = new List<int> ();

		normals = new List<Vector3> ();
		tangents = new List<Vector4> ();
		uvs = new List<Vector2> ();
		vertexcolors = new List<Color32> ();
	}

	private void CreateMesh(){
		mesh = new Mesh();

		SetVertices ();
		SetTriangles ();

		SetNormals ();
		SetUVs ();
		SetTangents ();
		SetVertexColors ();

        changeHeights(0);

		if (ValidateMesh ()) {
			//This shouls be done in this order (Vertices then Triangles)
			mesh.SetVertices (vertices);
			mesh.SetTriangles (triangles, 0); //0 cause we are using a single material (green TriangleMaterial)

			if (normals.Count == 0) {
				mesh.RecalculateNormals ();
				normals.AddRange (mesh.normals);
			}

			mesh.SetNormals (normals);
			mesh.SetTangents (tangents);
			mesh.SetUVs (0, uvs);
			mesh.SetColors (vertexcolors);

			meshfilter.mesh = mesh;
			meshcollider.sharedMesh = mesh;
		}

	}

	protected abstract void SetVertices ();
	protected abstract void SetTriangles ();

	protected abstract void SetNormals ();
	protected abstract void SetTangents ();
	protected abstract void SetUVs ();
	protected abstract void SetVertexColors ();
    protected abstract float changeHeights(int yVal);
}
