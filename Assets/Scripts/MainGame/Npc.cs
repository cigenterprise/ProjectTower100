using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Actor
{
    public string Type = "Default";

    public static class TYPEFLAG
    {
        public const int DEFAULT    = 0x00;
        public const int DIALOG     = 0x01;
        public const int COOK       = 0x02;
    }
    int m_typeFlag = TYPEFLAG.DEFAULT;

    new void Awake()
    {
        base.Awake();

        name = "Npc_" + Type;

        m_typeFlag = GetNpcType();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if ( Input.GetKeyDown( KeyCode.Space ) ) SceneControl_MainGame._uiDialogObj.SetActive( false );
    }

    void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( "Actor" ) )
        {
            if ( ( m_typeFlag & TYPEFLAG.DIALOG ) == TYPEFLAG.DIALOG )
            {
                Control_MainGame.m_uiDialog.PopUpDialog( "Tutorial_1.txt" );
            }
            if ( ( m_typeFlag & TYPEFLAG.COOK ) == TYPEFLAG.COOK )
            {
                Control_MainGame.m_uiCookObj.SetActive( true );
            }
        }
    }

    void PopupSlidePuzzle()
    {
        GameObject gameObject = new GameObject();
        gameObject.name = "SlidePuzzle";
        gameObject.AddComponent<SlidePuzzle>();
        gameObject.transform.SetParent( transform.parent );
    }

    int GetNpcType()
    {
        if ( Type.Equals( "Dialog" ) ) return TYPEFLAG.DIALOG;
        if ( Type.Equals( "Cook" ) ) return TYPEFLAG.COOK;

        return TYPEFLAG.DEFAULT;
    }

}
