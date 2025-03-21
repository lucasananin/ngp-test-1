using System.Collections.Generic;
using UnityEngine;

public class DAOs
{
}

[System.Serializable]
public class ItemDAO
{
    public string so_id = null;
    public int amount = 0;
}

[System.Serializable]
public class ItemListDAO
{
    public List<ItemDAO> itemDAOs = new List<ItemDAO>();
}
