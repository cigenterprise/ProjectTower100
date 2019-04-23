using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl_MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Left button
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("MainGame");
        }
    }

}
