using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialog : UI
{
    private GameObject  m_textObj       = null;
    private Text        m_text          = null;
    private GameObject  m_illustObj     = null;
    private RawImage    m_illust        = null;
    private bool        m_bActive       = false;
    private bool        m_bSpaceEnabled = true;
    private bool        m_bForcedSkip   = false;

    new void Awake()
    {
        base.Awake();

        gameObject.name = "UIDialog";

        MakeComponents();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( m_bForcedSkip || ( m_bActive && Input.GetKeyDown( KeyCode.Space ) ) )
        {
            m_bForcedSkip = false;

            if ( !m_bSpaceEnabled ) return;
            if ( !NextDialog() ) return;

            Module_Parse.Parse_Dialog.DlgStruct dlgStruct = Control_MainGame.m_parser.parseDialog.GetCurrent().Value;

            if ( dlgStruct.speaker.Equals( "#NameInput" ) ) OnNameInput();
            else if ( dlgStruct.speaker.Equals( "#GiveItem" ) )
            {
                OnGiveItem( dlgStruct.script );
                m_bForcedSkip = true;
            }
            else Speak( dlgStruct );
        }
    }

    public void SetPosition( Vector2 pos )
    {
        transform.position = pos;
    }

    protected override void MakeComponents()
    {
        // 일러스트
        m_illustObj = new GameObject();
        m_illustObj.transform.SetParent( transform );
        m_illustObj.name = "Illust";
        //_illustObj.transform.localPosition = new Vector2( 0, _canvas.pixelRect.height / 2 );
        m_illustObj.transform.localPosition = Vector2.zero;
        m_illust = m_illustObj.AddComponent<RawImage>();
        CustomAnchor( m_illust.rectTransform, CUSTOM_ANCHOR.BOTTOM_LEFT );
        // 임시
        SetIllust( "Ahri" );

        // 대화창
        GameObject dialogObj = new GameObject();
        dialogObj.transform.SetParent( transform );
        dialogObj.name = "Background";
        dialogObj.transform.localPosition = Vector2.zero;
        RawImage dialogImg = dialogObj.AddComponent<RawImage>();
        CustomAnchor( dialogImg.rectTransform, CUSTOM_ANCHOR.BOTTOM );
        dialogImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _canvas.pixelRect.width );
        dialogImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _canvas.pixelRect.height / 2 );
        //dialogImg.texture = Resources.Load("Sprites/Tap and Fly/Sprites/GUI/window_score", typeof(Texture)) as Texture;
        dialogImg.color = new Color( 0.5f, 0.5f, 0.5f, 0.4f );

        // 텍스트
        m_textObj = new GameObject();
        m_textObj.transform.SetParent( transform );
        m_textObj.name = "Text";
        m_textObj.transform.localPosition = new Vector3( 0, 0, 1 );
        m_text = m_textObj.AddComponent<Text>();
        CustomAnchor( m_text.rectTransform, CUSTOM_ANCHOR.BOTTOM );
        m_text.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _canvas.pixelRect.width * 0.9f );
        m_text.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _canvas.pixelRect.height * 0.9f / 2 );
        m_text.font = Resources.Load<Font>( "Fonts/소야곧은10" );
        m_text.fontSize = 40;
        m_text.color = Color.black;
        m_text.text = "대화창 테스트~~";

    }

    public void Speak( Module_Parse.Parse_Dialog.DlgStruct dlgStruct )
    {
        string sSpeaker;

        bool bUser = dlgStruct.speaker.Equals( "??" );
        if ( bUser )
        {
            User user = Control_MainGame.m_user;
            sSpeaker = user.IsNameSet() ? user.m_stat.sName : dlgStruct.speaker;
        }
        else
        {
            sSpeaker = dlgStruct.speaker;
        }

        m_text.text = sSpeaker + ": " + dlgStruct.script;
    }
    
    public void SetIllust( string filePath )
    {
        m_illust.texture = Resources.Load<Texture>( filePath );
        m_illust.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, m_illust.texture.width * 0.3f );
        m_illust.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, m_illust.texture.height * 0.3f );
    }

    public void PopUpDialog( string fileName )
    {
        Control_MainGame.m_parser.ReadFile( "Assets/Resources/Dialog/" + fileName );
        Module_Parse.Parse_Dialog.DlgStruct dlgStruct = Control_MainGame.m_parser.parseDialog.GetCurrent().Value;
        Speak( dlgStruct );
        gameObject.SetActive( true );
        m_bActive = true;
    }

    bool NextDialog()
    {
        bool EOF = !Control_MainGame.m_parser.parseDialog.Next();
        if ( EOF )
        {
            Control_MainGame.m_parser.parseDialog.Clear();
            m_bActive = false;
            gameObject.SetActive( false );
            return false;
        }
        else return true;
    }

    void OnNameInput()
    {
        m_bSpaceEnabled = false;

        GameObject prefabObj = Instantiate( Resources.Load<GameObject>( "UI/Prefab/WndNameInput" ) );
        prefabObj.transform.SetParent( this.transform );
        prefabObj.transform.localPosition = Vector2.zero;

        InputField inputField = prefabObj.transform.Find( "InputField" ).GetComponent<InputField>();
        inputField.onEndEdit.AddListener(
            delegate
            {
                Control_MainGame.m_user.SetName( inputField.text );
                Destroy( prefabObj );

                m_bForcedSkip = true;
                m_bSpaceEnabled = true;
            } );
    }

    void OnGiveItem( string sItem )
    {
        Control_MainGame.m_inventory.AddItem( sItem );
    }

    public override void Refresh()
    {
        
    }

}
