using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignMountain : MonoBehaviour {

    private SpawnMountain SM;
    [SerializeField] private GameObject ShockWave;
    [SerializeField] private GameObject Explosion;

    float xOffset;
    float zOffset;
    
    Vector3 mountPos;
    float spawnDist;
    float mountSize; // The farther the spawnPoint the Bigger the mountain
    float mountRise = 0.0f; //increment to make mountain irse from the ground;
    float offsetAmount;

    [SerializeField] private lookTest lt;
    [SerializeField] GameObject SpawnPoint;

    ProceduralMeshLandscape PML;

    void Start()
    {
        ProceduralMeshLandscape PML = this.GetComponent<ProceduralMeshLandscape>();
        SpawnPoint = GameObject.Find("SpawnPoint");

        mountPos = this.transform.position;
        spawnDist = SpawnPoint.transform.position.z;
        mountSize = Mathf.Abs(spawnDist / 20);

        this.transform.localScale += new Vector3(mountSize, mountSize, mountSize);

        offsetAmount = (mountSize * (PML.meshScale / 2));

        xOffset = this.transform.position.x - offsetAmount;
        mountPos.x = xOffset;


        zOffset = this.transform.position.z - offsetAmount;
        mountPos.z = zOffset;

        if(mountRise <= (6 * mountSize))
        {
            mountRise += 1f;
            mountPos.y = mountRise;
        }
        
        this.transform.position = mountPos;//new Vector3(xOffset, 2.0f, zOffset);

    }

    void Update()
    {
        if (mountRise <= (6 * mountSize))
        {
            mountRise += (mountSize / 2);
            mountPos.y = mountRise;
        }
        else {
            Instantiate(ShockWave, new Vector3(this.transform.position.x + offsetAmount, 0, this.transform.position.z + offsetAmount),  Quaternion.identity);
            Instantiate(Explosion, new Vector3(this.transform.position.x + offsetAmount, 0, this.transform.position.z + offsetAmount), Quaternion.identity);
            Destroy(this); //kill script
        }

        this.transform.position = mountPos;

    }

}
