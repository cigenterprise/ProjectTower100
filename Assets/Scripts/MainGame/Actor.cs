using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer = null;
    private GameObject spriteObj = null;
    protected Vector2 spriteSize = new Vector2( 1, 1 );
    protected BoxCollider2D bodyCollider = null;
    private Animator animator = null;

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
        spriteObj = new GameObject();
        spriteObj.name = "Sprite";
        spriteObj.transform.SetParent(transform);
        RectTransform spriteTfm = spriteObj.AddComponent<RectTransform>();
        spriteTfm.localScale = new Vector3( 1, 1, 1 );
        _spriteRenderer = spriteObj.AddComponent<SpriteRenderer>();
        _spriteRenderer.drawMode = SpriteDrawMode.Sliced;
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
        _spriteRenderer.size = spriteSize;
    }

    public void SetAnimation( string filePath )
    {
        if ( !animator ) animator = spriteObj.AddComponent<Animator>();
        
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>( filePath );
    }
}
