using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    Image m_background;
    Text m_text;
    bool m_bFadeout = false;

    void Awake()
    {
        name = "CutScene";

        GameObject prefabObj = Instantiate( Resources.Load( "CutScene/Cut0" ) as GameObject );
        prefabObj.transform.SetParent( this.transform );

        m_background = prefabObj.transform.Find( "Background" ).GetComponent<Image>();
        m_text = prefabObj.transform.Find( "Text" ).GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) ) m_bFadeout = true;

        if ( !m_bFadeout ) return;

        Color colorBg = m_background.color;
        colorBg.a -= 0.01f;
        m_background.color = colorBg;

        Color colorText = m_text.color;
        colorText.a -= 0.01f;
        m_text.color = colorText;

        if ( colorBg.a < 0 && colorText.a < 0 ) Destroy( gameObject );
    }
}
