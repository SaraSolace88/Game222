using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMesh_GA : GameAction
{
    [SerializeField]
    private bool bDisable;
    [SerializeField]
    private MeshRenderer mRenderer;

    public override void Action()
    {
        if(bDisable)
            mRenderer.enabled = false;
        else
            mRenderer.enabled = true;
    }
}
