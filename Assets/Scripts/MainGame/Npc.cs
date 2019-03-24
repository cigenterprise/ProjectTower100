using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Actor
{

    public static class TYPEFLAG
    {
        public const int DEFAULT = 0x00;
        public const int DIALOG = 0x01;
    }
    int _typeFlag = TYPEFLAG.DEFAULT;

    new void Awake()
    {
        base.Awake();

        _typeFlag = TYPEFLAG.DIALOG;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) ) SceneControl_MainGame._uiDialogObj.SetActive( false );
    }

    void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( "Actor" ) && ( _typeFlag & TYPEFLAG.DIALOG ) == TYPEFLAG.DIALOG ) PopupDialog( "POPUP!!\n\n(Press space-bar to close)" );
    }

    void PopupSlidePuzzle()
    {
        GameObject gameObject = new GameObject();
        gameObject.name = "SlidePuzzle";
        gameObject.AddComponent<SlidePuzzle>();
        gameObject.transform.SetParent( transform.parent );
    }

    void PopupDialog( string str )
    {
        SceneControl_MainGame._uiDialogObj.GetComponent<UIDialog>().SetText( str );
        SceneControl_MainGame._uiDialogObj.SetActive( true );
    }

}
