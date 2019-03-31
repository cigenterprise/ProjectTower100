﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UI
{
    const float kSlotWidth = 50.0f;
    const float kSlotHeight = 50.0f;
    const float kSlotGap = 5.0f;
    const int   kSlotNumRow = 6;
    const int   kSlotNumCol = 4;

    new void Awake()
    {
        base.Awake();

        gameObject.name = "UIInventory";

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
        // 배경
        GameObject bgObj = new GameObject();
        bgObj.transform.SetParent( transform );
        bgObj.name = "Background";
        bgObj.transform.localPosition = new Vector2( 0, 0 );
        RawImage bgImg = bgObj.AddComponent<RawImage>();
        bgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, ( kSlotWidth + kSlotGap ) * kSlotNumCol + kSlotGap );
        bgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, ( kSlotHeight + kSlotGap ) * kSlotNumRow + kSlotGap );
        bgImg.color = new Color( 0.5f, 0.5f, 0.5f, 0.4f );

        // 슬롯
        GameObject slotRootObj = new GameObject();
        slotRootObj.transform.SetParent( transform );
        slotRootObj.name = "Slot";
        RectTransform slotRootRect = slotRootObj.AddComponent<RectTransform>();
        slotRootObj.transform.localPosition = new Vector2( 0, 0 );
        slotRootRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, ( kSlotWidth + kSlotGap ) * kSlotNumCol + kSlotGap );
        slotRootRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, ( kSlotHeight + kSlotGap ) * kSlotNumRow + kSlotGap );

        for ( int x = 0; x < kSlotNumCol; ++x )
        {
            for ( int y = 0; y < kSlotNumRow; ++y )
            {
                GameObject slotObj = new GameObject();
                slotObj.transform.SetParent( slotRootObj.transform );
                slotObj.transform.localPosition = new Vector2( ( kSlotWidth + kSlotGap ) * x + kSlotGap, ( kSlotHeight + kSlotGap ) * y + kSlotGap );
                RawImage slotImg = slotObj.AddComponent<RawImage>();
                CustomAnchor( slotImg.rectTransform, CUSTOM_ANCHOR.BOTTOM_LEFT );
                slotImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kSlotWidth );
                slotImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kSlotHeight );
                slotImg.color = new Color( 0.0f, 0.0f, 0.5f, 0.4f );
            }
        }
    }

}