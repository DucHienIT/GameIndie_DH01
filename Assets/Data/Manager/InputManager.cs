using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : DucHienMonoBehaviour
{

    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    [SerializeField] protected Vector3 movementInput;
    public Vector3 MovementInput { get { return this.movementInput; } }

    [SerializeField] protected float onFiring;
    public float OnFiring { get { return this.onFiring; } }

    [SerializeField] protected float onShooting;
    public float OnShooting { get { return this.onShooting; } }

    [SerializeField] protected bool onJump;
    public bool OnJump => onJump;

    [SerializeField] protected Joystick joystick;

    InventoryData inventoryData;
    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        InputManager.instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJoystick();
    }
    protected virtual void LoadJoystick()
    {
        if (this.joystick != null) return;
        this.joystick = FindObjectOfType<Joystick>();
    }
    void Update()
    {
        GetMovementInput();
        GetMouseDown();
        GetOpenInventory();
    }


    protected virtual void GetMovementInput()
    {
        if (joystick == null) 
            LoadJoystick();
        float horizontal = joystick.Horizontal;
        if (horizontal < 0)
        {
            movementInput = Vector3.left;
            GetOnJump();
        }    
        else if (horizontal > 0)
        {
            GetOnJump();
            movementInput = Vector3.right;
        } 
        else
        {
            this.onJump = false;
            movementInput = Vector3.zero;
        }    
    }

    protected virtual void GetOnJump()
    {
        if (joystick.Vertical > 0)
            this.onJump = true;
        else
            this.onJump = false;
    }

    protected virtual void GetMouseDown()
    {
        //this.onFiring = Input.GetAxis("Fire1");
        //this.onShooting = Input.GetAxis("Fire2");
    }

    protected virtual void GetOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
             
        }
    }


}
