using UnityEngine;
using System.Collections;

public class coinSpawner : MonoBehaviour {

    public GameObject coins; //coins to be instantiated
    public int noOfCoins; //how many coins to be spawned
    public float maxPos; //maximum position from where coins are to be instantiated

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
        for (int i = 0; i < noOfCoins; i++) {
            yield return new WaitForSeconds(Random.Range(minTimer, maxTimer));
            Vector3 coinPos = new Vector3(Random.Range(-7.2f, 7.2f), transform.position.y, transform.position.z); //creating different positions on the x axis where the coins are spawned from
            Instantiate(coins, coinPos, transform.rotation); //instantiate the coins from the empty gameobject
        }
    }
}
