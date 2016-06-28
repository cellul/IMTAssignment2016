using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

    public GameObject[] enemies; //array of cars to be instantiated
    int enemyNo; //which car to spawn
    public float maxPos; //maximum position from where cars are to be instantiated

    public int noOfEnemies; //how many enemy cars are to be spawned
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
        for (int i = 0; i < noOfEnemies; i++) {
            yield return new WaitForSeconds(Random.Range(minTimer, maxTimer));
            Vector3 enemyPos = new Vector3(Random.Range(-7.2f, 7.2f), transform.position.y, transform.position.z); //creating different positions on the x axis where the enemies are spawned from
            enemyNo = Random.Range(0,8); //select a random number of car
            Instantiate(enemies[enemyNo], enemyPos, transform.rotation); //instantiate the car from the empty gameobject
        }
    }
}
