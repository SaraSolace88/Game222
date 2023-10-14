using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    //reference to projectile prefab
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireRate = 0.1f;

    private Controls1 pInput;
    private bool bFireOn, bActive;


    private void Start()
    {
        pInput = new Controls1();
        pInput.Enable();
        bActive = true;
        StartCoroutine(nameof(PerpetualFiring));
        pInput.Player.Fire.performed += FireOn;
        pInput.Player.Fire.canceled += FireOff;
    }

    private void OnDisable()
    {
        pInput.Player.Fire.performed -= FireOn;
        pInput.Player.Fire.canceled -= FireOff;
        pInput.Disable();
    }
    private void FireOn(InputAction.CallbackContext c)
    {
        bFireOn = true;
    }
    private void FireOff(InputAction.CallbackContext c)
    {
        bFireOn = false;
    }

    private void FireShot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
    IEnumerator PerpetualFiring()
    {
        while (bActive)
        {
            yield return new WaitForEndOfFrame();
            if (bFireOn)
            {
                yield return new WaitForSeconds(fireRate);
                FireShot();
            }
        }
    }
    //get input

    //spawn object

}
