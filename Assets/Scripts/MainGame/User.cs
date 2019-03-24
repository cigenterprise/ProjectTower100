using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Actor
{
    struct DirObj
    {
        public GameObject gameObject;
        public DirCollider dirCollider;
    }
    DirObj[] dirObj;

    UIUser uiUser;

    new void Awake()
    {
        base.Awake();

        spriteSize.Set( 1.0f, 1.5f );

        SetSprite( "Ahri_SD" );

        dirObj = new DirObj[ DIRECTION.LTRB_INDEX_MAX ];
        for ( int idx = 0; idx < DIRECTION.LTRB_INDEX_MAX; ++idx )
        {
            dirObj[ idx ].gameObject = new GameObject();
            dirObj[ idx ].gameObject.transform.SetParent( transform );
            dirObj[ idx ].dirCollider = dirObj[idx].gameObject.AddComponent<DirCollider>();
            switch ( idx )
            {
                case DIRECTION.LEFT:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.LEFT_VEC2 * dirObj[ idx ].dirCollider.colliderSize - new Vector2( bodyCollider.size.x / 2, 0 ) ;
                    dirObj[ idx ].gameObject.name = "Collider_Left";
                    break;
                case DIRECTION.TOP:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.TOP_VEC2 * dirObj[ idx ].dirCollider.colliderSize + new Vector2( 0, bodyCollider.size.y / 2 );
                    dirObj[ idx ].gameObject.name = "Collider_Top";
                    break;
                case DIRECTION.RIGHT:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.RIGHT_VEC2 * dirObj[ idx ].dirCollider.colliderSize + new Vector2( bodyCollider.size.x / 2, 0 );
                    dirObj[ idx ].gameObject.name = "Collider_Right";
                    break;
                case DIRECTION.BOTTOM:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.BOTTOM_VEC2 * dirObj[ idx ].dirCollider.colliderSize - new Vector2( 0, bodyCollider.size.y / 2 );
                    dirObj[ idx ].gameObject.name = "Collider_Bottom";
                    break;
                default:
                    break;
            }
        }

        GameObject uiObj = new GameObject();
        uiUser = uiObj.AddComponent<UIUser>();
        uiUser.SetUser( this );
        uiObj.transform.SetParent(transform);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            Move( dirObj[ DIRECTION.RIGHT ], _stat.moveSpeed );
            transform.localScale = new Vector3( 1, 1, 1 );
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            Move( dirObj[ DIRECTION.LEFT ], _stat.moveSpeed );
            //transform.localScale = new Vector3( -1, 1, 1 );
        }
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            Move( dirObj[ DIRECTION.TOP ], _stat.moveSpeed );
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            Move( dirObj[ DIRECTION.BOTTOM ], _stat.moveSpeed );
        }
    }

    void Move( DirObj dirObj, float speed )
    {
        if ( dirObj.dirCollider.bMovable ) transform.position += dirObj.gameObject.transform.localPosition.normalized * speed;
    }

}
