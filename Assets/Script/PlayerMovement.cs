using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Needed for delegates or InputEvents or classes

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 constraints;
    //direction
    [SerializeField]
    private Vector3 direction;
    //speed
    [SerializeField]
    private float speed = 10, Bspeed = 20;
    private bool BspeedBoost;
    private Controls1 playerInput;

    [SerializeField]
    private MeshRenderer mRenderer;

    void Start()
    {
        SpeedBoost_GA.SpeedBoostOn += SpeedBoostOn;
        SpeedBoost_GA.SpeedBoostOff += SpeedBoostOff;
        if (mRenderer)
        mRenderer.material.color = Color.green;

        playerInput = new Controls1();
        playerInput.Enable();

        playerInput.Player.Sprint.performed += Pressed;
        playerInput.Player.Sprint.canceled += Released;

    }

    private void OnDisable()
    {
        SpeedBoost_GA.SpeedBoostOn -= SpeedBoostOn;
        SpeedBoost_GA.SpeedBoostOff -= SpeedBoostOff;//
        playerInput.Player.Sprint.performed -= Pressed;
        playerInput.Player.Sprint.canceled -= Released;
        playerInput.Disable();
    }
    private void SpeedBoostOn() { BspeedBoost = true; }
    private void SpeedBoostOff() { BspeedBoost = false; }
    private void Pressed(InputAction.CallbackContext c)
    {
        BspeedBoost = true;
    }

    private void Released(InputAction.CallbackContext c)
    {
        BspeedBoost = false;
    }

    void Update()
    {
        direction.x = playerInput.Player.Movement.ReadValue<Vector2>().x;
        direction.y = playerInput.Player.Movement.ReadValue<Vector2>().y;
        direction.z = 0;

        if (BspeedBoost)
            transform.localPosition += direction * Bspeed * Time.deltaTime;
        else
            transform.localPosition += direction * speed * Time.deltaTime; //Time.deltaTime controls speed at what things happen based on framerate.
        ConstrainMovement();
    }

    private void ConstrainMovement()
    {
        Vector3 currentPosition = transform.localPosition; //<Remember Local Position

        //Upper constraint
        if (currentPosition.y >= constraints.y)
            currentPosition.y = constraints.y;
        //Lower constraint
        else if (currentPosition.y <= -constraints.y)
            currentPosition.y = -constraints.y;
        //Right constraint
        else if(currentPosition.x >= constraints.x)
            currentPosition.x = constraints.x;
        //Left constraint
        else if(currentPosition.x <= -constraints.x)
            currentPosition.x = -constraints.x;

        currentPosition.z = constraints.z;

        transform.localPosition = currentPosition;
    }
}



//Normalizing makes so the Vector stays the same no matter what direction. AKA diagonal moving doesn't make you move faster. Instead of square, circle.