using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveScript : MonoBehaviour {

    private MeshRenderer ShockMat;
    private float fadeSpeed = 1f;

    [SerializeField] GameObject SpawnPoint;
    private float radius;

    void Start()
    {
        ShockMat = this.GetComponent<MeshRenderer>();
        SpawnPoint = GameObject.Find("SpawnPoint");

        radius = Mathf.Abs(SpawnPoint.transform.position.z);
        
    }

    void Update()
    {
        transform.localScale += new Vector3(3f, .5f, 3f);
        if (transform.localScale.x >= (2 * radius)) {
            this.GetComponent<AudioSource>().mute = true;
            Destroy(this.gameObject, 3);
        }
    }

}
