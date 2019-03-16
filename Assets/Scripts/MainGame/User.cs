using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Actor
{
    GameObject dirObj = null;
    DirCollider dirCollider = null;

    new void Awake()
    {
        base.Awake();

        SetSprite( "hitEffect" );

        dirObj = new GameObject();
        dirObj.transform.SetParent( transform );
        dirCollider = dirObj.AddComponent<DirCollider>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _stat.direction = new Vector2( 0, 0 );

        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            _stat.direction += DIRECTION.RIGHT;
            transform.localScale = new Vector3( 1, 1, 1 );
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            _stat.direction += DIRECTION.LEFT;
            //transform.localScale = new Vector3( -1, 1, 1 );
        }
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            _stat.direction += DIRECTION.TOP;
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            _stat.direction += DIRECTION.BOTTOM;
        }

        Vector2 dir = _stat.direction * _stat.moveSpeed;
        dirObj.transform.localPosition = new Vector3( dir.x, dir.y, 0 ) * 10;
        Move( _stat.direction * _stat.moveSpeed );

    }

    void Move( Vector2 dir )
    {
        if ( dirCollider.bMovable )
            transform.position += new Vector3( dir.x, dir.y, 0 );
    }

}
