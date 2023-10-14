using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedBoost_GA : GameAction
{
    private float speedBoostDuration = 2;
    public static Action SpeedBoostOn = delegate { };
    public static Action SpeedBoostOff = delegate { };

    private bool bActive;
    public override void Action()
    {
        Debug.Log("erae");
        if (bActive) return;
        
        SpeedBoostOn();
        StartCoroutine(nameof(SpeedBoostOffDelay));
    }
    IEnumerator SpeedBoostOffDelay()
    {
        bActive= true;
        yield return new WaitForSeconds(speedBoostDuration);
        SpeedBoostOff();
        bActive= false;
    }
}
