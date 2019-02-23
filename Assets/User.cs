using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Actor
{

    new void Awake()
    {
        base.Awake();

        SetSprite( "hitEffect" );
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            transform.position += new Vector3( +_stat.moveSpeed, 0, 0 );
            transform.localScale = new Vector3( 1, 1, 1 );
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            transform.position += new Vector3( -_stat.moveSpeed, 0, 0 );
            transform.localScale = new Vector3( -1, 1, 1 );
        }
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            transform.position += new Vector3( 0, +_stat.moveSpeed, 0 );
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            transform.position += new Vector3( 0, -_stat.moveSpeed, 0 );
        }
    }
}
