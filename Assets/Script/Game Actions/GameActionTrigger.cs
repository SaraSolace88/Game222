using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionTrigger : MonoBehaviour
{
    [SerializeField]
    private List<GameAction> gAction;
    private bool bActive;

    //physics driven event that requires at least one object to have a rigidbody
    private void OnTriggerEnter(Collider other)
    {
        if (bActive) return; //stops execution of the corountine if its already running.
        StartCoroutine(nameof(DelayAction));
    }

    IEnumerator DelayAction()
    {
        bActive = true;
        foreach (GameAction item in gAction)
        {
            yield return new WaitForSeconds(item.delay);
            item.Action();
        }
        bActive = false;
    }
}
