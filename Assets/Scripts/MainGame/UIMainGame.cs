﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGame : UI
{
    GameObject hpObj = null;
    GameObject hpBgObj = null;
    RawImage hpImg = null;
    const float kSpaceY = 0.5f;
    const float kHpBarBgWidth = 60;
    const float kHpBarBgHeight = 20;
    const float kHpBarHeight = 10;

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
        
    }

    protected override void MakeComponents()
    {
        // HP 바
        hpObj = new GameObject();
        hpObj.transform.SetParent( transform );
        hpObj.name = "HpBar";
        hpImg = hpObj.AddComponent<RawImage>();
        hpImg.rectTransform.localPosition = new Vector2( 0, 0 );
        hpImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarBgWidth );
        hpImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kHpBarHeight );
        hpImg.color = new Color( 0.5f, 0.0f, 0.0f, 0.7f );

        hpBgObj = new GameObject();
        hpBgObj.transform.SetParent( transform );
        hpBgObj.name = "HpBarBg";
        RawImage hpBgImg = hpBgObj.AddComponent<RawImage>();
        hpBgImg.rectTransform.localPosition = new Vector2( 0, 0 );
        hpBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarBgWidth );
        hpBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kHpBarBgHeight );
        hpBgImg.color = new Color( 1, 1, 1, 0.2f );
    }

}
