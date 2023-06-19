using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

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
        GetOpenInventory();
    }


    protected virtual void GetMovementInput()
    {
        if (joystick == null) 
            LoadJoystick();
        float horizontal = joystick.Horizontal;
        if (horizontal < 0)
            movementInput = Vector3.left;
        
        else if (horizontal > 0)
            movementInput = Vector3.right;
        else
            movementInput = Vector3.zero;
    }

    public virtual void SetOnJump(bool value)
    {
        this.onJump = value;
    }

    protected virtual void GetOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
             
        }
    }


}
