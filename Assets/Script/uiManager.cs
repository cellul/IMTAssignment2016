using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

    [SerializeField]
    private Text pause = null; //holds the pause button text
    [SerializeField]
    private Text mute = null; //holds the mute button text
    public Button[] buttons; //array of buttons
    public Text scoreText; //holds the score text
    public Text livesText; //holds the lives text
    public Text coinsText; //holds the coins text
    bool collide;
    public int score; //holds the number of score
    public int lives; //holds the number of lives
    public int coins; //holds the number of coins
    public bool canMute; //holds if mute is true or false
    public int winCon; //holds the score number to win
    
    // Triggered when play button is pressed in the menu scene
    public void playButtonPress()
    {
        Application.LoadLevel(1);
        //Debug.Log("Going to choose menu...");
    }

    // Triggered when exit button is pressed in the menu scene
    public void exitButtonPress()
    {
        Application.Quit();
        Debug.Log("The application is closing...");
    }

   // Triggered when OK button is pressed in the menu scene
    public void okButtonPress(){

        //read name from textbox, create a string to write the name as output, write/update the latter
        string name = GameObject.Find("InputField").GetComponent<InputField>().text;
        string welcome = "Welcome " + name + "!";
        GameObject.Find ("OutputText").GetComponent<Text> ().text = welcome;
        Debug.Log(name);
	}

    // Triggered when close button is pressed in the choose scene
    public void closeButtonPress()
    {
        Application.LoadLevel(0);
        //Debug.Log("Going back to the menu...");
    }

    public void helpButtonPress(){
        Application.LoadLevel(2);
    }

    // Triggered when supra button is pressed in the choose scene
    public void supraButtonPress()
    {
        Application.LoadLevel(3);
    }

    // Triggered when gtr button is pressed in the choose scene
    public void gtrButtonPress()
    {
        Application.LoadLevel(4);
    }

    // Triggered when carrera button is pressed in the choose scene
    public void carreraButtonPress()
    {
        Application.LoadLevel(5);
    }

    //Triggered when the pause button is pressed in the game scene
    public void pauseButtonPress()
    {
	//if the game is running, it gets paused and vice versa
        if (Time.timeScale == 1){
            Time.timeScale = 0;
            pause.text = "►";
        }else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pause.text = "▍▍";
        }

    }

    //Triggered when the mute button is pressed in the game scene
    public void muteButtonPress()
    {
	//if the game is muted, sound gets playing and vice versa
        if (canMute){
            AudioListener.pause = true;
            canMute = false;
            mute.text = "UNMUTE";
        }else{
            AudioListener.pause = false;
            canMute = true;
            mute.text = "MUTE";
        }

    }

    //Increments the score by 1
    public void scoreUpdate(){
        if ((!collide) && (lives !=0)){
            score += 1;
        }
    }

    //Triggered when the player is destroyed
    public void Collide(){
        collide = true; //when the car collides, change the bool to true
        if (lives > 0)
        {
            lives -= 1; //if lives are not down to 0 yet, decrement lives
        }

        if (lives == 0){
            foreach (Button button in buttons){
                button.gameObject.SetActive(true);
            }

            collide = true;
        }else {
            score = 0;
            collide = false; //reset score to 0 and set collide to false again to continue playing if lives is not yet down to 0
        }
    }

    // Use this for initialization
    void Start () {
        canMute = true; //can mute is true at the beginning of the game because sound is playing
        collide = false; //collide is false at the beginning of the game
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f); //update the score every 0.5 seconds
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score; //updates the score text
        livesText.text = "Lives: " + lives; //updates the lives text

        if (score >= winCon) {
            Application.LoadLevel(6);
            //if the saved score is less than the current score
            if (PlayerPrefs.GetInt("score") < score)
            {
                PlayerPrefs.SetInt("score", score); //save the new high score
                //PlayerPrefs.SetString("name", name); //save the new high score player
            }
        }
    }
}
