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

    [SerializeField] protected float onShooting;
    public float OnShooting { get { return this.onShooting; } }

    [SerializeField] protected bool isJumping;
    public bool IsJumping { get { return this.isJumping; } }

    InventoryData inventoryData;
    private void Awake()
    {
        if (InputManager.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        InputManager.instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        GetMovementInput();
        GetMouseDown();
        GetJumpInput();
        GetOpenInventory();
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
        movementInput = new Vector3(moveHorizontal, 0f, moveVertical);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
        this.onShooting = Input.GetAxis("Fire2");
    }

    protected virtual void GetJumpInput()
    {
        this.isJumping = Input.GetKeyDown(KeyCode.Space);
    }

    protected virtual void GetOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
        }
    }
}
