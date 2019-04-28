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

    public struct UserStat
    {
        public int currency;
    }
    public UserStat userStat;

    bool m_bNameSet = false;

    new void Awake()
    {
        gameObject.name = "User";

        base.Awake();

        m_spriteSize.Set( 1.0f, 1.5f );
        SetSprite( "Ahri_SD" );
        SetAnimation( "Character/Ahri_SD" );

        dirObj = new DirObj[ DIRECTION.LTRB_INDEX_MAX ];
        for ( int idx = 0; idx < DIRECTION.LTRB_INDEX_MAX; ++idx )
        {
            dirObj[ idx ].gameObject = new GameObject();
            dirObj[ idx ].gameObject.transform.SetParent( transform );
            dirObj[ idx ].dirCollider = dirObj[idx].gameObject.AddComponent<DirCollider>();
            switch ( idx )
            {
                case DIRECTION.LEFT:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.LEFT_VEC2 * dirObj[ idx ].dirCollider.colliderSize - new Vector2( m_bodyCollider.size.x / 2, 0 ) ;
                    dirObj[ idx ].gameObject.name = "Collider_Left";
                    break;
                case DIRECTION.TOP:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.TOP_VEC2 * dirObj[ idx ].dirCollider.colliderSize + new Vector2( 0, m_bodyCollider.size.y / 2 );
                    dirObj[ idx ].gameObject.name = "Collider_Top";
                    break;
                case DIRECTION.RIGHT:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.RIGHT_VEC2 * dirObj[ idx ].dirCollider.colliderSize + new Vector2( m_bodyCollider.size.x / 2, 0 );
                    dirObj[ idx ].gameObject.name = "Collider_Right";
                    break;
                case DIRECTION.BOTTOM:
                    dirObj[ idx ].gameObject.transform.localPosition = DIRECTION.BOTTOM_VEC2 * dirObj[ idx ].dirCollider.colliderSize - new Vector2( 0, m_bodyCollider.size.y / 2 );
                    dirObj[ idx ].gameObject.name = "Collider_Bottom";
                    break;
                default:
                    break;
            }
        }
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
            Move( dirObj[ DIRECTION.RIGHT ], m_stat.fVEL );
            transform.localScale = Vector3.one;
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            Move( dirObj[ DIRECTION.LEFT ], m_stat.fVEL );
            //transform.localScale = new Vector3( -1, 1, 1 );
        }
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            Move( dirObj[ DIRECTION.TOP ], m_stat.fVEL );
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            Move( dirObj[ DIRECTION.BOTTOM ], m_stat.fVEL );
        }
    }

    void Move( DirObj dirObj, float speed )
    {
        if ( dirObj.dirCollider.bMovable ) transform.position += dirObj.gameObject.transform.localPosition.normalized * speed;
    }

    public void ClearDirObj()
    {
        foreach ( DirObj iter in dirObj )
        {
            iter.dirCollider.bMovable = true;
        }
    }

    public ref UserStat GetUserStat()
    {
        return ref userStat;
    }

    public new void SetName( string sName )
    {
        base.SetName( sName );
        m_bNameSet = true;
    }

    public bool IsNameSet()
    {
        return m_bNameSet;
    }

}
