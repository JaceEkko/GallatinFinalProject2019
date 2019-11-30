using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMountain : MonoBehaviour
{

    public GameObject mountain;
    private ProceduralMeshLandscape PML;
    
    public bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        PML = mountain.GetComponent<ProceduralMeshLandscape>();
    }

    // Update is called once per frame
    void Update()
    {
        float f =  Mathf.Atan(this.transform.position.x / this.transform.position.z);
        float fdeg = f * (180 / Mathf.PI);
        //Debug.Log(fdeg);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Spawn");

            //Instantiate(mountain, new Vector3(Random.Range(-50.0f, 50.0f), 6.9f, Random.Range(-50.0f, 50.0f)), Quaternion.identity);
            //if (Camera.main.transform.position.x < 0 && Camera.main.transform.position.z < 0)
            //{
            Instantiate(mountain, new Vector3(this.transform.position.x, mountain.transform.position.y + (PML.falloffsize / 2), this.transform.position.z), new Quaternion(PML.transform.rotation.x, PML.transform.rotation.y, PML.transform.rotation.z, PML.transform.rotation.w + fdeg));/*new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w)*/
            //}
            isRunning = true;
        }
    }
}
