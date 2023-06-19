using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterMovement : DucHienMonoBehaviour
{
    [SerializeField] protected Transform Model;
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float jumpPower = 4f;
    [SerializeField] protected Vector3 movementInput;
    [SerializeField] protected float limitX = 4f;
    private Animator animator;
    private Rigidbody2D rb;
   


    protected override void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (this.Model != null) return;
        this.Model = transform.parent.Find("Model").transform;
    }

    void Update()
    {
        this.GetMovementInput();
        this.LookAtTarget();
        this.Moving();
        this.UpdateAnimator();
        this.HandleJump();
    }

    protected virtual void GetMovementInput()
    {
        this.movementInput = InputManager.Instance.MovementInput;
    }

    protected virtual void LookAtTarget()
    {
        if (movementInput.x < 0) // Ấn phím A, quay qua trái
        {
            Model.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (movementInput.x > 0) // Ấn phím D, quay qua phải
        {
            Model.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    protected virtual void Moving()
    {
        Vector3 movement = movementInput.normalized * speed;
        Vector3 newPosition = transform.parent.position + movement * Time.deltaTime;

       // if (newPosition.x > limitX || newPosition.x < -limitX) return;
        transform.parent.position = newPosition;
    }

    protected virtual void UpdateAnimator()
    {
        bool isRun = (movementInput.x != 0); // Kiểm tra xem có đang di chuyển (ấn phím A hoặc D) hay không
        animator.SetBool("isRun", isRun);

        if (CharaterImpact.Instance.OnGround) animator.SetBool("isJump", false); 

    }

    protected virtual void HandleJump()
    {
        if (InputManager.Instance.OnJump  && CharaterImpact.Instance.OnGround)
        {
            rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            CharaterImpact.Instance.SetOnGroud(false);
            animator.SetBool("isJump", true);
        }
    }
}
