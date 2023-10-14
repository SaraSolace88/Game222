using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject_GA : GameAction
{
    public override void Action()
    {
        Destroy(gameObject);
    }
}
