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
        //Debug.Log(radius);
        /*
        if (transform.localScale.x < (2 * radius))
        {
            transform.localScale += new Vector3(3f, .5f, 3f);
        }
        */
        transform.localScale += new Vector3(3f, .5f, 3f);
        if (transform.localScale.x >= (2 * radius)) {
            //transform.localScale = new Vector3(1, 1, 1);
            this.GetComponent<AudioSource>().mute = true;
            Destroy(this.gameObject, 3);
        }
        /*
        if (transform.localScale.x > 10) {
            Color color = this.GetComponent<MeshRenderer>().material.color;
            color.a -= Time.deltaTime * fadeSpeed;
            this.GetComponent<MeshRenderer>().material.color = color;
            //ShockMat.material.SetFloat("_SoftParticlesFactor", 0f);
        }
        */
    }

}
