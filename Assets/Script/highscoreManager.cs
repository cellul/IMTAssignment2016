using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class highscoreManager : MonoBehaviour {

    public Text highscoreText; //holds the highscore text

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("score") /*+ " (" + PlayerPrefs.GetString("name") + ")"*/; //updates the highscore text
    }
}
