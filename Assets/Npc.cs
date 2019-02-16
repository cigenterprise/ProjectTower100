using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Actor {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter!");
        
        GameObject gameObject = new GameObject();
        gameObject.name = "SlidePuzzle";
        gameObject.AddComponent<SlidePuzzle>();

        gameObject.transform.SetParent(this.gameObject.transform.parent);
    }

}
