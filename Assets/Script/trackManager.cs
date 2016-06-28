using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class trackManager : MonoBehaviour
{

    public float speed; //controls in how much speed the track is moving
	Vector2 offset; //moves the texture on the quad
    public Texture2D tex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2 (0, Time.time * speed); //increase the value depending on the time

		GetComponent<Renderer>().material.mainTextureOffset = offset;
        GetComponent<Renderer>().material.mainTexture = tex;
	}
}
