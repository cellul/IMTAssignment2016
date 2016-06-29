using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class carManager : MonoBehaviour {

    //public GameObject car; //car to be instantiated
    public float carSpeed; //controls the speed of the car
    public float maxPos;
    Vector3 position; //temporary position of the car
    public uiManager ui; //lets the car access the uiManager scrip
    public audioManager am; //lets the car access the audioManager script


    //triggered when the car collides
    /*IEnumerator whenCollided(){
        ui.Collide();
        am.carSound.Stop();
        yield return new WaitForSeconds(1);
        am.carSound.Play();
    }*/

	// Use this for initialization
	void Start () {
        AudioListener.pause = false;  //sound is playing at the beginning of the game
        am.carSound.Play(); //play the sound attached to the audio source
        position = transform.position; //current position of the car
	}
	
	// Update is called once per frame
	void Update () {
        position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime; //keeps the car moving in the same position on the x axis
        position.x = Mathf.Clamp(position.x, -7.2f, 7.2f); //limit the value of the x position
        transform.position = position;
	}

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Enemy car")
        {
            if (ui.lives <= 0)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
                //if the saved score is less than the current score
                if (PlayerPrefs.GetInt("score") < ui.score)
                {
                    PlayerPrefs.SetInt("score", ui.score); //save the new high score
                    //PlayerPrefs.SetString("name", ui.name); //save the new high score player
                }
            }
            else
            {
                Destroy(col.gameObject);
                //if the saved score is less than the current score
                if (PlayerPrefs.GetInt("score") < ui.score)
                {
                    PlayerPrefs.SetInt("score", ui.score); //save the new high score
                    //PlayerPrefs.SetString("name", ui.name); //save the new high score player
                }
                ui.Collide();
                am.crashSound.Play();
                am.carSound.Stop();
                //yield return new WaitForSeconds(1);
                am.carSound.Play();
                //Instantiate(car, transform.position, transform.rotation); //reinstantiate the car
            }


        }

        if (col.gameObject.tag == "Coin"){
            Destroy(col.gameObject);
            am.coinSound.Play();
            ui.score += 10;
            ui.coins += 1;
            ui.scoreText.text = "Score: " + ui.score;
            ui.coinsText.text = "Coins: " + ui.coins;
        }

        if (col.gameObject.tag == "Heart"){
            Destroy(col.gameObject);
            am.heartSound.Play();
            ui.lives += 1;
            ui.score += 5;
            ui.livesText.text = "Lives: " + ui.lives;
            ui.scoreText.text = "Score: " + ui.score;
        }
    }
}
