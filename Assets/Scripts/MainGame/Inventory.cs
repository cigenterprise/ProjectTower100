using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int kMaxItemCount = 24;

    public class Item
    {
        public string sName;
    }
    public ArrayList m_aItem = null;

    private void Awake()
    {
        gameObject.name = "Inventory";

        m_aItem = new ArrayList();
        AddItem( null );
        AddItem( null );
        AddItem( "MEAT" );
        AddItem( "CHICKEN" );
        AddItem( "CHICKEN" );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem( string sItem )
    {
        bool bSuccess = false;

        if ( m_aItem.Count < kMaxItemCount )
        {
            Item item = new Item();
            item.sName = sItem;
            m_aItem.Add( item );

            bSuccess = true;
        }

        return bSuccess;
    }

    public bool RemoveItem( string sItem )
    {
        for ( int idx = 0; idx < m_aItem.Count; ++idx )
        {
            Item item = m_aItem[ idx ] as Item;
            if ( sItem.Equals( item.sName ) )
            {
                m_aItem.RemoveAt( idx );
                return true;
            }
        }

        return false;
    }

    public int FindItems( string sItem )
    {
        int nCount = 0;
        foreach ( Item item in m_aItem )
        {
            if ( sItem.Equals( item.sName ) ) ++nCount;
        }

        return nCount;
    }
}
