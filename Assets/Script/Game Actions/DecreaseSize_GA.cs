using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSize_GA : GameAction
{
    public override void Action()
    {
        transform.localScale = transform.localScale / 2;
    }
}
