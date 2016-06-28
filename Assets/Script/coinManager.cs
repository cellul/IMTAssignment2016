using UnityEngine;
using System.Collections;

public class coinManager : MonoBehaviour {

    public float coinSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,1,0) * coinSpeed * Time.deltaTime); //move the coin in particular direction
	}
}
