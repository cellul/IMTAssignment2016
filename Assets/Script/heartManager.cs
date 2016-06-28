using UnityEngine;
using System.Collections;

public class heartManager : MonoBehaviour {

    public float heartSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,1,0) * heartSpeed * Time.deltaTime); //move the hearts in particular direction
	}
}
