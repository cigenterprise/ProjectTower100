using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGame : UI
{
    RawImage m_hpImg = null;

    const float kHpBarOffsetX = 50.0f;
    const float kHpBarOffsetY = -10.0f;
    const float kHpBarBgWidth = 120.0f;
    const float kHpBarBgHeight = 40.0f + kBarGap;
    const float kHpBarWidth = kHpBarBgWidth - kBarInternalOffsetX * 2.0f;
    const float kHpBarHeight = 10.0f;
    const float kHungerBarHeight = 10.0f;
    const float kBarGap = 2.0f;
    const float kBarInternalOffsetX = 5.0f;
    const float kBarInternalOffsetY = -( kHpBarBgHeight - kHpBarHeight - kHungerBarHeight - kBarGap ) * 0.5f;

    const float kCurrencyOffsetX = 200.0f;
    const float kCurrencyOffsetY = -10.0f;
    const float kCurrencyBgWidth = 120.0f;
    const float kCurrencyBgHeight = 40.0f;
    const float kCurrencyImgOffsetX = 10.0f;
    const float kCurrencyImgOffsetY = -10.0f;
    const float kCurrencyImgWidth = 20.0f;
    const float kCurrencyImgHeight = 20.0f;
    const float kCurrencyTextOffsetX = 60.0f;
    const float kCurrencyTextOffsetY = -10.0f;
    const float kCurrencyTextWidth = 50.0f;
    const float kCurrencyTextHeight = 20.0f;

    private Text currencyText = null;

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

    private void FixedUpdate()
    {
        ref User.UserStat userStat = ref Control_MainGame._user.GetUserStat();
        userStat.currency++;
        currencyText.text = userStat.currency.ToString();

        UpdateHpBar();
    }

    protected override void MakeComponents()
    {
        // HP, 배고픔 바 배경
        GameObject hpBgObj = new GameObject();
        hpBgObj.name = "HpBarBg";
        hpBgObj.transform.SetParent( transform );
        RawImage hpBgImg = hpBgObj.AddComponent<RawImage>();
        hpBgImg.rectTransform.localPosition = new Vector2( kHpBarOffsetX, kHpBarOffsetY );
        CustomAnchor( hpBgImg.rectTransform, CUSTOM_ANCHOR.TOP_LEFT );
        hpBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarBgWidth );
        hpBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kHpBarBgHeight );
        hpBgImg.color = new Color( 1, 1, 1, 0.8f );

        // HP 바
        GameObject hpObj = new GameObject();
        hpObj.name = "HpBar";
        hpObj.transform.SetParent( transform );
        m_hpImg = hpObj.AddComponent<RawImage>();
        m_hpImg.rectTransform.localPosition = new Vector2( kHpBarOffsetX + kBarInternalOffsetX, kHpBarOffsetY + kBarInternalOffsetY );
        CustomAnchor( m_hpImg.rectTransform, CUSTOM_ANCHOR.TOP_LEFT );
        m_hpImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarWidth );
        m_hpImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kHpBarHeight );
        m_hpImg.color = new Color( 0.5f, 0.0f, 0.0f, 0.7f );

        // 배고픔 바
        GameObject hungerObj = new GameObject();
        hungerObj.name = "HungerBar";
        hungerObj.transform.SetParent( transform );
        RawImage hungerImg = hungerObj.AddComponent<RawImage>();
        hungerImg.transform.localPosition = new Vector2( kHpBarOffsetX + kBarInternalOffsetX, kHpBarOffsetY - kHpBarHeight - kBarGap + kBarInternalOffsetY );
        CustomAnchor( hungerImg.rectTransform, CUSTOM_ANCHOR.TOP_LEFT );
        hungerImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarWidth );
        hungerImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kHungerBarHeight );
        hungerImg.color = new Color( 0.5f, 0.3f, 0.0f, 0.7f );

        // 재화 창 배경
        GameObject currencyObj = new GameObject();
        currencyObj.name = "CurrencyBg";
        currencyObj.transform.SetParent( transform );
        RawImage currencyBgImg = currencyObj.AddComponent<RawImage>();
        currencyBgImg.transform.localPosition = new Vector2( kCurrencyOffsetX, kCurrencyOffsetY );
        CustomAnchor( currencyBgImg.rectTransform, CUSTOM_ANCHOR.TOP_LEFT );
        currencyBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kCurrencyBgWidth );
        currencyBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kCurrencyBgHeight );
        currencyBgImg.color = new Color( 1, 1, 1, 0.8f );

        // 재화 이미지
        GameObject currencyImgObj = new GameObject();
        currencyImgObj.name = "CurrencyImg";
        currencyImgObj.transform.SetParent( transform );
        RawImage currencyImg = currencyImgObj.AddComponent<RawImage>();
        currencyImg.transform.localPosition = new Vector2( kCurrencyOffsetX + kCurrencyImgOffsetX, kCurrencyOffsetY + kCurrencyImgOffsetY );
        CustomAnchor( currencyImg.rectTransform, CUSTOM_ANCHOR.TOP_LEFT );
        currencyImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kCurrencyImgWidth );
        currencyImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kCurrencyImgHeight );
        currencyImg.color = new Color( 0.2f, 0.2f, 0.2f, 0.5f );

        GameObject currencyTextObj = new GameObject();
        currencyTextObj.name = "CurrencyText";
        currencyTextObj.transform.SetParent( transform );
        currencyText = currencyTextObj.AddComponent<Text>();
        currencyText.transform.localPosition = new Vector2( kCurrencyOffsetX + kCurrencyTextOffsetX, kCurrencyOffsetY + kCurrencyTextOffsetY );
        CustomAnchor( currencyText.rectTransform, CUSTOM_ANCHOR.TOP_LEFT );
        currencyText.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kCurrencyTextWidth );
        currencyText.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kCurrencyTextHeight );
        currencyText.font = Resources.GetBuiltinResource<Font>( "Arial.ttf" );
        currencyText.fontSize = 16;
        currencyText.color = new Color( 0, 0, 0 );
        currencyText.text = 0.ToString();
    }

    void UpdateHpBar()
    {
        User.Stat stat = Control_MainGame._user.m_stat;
        m_hpImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarWidth * stat.fCHP / stat.fMHP );
    }

}
