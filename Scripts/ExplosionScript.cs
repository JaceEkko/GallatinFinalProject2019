using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    private ParticleSystem PE;
    public ParticleSystemScalingMode PSR;

    [SerializeField] GameObject SpawnPoint;
    float spawnDist;
    float mountSize;

    // Use this for initialization
    void Start () {
        PE = this.GetComponent<ParticleSystem>();
        SpawnPoint = GameObject.Find("SpawnPoint");
    }
	
	// Update is called once per frame
	void Update () {
        spawnDist = SpawnPoint.transform.position.z;
        mountSize = Mathf.Abs(spawnDist / 20);

        var main = PE.main;
        main.startSize = mountSize / 2;
        Destroy(this.gameObject, 3);
    }
        
}
