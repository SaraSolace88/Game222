using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]

public class IncrementColor_GA : GameAction
{
    private MeshRenderer mRenderer;

    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
    }

    public override void Action()
    {
        Vector4 tempColor = mRenderer.material.color;

        tempColor.x += 0.1f;
        mRenderer.material.color = tempColor;
    }
}
