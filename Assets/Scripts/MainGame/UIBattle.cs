using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : UI
{
    Dice        m_dice                  = null;
    bool        m_bRollStart            = false;
    bool        m_bRolling              = false;
    float       m_tElapsed              = 0;
    Text        m_enemyName             = null;
    Text        m_enemyHp               = null;
    Text        m_rollResult            = null;
    RawImage    m_rollGaugeImg          = null;
    float       m_fRollGaugeWidthLimit  = 0;
    float       m_fRollGauge            = 0;

    const float kGaugeSpeed           = 0.01f;

    new void Awake()
    {
        base.Awake();

        gameObject.name = "UIBattle";

        MakeComponents();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateBattleInfo();
    }

    private void FixedUpdate()
    {
        UpdateRollGauge();

        if ( m_bRolling )
        {
            m_tElapsed += Time.fixedDeltaTime;
            if ( m_bRolling && m_tElapsed >= 4.0f )
            {
                m_bRolling = false;
                if ( Dice.Value( "" ) == 0 )
                {
                    Debug.Log( "Reroll" );
                    Roll();
                }
                else
                {
                    ExecuteRollResult( Dice.Value( "" ) );
                    m_rollResult.text = Dice.AsString( "" );
                    Debug.Log( Dice.AsString( "" ) );
                }

                UpdateBattleInfo();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void MakeComponents()
    {
        GameObject prefabObj = Instantiate( Resources.Load( "UI/Prefab/UIBattle_bg" ) as GameObject );
        prefabObj.transform.SetParent( this.transform );
        prefabObj.transform.localPosition = Vector2.zero;

        m_dice = gameObject.AddComponent<Dice>();

        GameObject virtualGroundObj = Instantiate( Resources.Load( "UI/Prefab/VirtualGround_Dice" ) as GameObject );

        MakeButtons( prefabObj );

        GameObject enemyInfoObj = prefabObj.transform.Find( "BattleInfo" ).gameObject;
        m_enemyName = enemyInfoObj.transform.Find( "EnemyName" ).gameObject.GetComponent<Text>();
        m_enemyHp = enemyInfoObj.transform.Find( "EnemyHP" ).gameObject.GetComponent<Text>();
        m_rollResult = enemyInfoObj.transform.Find( "RollResult" ).gameObject.GetComponent<Text>();

        GameObject rollPowerObj = prefabObj.transform.Find( "RollPower" ).gameObject;
        m_fRollGaugeWidthLimit = rollPowerObj.GetComponent<RectTransform>().rect.width;
        m_rollGaugeImg = rollPowerObj.transform.Find( "Gauge" ).gameObject.GetComponent<RawImage>();
    }

    void MakeButtons( GameObject parentObj )
    {
        Button btnRoll = parentObj.transform.Find( "DiceRollBtn" ).gameObject.GetComponent<Button>();
        btnRoll.onClick.AddListener(
            delegate
            {
                Roll();
            } );
    }

    void Roll()
    {
        if ( !m_bRollStart )
        {
            m_bRollStart = true;
        }
        else
        {
            Dice.Clear();

            Vector3 spawnPoint = new Vector3( 0, 0, -7 );

            Dice.Roll( "1d6", "d6-red-dots", spawnPoint, Vector3.zero, 0.5f );

            m_tElapsed = 0;
            m_bRolling = true;
            m_fRollGauge = 0;
            m_bRollStart = false;
        }
    }

    void UpdateBattleInfo()
    {
        Enemy enemy = Control_MainGame.m_enemy;
        m_enemyName.text = "이름 " + enemy.name;
        m_enemyHp.text = "HP " + enemy.m_stat.fCHP + "/" + enemy.m_stat.fMHP;
    }

    void UpdateRollGauge()
    {
        if ( m_bRollStart )
        {
            m_fRollGauge += kGaugeSpeed;
            if ( m_fRollGauge >= 1.0f ) m_fRollGauge -= 1.0f;
            m_rollGaugeImg.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, m_fRollGaugeWidthLimit * m_fRollGauge );
        }
    }

    void ExecuteRollResult( int nResult )
    {
        float fBaseDamage = Control_MainGame.m_enemy.m_stat.fADB;
        switch ( nResult )
        {
            case 1:
                break;
            case 2:
                Control_MainGame._user.IncreaseHp( fBaseDamage * 0.5f );
                break;
            case 3:
                Control_MainGame._user.IncreaseHp( fBaseDamage );
                break;
            case 4:
                Control_MainGame._user.IncreaseHp( fBaseDamage * 1.2f );
                break;
            case 5:
                Control_MainGame._user.IncreaseHp( fBaseDamage ); // 공격 후 회피 버프 추가해야함
                break;
            case 6:
                // 마법 공격
                break;
        }
    }
}
