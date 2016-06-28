using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour {

    public float enemySpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,1,0) * enemySpeed * Time.deltaTime);//move the enemy car in particular direction
	}
}
