using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    [System.Serializable]
    public class Stat
    {
        public float moveSpeed = 0.1f;
    }
    public Stat stat = new Stat();

    private BoxCollider2D boxCollider = null;
    private Rigidbody2D rigidBody = null;

    private void Awake()
    {
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(1, 1);
        boxCollider.isTrigger = true;

        rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Static;
        rigidBody.isKinematic = false;
        rigidBody.gravityScale = 0;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
