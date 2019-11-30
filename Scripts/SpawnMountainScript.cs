using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMountainScript : MonoBehaviour {

	public GameObject Mountain;
    private bool canSpawn = true;

    private ProceduralMeshLandscape PML;
    private ButtonPressScript BPS;

    string prevBut;
   
    // Use this for initialization
    void Start () {
		string[] s = Input.GetJoystickNames ();
		for (int i = 0; i < s.Length; i++) {
			Debug.Log (s [i]);
		}

        PML = Mountain.GetComponent<ProceduralMeshLandscape>();
        BPS = this.GetComponent<ButtonPressScript>();

        
    }
        
    // Update is called once per frame
    void Update () {
        Debug.Log("Current detected event: " + Event.current);
        float f = Mathf.Atan(this.transform.position.x / this.transform.position.z);
        float fdeg = f * (180 / Mathf.PI);

        if (Input.GetButtonDown ("X"))
        {
            Instantiate(Mountain, new Vector3(this.transform.position.x, Mountain.transform.position.y + (PML.falloffsize / 2), this.transform.position.z), new Quaternion(PML.transform.rotation.x, PML.transform.rotation.y, PML.transform.rotation.z, PML.transform.rotation.w + fdeg));/*new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w)*///Instantiate (Mountain, new Vector3(0,0.0001f,13.9f), new Quaternion(0,0,0,0));
            //Debug.Log ("Shabam!!");
            canSpawn = false;
            prevBut = BPS.RetString();
        }
        if (Input.GetButtonDown("Circle"))
        {
            Instantiate(Mountain, new Vector3(this.transform.position.x, Mountain.transform.position.y + (PML.falloffsize / 2), this.transform.position.z), new Quaternion(PML.transform.rotation.x, PML.transform.rotation.y, PML.transform.rotation.z, PML.transform.rotation.w + fdeg));/*new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w)*///Instantiate (Mountain, new Vector3(0,0.0001f,13.9f), new Quaternion(0,0,0,0));
            //Debug.Log ("Shabam!!");
            canSpawn = false;
            prevBut = BPS.RetString();
        }
        if (Input.GetButtonDown("Triangle"))
        {
            Instantiate(Mountain, new Vector3(this.transform.position.x, Mountain.transform.position.y + (PML.falloffsize / 2), this.transform.position.z), new Quaternion(PML.transform.rotation.x, PML.transform.rotation.y, PML.transform.rotation.z, PML.transform.rotation.w + fdeg));/*new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w)*///Instantiate (Mountain, new Vector3(0,0.0001f,13.9f), new Quaternion(0,0,0,0));
            //Debug.Log ("Shabam!!");
            canSpawn = false;
            prevBut = BPS.RetString();
        }
        if (Input.GetButtonDown("Square"))
        {
            Instantiate(Mountain, new Vector3(this.transform.position.x, Mountain.transform.position.y + (PML.falloffsize / 2), this.transform.position.z), new Quaternion(PML.transform.rotation.x, PML.transform.rotation.y, PML.transform.rotation.z, PML.transform.rotation.w + fdeg));/*new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w)*///Instantiate (Mountain, new Vector3(0,0.0001f,13.9f), new Quaternion(0,0,0,0));
            //Debug.Log ("Shabam!!");
            canSpawn = false;
            prevBut = BPS.RetString();
        }
        
        Debug.Log("Resets When NOT Equal!!");
        Debug.Log("Prev: " + prevBut);
        Debug.Log("Curr: " + BPS.RetString());
    }

    
}
