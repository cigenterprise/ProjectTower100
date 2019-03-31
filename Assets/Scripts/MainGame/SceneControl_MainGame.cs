﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl_MainGame : MonoBehaviour
{

    public static Camera _mainCamera = null;
    public static GameObject _uiDialogObj = null;
    public static UIDialog _uiDialog = null;
    public static GameObject _uiMainGameObj = null;
    public static GameObject _userObj = null;
    public static GameObject _uiInvenObj = null;
    public static User _user = null;
    public static Field _field = null;
    public static bool _editMode = false;
    public static TileEditor _tileEditor = null;
    public static Module_Parse parser = null;

    private void Awake()
    {
        // 이름 설정
        gameObject.name = "SceneControl";

        // 카메라 전역설정
        if ( !_mainCamera )
        {
            GameObject cameraObj = new GameObject();
            cameraObj.transform.SetParent( transform );
            cameraObj.name = "MainCamera";
            cameraObj.transform.position = new Vector3( 0, 0, -10 );
            _mainCamera = cameraObj.AddComponent<Camera>();
            _mainCamera.orthographic = true;
            _mainCamera.depth = -1;
            // 오디오 리스너
            AudioListener audioListener = cameraObj.AddComponent<AudioListener>();
        }

        // 대화창 UI
        if ( !_uiDialogObj )
        {
            _uiDialogObj = new GameObject();
            _uiDialogObj.transform.SetParent( transform );
            _uiDialog = _uiDialogObj.AddComponent<UIDialog>();
            _uiDialogObj.SetActive( false );
        }

        // 메인게임 UI
        if ( !_uiMainGameObj )
        {
            _uiMainGameObj = new GameObject();
            _uiMainGameObj.transform.SetParent( transform );
            UIMainGame uiMainGame = _uiMainGameObj.AddComponent<UIMainGame>();
            _uiMainGameObj.SetActive( true );
        }

        if ( !_uiInvenObj )
        {
            _uiInvenObj = new GameObject();
            _uiInvenObj.transform.SetParent( transform );
            UIInventory uiInven = _uiInvenObj.AddComponent<UIInventory>();
            _uiInvenObj.SetActive( false );
        }

        // Field
        GameObject fieldObj = new GameObject();
        fieldObj.transform.SetParent( transform );
        fieldObj.name = "Field";
        _field = fieldObj.AddComponent<Field>();

        // NPC
        GameObject npcObj = new GameObject();
        npcObj.transform.SetParent( transform );
        npcObj.name = "Npc";
        Npc npc = npcObj.AddComponent<Npc>();
        npc.SetPosition( 2, 1 );

        // User
        _userObj = new GameObject();
        _userObj.transform.SetParent( transform );
        _userObj.name = "User";
        _user = _userObj.AddComponent<User>();
        _user.SetPosition( -1, -1 );

        // Parser
        parser = gameObject.AddComponent<Module_Parse>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.I ) ) _uiInvenObj.SetActive( !_uiInvenObj.activeSelf );
    }

}
