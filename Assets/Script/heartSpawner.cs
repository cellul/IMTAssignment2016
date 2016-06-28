using UnityEngine;
using System.Collections;

public class heartSpawner : MonoBehaviour {

    public GameObject hearts; //hearts to be instantiated
    public int noOfHearts; //how many hearts to be spawned
    public float maxPos; //maximum position from where hearts are to be instantiated
    
    public float minTimer; //minumum time by which the timer is delayed
    public float maxTimer; //maximum time by which the timer is delayed

    // Use this for initialization
    void Start () {
        StartCoroutine("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator Spawn() {
        for (int i = 0; i < noOfHearts; i++) {
            yield return new WaitForSeconds(Random.Range(minTimer, maxTimer));
            Vector3 heartPos = new Vector3(Random.Range(-7.2f, 7.2f), transform.position.y, transform.position.z); //creating different positions on the x axis where the hearts are spawned from
            Instantiate(hearts, heartPos, transform.rotation); //instantiate the heart from the empty gameobject
        }
    }
}
