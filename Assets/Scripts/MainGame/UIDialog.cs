using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialog : UI
{
    private GameObject _dialogObj = null;
    private GameObject _textObj = null;
    private Text _text = null;
    private GameObject _illustObj = null;
    private RawImage _illust = null;

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

    }

    public void SetPosition( Vector2 pos )
    {
        transform.position = pos;
    }

    protected override void MakeComponents()
    {
        // 일러스트
        if (!_illustObj)
        {
            _illustObj = new GameObject();
            _illustObj.transform.SetParent(transform);
            _illustObj.name = "Illust";
            //_illustObj.transform.localPosition = new Vector2( 0, _canvas.pixelRect.height / 2 );
            _illustObj.transform.localPosition = new Vector2(0, 0);
            _illust = _illustObj.AddComponent<RawImage>();
            CustomAnchor(_illust.rectTransform, CUSTOM_ANCHOR.BOTTOM_LEFT);
            // 임시
            SetIllust("Ahri");
        }

        // 대화창
        if ( !_dialogObj )
        {
            GameObject dialogObj = new GameObject();
            dialogObj.transform.SetParent( transform );
            dialogObj.name = "Background";
            dialogObj.transform.localPosition = new Vector2( 0, 0 );
            RawImage dialogImg = dialogObj.AddComponent<RawImage>();
            CustomAnchor( dialogImg.rectTransform, CUSTOM_ANCHOR.BOTTOM );
            dialogImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _canvas.pixelRect.width );
            dialogImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _canvas.pixelRect.height / 2 );
            //dialogImg.texture = Resources.Load("Sprites/Tap and Fly/Sprites/GUI/window_score", typeof(Texture)) as Texture;
            dialogImg.color = new Color( 0.5f, 0.5f, 0.5f, 0.4f );
        }

        // 텍스트
        if ( !_textObj )
        {
            _textObj = new GameObject();
            _textObj.transform.SetParent( transform );
            _textObj.name = "Text";
            _textObj.transform.localPosition = new Vector3( 0, 0, 1 );
            _text = _textObj.AddComponent<Text>();
            CustomAnchor( _text.rectTransform, CUSTOM_ANCHOR.BOTTOM );
            _text.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _canvas.pixelRect.width * 0.9f );
            _text.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _canvas.pixelRect.height * 0.9f / 2 );
            _text.font = Resources.GetBuiltinResource<Font>( "Arial.ttf" );
            _text.fontSize = 40;
            _text.color = new Color( 0, 0, 0 );
            _text.text = "대화창 테스트~~";
        }

    }

    public void SetText( string str )
    {
        if ( _textObj )
        {
            _text.text = str;
        }
    }

    public void SetIllust( string filePath )
    {
        _illust.texture = Resources.Load<Texture>( filePath );
        _illust.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _illust.texture.width * 0.3f );
        _illust.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _illust.texture.height * 0.3f );
    }

}
