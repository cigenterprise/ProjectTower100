using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : UI
{
    Dice    m_dice          = null;
    bool    m_bRolling      = false;
    float   m_tElapsed      = 0;
    Text    m_enemyName     = null;
    Text    m_enemyHp       = null;
    Text    m_rollResult    = null;

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
                    Control_MainGame.m_enemy.IncreaseHp( Dice.Value( "" ) );
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
    }

    void MakeButtons( GameObject parentObj )
    {
        Button btnRoll = parentObj.transform.Find( "DiceRoll" ).gameObject.GetComponent<Button>();
        btnRoll.onClick.AddListener(
            delegate
            {
                Roll();
            } );
    }

    void Roll()
    {
        Dice.Clear();

        Vector3 spawnPoint = new Vector3( 0, 0, -7 );

        Dice.Roll( "1d6", "d6-red-dots", spawnPoint, Vector3.zero, 0.5f );

        m_tElapsed = 0;
        m_bRolling = true;
    }

    void UpdateBattleInfo()
    {
        Enemy enemy = Control_MainGame.m_enemy;
        m_enemyName.text = "이름 " + enemy.name;
        m_enemyHp.text = "HP " + enemy._stat.hpCurrent + "/" + enemy._stat.hpMax;
    }
}
