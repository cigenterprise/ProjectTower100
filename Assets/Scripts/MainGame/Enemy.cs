using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    new void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( "Actor" ) )
        {
            Control_MainGame.m_uiBattleObj.GetComponent<UIBattle>().SetEnemy( this );
            Control_MainGame.m_uiBattleObj.SetActive( true );
        }
    }

    void OnTriggerExit2D( Collider2D collision )
    {
        if ( collision.CompareTag( "Actor" ) )
        {
            Control_MainGame.m_uiBattleObj.GetComponent<UIBattle>().SetEnemy( null );
            Control_MainGame.m_uiBattleObj.SetActive( false );
        }
    }

}
