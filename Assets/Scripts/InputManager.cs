using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    [SerializeField] protected Vector3 movementInput;
    public Vector3 MovementInput { get { return this.movementInput; } }

    [SerializeField] protected float onFiring;
    public float OnFiring { get { return this.onFiring; } }

    private void Awake()
    {
        if (InputManager.instance != null)
        {
            Debug.LogError("There is more than one InputManager in the scene!");
        }
        InputManager.instance = this;
    }

    void Update()
    {
        GetMovementInput();
        GetMouseDown();
    }

    protected virtual void GetMovementInput()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1f;
        }

        movementInput = new Vector3(moveHorizontal, 0f, moveVertical);
    }


    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
