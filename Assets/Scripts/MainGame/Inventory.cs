using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int kMaxItemCount = 24;

    public struct Item
    {
        public string name;
    }
    public ArrayList m_aItem = null;

    private void Awake()
    {
        gameObject.name = "Inventory";

        m_aItem = new ArrayList();
        Item item = new Item();
        m_aItem.Add( item );
        m_aItem.Add( item );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
