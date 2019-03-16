using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGame : UI
{
    public static Button _buttonEditMode = null;
    public static Text _textEditMode = null;

    new void Awake()
    {
        base.Awake();

        gameObject.name = "UIMainGame";

        MakeComponents();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.A ) ) Debug.Log( "HAWI" );
    }

    protected override void MakeComponents()
    {
        // 맵 에디터 모드 버튼

        // 버튼 오브젝트
        GameObject editModeButtonObj = new GameObject();
        editModeButtonObj.transform.SetParent( transform );
        editModeButtonObj.name = "Button_EditMode";
        editModeButtonObj.AddComponent<RectTransform>();
        editModeButtonObj.transform.localPosition = new Vector3( -_canvas.pixelRect.width / 2 * 0.9f, _canvas.pixelRect.height / 2 * 0.9f );

        // Button
        GameObject buttonObj = new GameObject();
        buttonObj.transform.SetParent( editModeButtonObj.transform );
        buttonObj.name = "Button";
        buttonObj.transform.localPosition = new Vector2( 0, 0 );
        _buttonEditMode = buttonObj.AddComponent<Button>();
        _buttonEditMode.image = buttonObj.AddComponent<Image>();
        _buttonEditMode.image.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 40 );
        _buttonEditMode.onClick.AddListener( ToggleEditMode );

        // Text
        GameObject textObj = new GameObject();
        textObj.transform.SetParent( buttonObj.transform );
        textObj.name = "Text";
        textObj.transform.localPosition = new Vector2( 0, 0 );
        _textEditMode = textObj.AddComponent<Text>();
        _textEditMode.font = Resources.GetBuiltinResource<Font>( "Arial.ttf" );
        _textEditMode.fontSize = 12;
        _textEditMode.color = new Color( 0, 0, 0 );
        _textEditMode.text = "편집모드 활성화";
        _textEditMode.alignment = TextAnchor.MiddleCenter;
        //버튼 이미지
        //_buttonEditMode.image.sprite = Resources.GetBuiltinResource<Sprite>("UISprite");
    }

    void ToggleEditMode()
    {
        SceneControl_MainGame._editMode = !SceneControl_MainGame._editMode;
        if ( SceneControl_MainGame._editMode )
        {
            Debug.Log( "편집모드 활성화됨" );
            _textEditMode.text = "편집모드 비활성화";
            SceneControl_MainGame._tileEditor.ToggleEditMode( true );
        }
        else
        {
            Debug.Log( "편집모드 비활성화됨" );
            _textEditMode.text = "편집모드 활성화";
            SceneControl_MainGame._tileEditor.ToggleEditMode( false );
        }
    }
}
