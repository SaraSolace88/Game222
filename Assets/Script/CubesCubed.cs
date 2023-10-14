using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubesCubed : MonoBehaviour
{
    private Controls1 playerInput;

    [SerializeField]
    private MeshRenderer ULCube, UCCube, URCube, CLCube, CCube, CRCube, BLCube, BCCube, BRCube;

    [SerializeField]
    private Vector2 direction;

    private bool isGreen;

    void Start()
    {
        playerInput = new Controls1 ();
        playerInput.Enable();

        playerInput.Player.Movement.performed += Pressed;
        playerInput.Player.Movement.canceled += Released;
    }

    private void Pressed(InputAction.CallbackContext c)
    {
        isGreen = true;
    }

    private void Released(InputAction.CallbackContext c)
    {
        isGreen = false;
    }

    private void reset()
    {
        CCube.material.color = Color.grey;
        ULCube.material.color = Color.grey;
        UCCube.material.color = Color.grey;
        URCube.material.color = Color.grey;
        CLCube.material.color = Color.grey;
        CRCube.material.color = Color.grey;
        BLCube.material.color = Color.grey;
        BCCube.material.color = Color.grey;
        BRCube.material.color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = playerInput.Player.Movement.ReadValue<Vector2>().x;
        direction.y = playerInput.Player.Movement.ReadValue<Vector2>().y;
        if (isGreen == true)
        {
            CCube.material.color = Color.grey;
            if (direction.x < 0)
            {
                if (direction.y < 0)
                {
                    reset();
                    BLCube.material.color = Color.green;
                }
                else if (direction.y == 0)
                {
                    reset();
                    CLCube.material.color = Color.green;
                }
                else if (direction.y > 0)
                {
                    reset();
                    ULCube.material.color = Color.green;
                }
            }
            else if (direction.x == 0)
            {
                if (direction.y < 0)
                {
                    reset();
                    BCCube.material.color = Color.green;
                }
                else if (direction.y > 0)
                {
                    reset();
                    UCCube.material.color = Color.green;
                }
            }
            else if (direction.x > 0)
            {
                if (direction.y < 0)
                {
                    reset();
                    BRCube.material.color = Color.green;
                }
                else if (direction.y == 0)
                {
                    reset();
                    CRCube.material.color = Color.green;
                }
                else if (direction.y > 0)
                {
                    reset();
                    URCube.material.color = Color.green;
                }
            }
        }
        else
        {
            CCube.material.color = Color.green;
            ULCube.material.color = Color.grey;
            UCCube.material.color = Color.grey;
            URCube.material.color = Color.grey;
            CLCube.material.color = Color.grey;
            CRCube.material.color = Color.grey;
            BLCube.material.color = Color.grey;
            BCCube.material.color = Color.grey;
            BRCube.material.color = Color.grey;
        }
    }
}
