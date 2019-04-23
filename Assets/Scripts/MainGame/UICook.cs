using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICook : UI
{
    RawImage    m_inputImg0;
    RawImage    m_inputImg1;
    Text        m_inputText0;
    Text        m_inputText1;
    int         m_nSelectedRecipe = -1;

    class Recipe
    {
        public string   sMaterial0;
        public int      nRequired0;
        public string   sMaterial1;
        public int      nRequired1;
    }
    ArrayList m_aRecipe = new ArrayList();
    
    new void Awake()
    {
        // 임시
        Recipe recipe = new Recipe();
        recipe.sMaterial0 = "MEAT";
        recipe.nRequired0 = 1;
        recipe.sMaterial1 = "EGG";
        recipe.nRequired1 = 5;
        m_aRecipe.Add( recipe );

        base.Awake();

        gameObject.name = "UICook";

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
        GameObject prefabObj = Instantiate( Resources.Load( "UI/Prefab/UICook_bg" ) as GameObject );
        prefabObj.transform.SetParent( this.transform );
        prefabObj.transform.localPosition = Vector2.zero;

        MakeButtons( prefabObj );
    }

    void MakeButtons( GameObject parentObj )
    {
        GameObject recipeListObj = parentObj.transform.Find( "Recipe" ).gameObject;
        GameObject materialObj = parentObj.transform.Find( "Material" ).gameObject;

        m_inputImg0 = materialObj.transform.Find( "Input0" ).GetComponent<RawImage>();
        m_inputImg1 = materialObj.transform.Find( "Input1" ).GetComponent<RawImage>();
        m_inputText0 = materialObj.transform.Find( "Input0_Text" ).GetChild( 0 ).GetComponent<Text>();
        m_inputText1 = materialObj.transform.Find( "Input1_Text" ).GetChild( 0 ).GetComponent<Text>();

        for ( int idx = 0; idx < recipeListObj.transform.childCount; ++idx )
        {
            GameObject obj = recipeListObj.transform.GetChild( idx ).gameObject;
            Button btn = obj.GetComponent<Button>();
            int idxByValue = idx;
            btn.onClick.AddListener(
                delegate
                {
                    LoadRecipe( idxByValue );
                } );
        }

        GameObject outputObj = materialObj.transform.Find( "Output" ).gameObject;
        Button outputBtn = outputObj.GetComponent<Button>();
        outputBtn.onClick.AddListener(
            delegate
            {
                Cook( m_nSelectedRecipe );
            } );
    }

    void LoadRecipe( int recipeIdx )
    {
        Recipe recipe = null;
        if ( m_aRecipe.Count > recipeIdx ) recipe = m_aRecipe[ recipeIdx ] as Recipe;
        else
        {
            Debug.Log( "Recipe index out of bound" );
            return;
        }

        int nMaterial0 = Control_MainGame.m_inventory.FindItems( recipe.sMaterial0 );
        int nMaterial1 = Control_MainGame.m_inventory.FindItems( recipe.sMaterial1 );

        m_inputText0.text = $"필요 수량 {recipe.nRequired0}\n보유 수량 {nMaterial0}";
        m_inputText1.text = $"필요 수량 {recipe.nRequired1}\n보유 수량 {nMaterial1}";

        m_nSelectedRecipe = recipeIdx;
    }

    void Cook( int recipeIdx )
    {
        if ( recipeIdx == -1 ) return;

        Recipe recipe = null;
        if ( m_aRecipe.Count > recipeIdx ) recipe = m_aRecipe[ recipeIdx ] as Recipe;
        else
        {
            Debug.Log( "Recipe index out of bound" );
            return;
        }

        int nMaterial0 = Control_MainGame.m_inventory.FindItems( recipe.sMaterial0 );
        int nMaterial1 = Control_MainGame.m_inventory.FindItems( recipe.sMaterial1 );

        if ( recipe.nRequired0 > nMaterial0 || recipe.nRequired1 > nMaterial1 )
        {
            Debug.Log( "Insufficient materials" );
            // 재료부족
            return;
        }

        for ( int iter = 0; iter < recipe.nRequired0; ++iter )
            Control_MainGame.m_inventory.RemoveItem( recipe.sMaterial0 );
        for ( int iter = 0; iter < recipe.nRequired1; ++iter )
            Control_MainGame.m_inventory.RemoveItem( recipe.sMaterial1 );
    }
}
