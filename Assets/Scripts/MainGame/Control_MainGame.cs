using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_MainGame : MonoBehaviour
{

    public static Camera m_mainCamera = null;
    public static GameObject m_uiDialogObj = null;
    public static UIDialog m_uiDialog = null;
    public static GameObject m_uiMainGameObj = null;
    public static GameObject m_userObj = null;
    public static GameObject m_uiInvenObj = null;
    public static GameObject m_uiCookObj = null;
    public static GameObject m_uiBattleObj = null;
    public static GameObject m_cutSceneObj = null;
    public static User m_user = null;
    public static Field m_field = null;
    public static Inventory m_inventory = null;
    public static bool m_bEditMode = false;
    public static TileEditor m_tileEditor = null;
    public static Module_Parse m_parser = null;

    private void Awake()
    {
        // 이름 설정
        name = "Control";

        // 카메라 전역설정
        GameObject cameraObj = new GameObject();
        cameraObj.transform.SetParent( transform );
        cameraObj.name = "MainCamera";
        cameraObj.transform.position = new Vector3( 0, 0, -20 );
        m_mainCamera = cameraObj.AddComponent<Camera>();
        m_mainCamera.orthographic = true;
        m_mainCamera.depth = -1;
        // 오디오 리스너
        AudioListener audioListener = cameraObj.AddComponent<AudioListener>();

        // 대화창 UI
        m_uiDialogObj = new GameObject();
        m_uiDialogObj.transform.SetParent( transform );
        m_uiDialog = m_uiDialogObj.AddComponent<UIDialog>();
        m_uiDialogObj.SetActive( false );

        // 메인게임 UI
        m_uiMainGameObj = new GameObject();
        m_uiMainGameObj.transform.SetParent( transform );
        UIMainGame uiMainGame = m_uiMainGameObj.AddComponent<UIMainGame>();
        m_uiMainGameObj.SetActive( true );

        // 인벤토리, UI
        GameObject invenObj = new GameObject();
        m_inventory = invenObj.AddComponent<Inventory>();
        invenObj.transform.SetParent( transform );

        m_uiInvenObj = new GameObject();
        m_uiInvenObj.transform.SetParent( transform );
        UIInventory uiInven = m_uiInvenObj.AddComponent<UIInventory>();
        m_uiInvenObj.SetActive( false );

        // 요리 UI
        m_uiCookObj = new GameObject();
        m_uiCookObj.transform.SetParent( transform );
        m_uiCookObj.AddComponent<UICook>();
        m_uiCookObj.SetActive( false );

        // 전투 UI
        m_uiBattleObj = new GameObject();
        m_uiBattleObj.transform.SetParent( transform );
        m_uiBattleObj.AddComponent<UIBattle>();
        m_uiBattleObj.SetActive( false );

        // Field
        GameObject fieldObj = new GameObject();
        fieldObj.transform.SetParent( transform );
        m_field = fieldObj.AddComponent<Field>();

        // User
        m_userObj = new GameObject();
        m_userObj.transform.SetParent( transform );
        m_user = m_userObj.AddComponent<User>();
        m_user.SetPosition( -1, -1 );

        // Parser
        m_parser = gameObject.AddComponent<Module_Parse>();

        // Prologue CutScene
        m_cutSceneObj = new GameObject();
        m_cutSceneObj.transform.SetParent( this.transform );
        m_cutSceneObj.transform.localPosition = Vector2.zero;
        m_cutSceneObj.AddComponent<CutScene>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.I ) ) m_uiInvenObj.SetActive( !m_uiInvenObj.activeSelf );
    }

}
