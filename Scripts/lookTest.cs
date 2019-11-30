using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookTest : MonoBehaviour {

    //private MeshRenderer meshRenderer;
    private Renderer rend;
    private bool cantSpawn = false;

    [SerializeField] private float minSpawnDist = 50; // The closest distance you can place a mountain
    public float maxSpawnDist = 900; // The closest distance you can place a mountain

    [SerializeField] private MeshRenderer spawnPointMR;

    [SerializeField] private GameObject cursorShape;
    private float spawnDist;
    
    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        //meshRenderer = GetComponent<MeshRenderer>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnDist = this.transform.position.z;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        
        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram...
            // Display the cursor mesh.
            //meshRenderer.enabled = true;

            // Move the cursor to the point where the raycast hit.
            transform.position = hitInfo.point;
            
            //transform.position = gazeDirection;

            // Rotate the cursor to hug the surface of the hologram.
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            //make the cursor green if the hologram is manipulatable, else red


        }
        else {
            Debug.Log("here");
            transform.position += new Vector3(100,0,100);
        }
        
                
    }
    
}
