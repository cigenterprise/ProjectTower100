using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirCollider : MonoBehaviour
{
    public BoxCollider2D dirCollider = null;
    public Rigidbody2D dirRigidBody = null;
    public bool bMovable = true;
    public float colliderSize = 0.2f;

    private void Awake()
    {
        dirCollider = gameObject.AddComponent<BoxCollider2D>();
        dirCollider.size = new Vector2( colliderSize, colliderSize );
        dirCollider.isTrigger = true;

        dirRigidBody = gameObject.AddComponent<Rigidbody2D>();
        dirRigidBody.bodyType = RigidbodyType2D.Static;
        dirRigidBody.isKinematic = false;
        dirRigidBody.gravityScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( "Gate" ) )
        {
            SceneControl_MainGame._userObj.transform.localPosition = new Vector2( 0, 0 );
            SceneControl_MainGame._field.LoadNextFloor();
        }
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        if ( collision.CompareTag( "Wall" ) )
            bMovable = false;
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if ( collision.CompareTag( "Wall" ) )
            bMovable = true;
    }
}
