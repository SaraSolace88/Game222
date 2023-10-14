using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition_GA : GameAction
{
    public override void Action()
    {
        transform.position += new Vector3(5, 5, 0);
    }
}
