using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToggle_GA : GameAction
{
    [SerializeField]
    private bool bDisable;
    [SerializeField]
    private GameObject gObject;

    public override void Action()
    {
        if(bDisable)
            gObject.SetActive(false);
        else
            gObject.SetActive(true);
    }
}
