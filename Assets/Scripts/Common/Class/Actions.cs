using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions
{
    public Vector2Int nextPlayerPosition;
    public WorldType nextWorldType;

    public Actions(Vector2Int nextPlayerPosition, WorldType nextWorldType)
    {
        this.nextPlayerPosition = nextPlayerPosition;
        this.nextWorldType = nextWorldType;
    }
    
}
