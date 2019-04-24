using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    private SpriteRenderer m_spriteRenderer = null;
    private GameObject m_spriteObj = null;
    protected Vector2 m_spriteSize = Vector2.one;
    protected BoxCollider2D m_bodyCollider = null;
    private Animator m_animator = null;

    [System.Serializable]
    public class Stat
    {
        public float fVEL   = 0.1f;     // Velocity
        public float fCHP   = 10.0f;    // Current HP
        public float fMHP   = 10.0f;    // Max HP
        public float fCH    = 10.0f;    // Current Hunger
        public float fMH    = 10.0f;    // Max Hunger
        public float fADB   = 1.0f;     // Attack Damage Base
    }
    public Stat m_stat = new Stat();

    protected void Awake()
    {
        m_spriteObj = new GameObject();
        m_spriteObj.name = "Sprite";
        m_spriteObj.transform.SetParent(transform);
        RectTransform spriteTfm = m_spriteObj.AddComponent<RectTransform>();
        spriteTfm.localScale = Vector3.one;
        spriteTfm.localPosition = new Vector3( 0, 0, LAYERZ.ACTOR );
        m_spriteRenderer = m_spriteObj.AddComponent<SpriteRenderer>();
        m_spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        SetSprite( "hitEffect" );

        m_bodyCollider = gameObject.AddComponent<BoxCollider2D>();
        m_bodyCollider.size = Vector2.one;
        m_bodyCollider.isTrigger = true;
        m_bodyCollider.tag = "Actor";

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
        m_spriteRenderer.sprite = Resources.Load<Sprite>( filePath );
        m_spriteRenderer.size = m_spriteSize;
    }

    public void SetAnimation( string filePath )
    {
        if ( !m_animator ) m_animator = m_spriteObj.AddComponent<Animator>();
        
        m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>( filePath );
    }

    public void IncreaseHp( float value )
    {
        m_stat.fCHP -= value;
    }
}
