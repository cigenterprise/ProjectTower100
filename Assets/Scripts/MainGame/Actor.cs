using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer = null;
    protected BoxCollider2D bodyCollider = null;

    [System.Serializable]
    public class Stat
    {
        public float moveSpeed = 0.1f;
        public float hpCurrent = 10.0f;
        public float hpMax = 10.0f;
    }
    public Stat _stat = new Stat();

    protected void Awake()
    {
        _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        SetSprite( "hitEffect" );

        bodyCollider = gameObject.AddComponent<BoxCollider2D>();
        bodyCollider.size = new Vector2( 1, 1 );
        bodyCollider.isTrigger = true;
        bodyCollider.tag = "Actor";

        Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Static;
        rigidBody.isKinematic = false;
        rigidBody.gravityScale = 0;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPosition( float x, float y, float z = 0 )
    {
        transform.position = new Vector3( x, y, z );
    }

    public void SetSprite( string filePath )
    {
        _spriteRenderer.sprite = Resources.Load<Sprite>( filePath );
    }

}
