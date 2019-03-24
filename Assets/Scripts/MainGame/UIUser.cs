using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUser : UI
{

    public User user = null;
    GameObject hpObj = null;
    GameObject hpBgObj = null;
    RawImage hpImg = null;
    const float kSpaceY = 0.5f;
    const float kHpBarBgWidth = 60;
    const float kHpBarBgHeight = 20;
    const float kHpBarHeight = 10;

    new void Awake()
    {
        base.Awake();

        gameObject.name = "UIUser";

        MakeComponents();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpObj.transform.position = SceneControl_MainGame._mainCamera.WorldToScreenPoint( user.transform.position + new Vector3( 0, kSpaceY, 0 ) );
        hpBgObj.transform.position = SceneControl_MainGame._mainCamera.WorldToScreenPoint( user.transform.position + new Vector3( 0, kSpaceY, 0 ) );
        hpImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarBgWidth * user._stat.hpCurrent / user._stat.hpMax );
    }

    protected override void MakeComponents()
    {
        hpObj = new GameObject();
        hpObj.transform.SetParent(transform);
        hpObj.name = "HpBar";
        hpImg = hpObj.AddComponent<RawImage>();
        hpImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, kHpBarBgWidth );
        hpImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, kHpBarHeight );
        //hpImg.texture = Resources.Load("Sprites/Tap and Fly/Sprites/GUI/window_score", typeof(Texture)) as Texture;
        hpImg.color = new Color(0.5f, 0.0f, 0.0f, 0.7f);

        hpBgObj = new GameObject();
        hpBgObj.transform.SetParent( transform );
        hpBgObj.name = "HpBarBg";
        RawImage hpBgImg = hpBgObj.AddComponent<RawImage>();
        hpBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, kHpBarBgWidth );
        hpBgImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, kHpBarBgHeight );
        //bgImg.texture = Resources.Load("Sprites/Tap and Fly/Sprites/GUI/window_score", typeof(Texture)) as Texture;
        hpBgImg.color = new Color( 1, 1, 1, 0.2f );
    }

    public void SetUser(User user)
    {
        this.user = user;
    }

}
