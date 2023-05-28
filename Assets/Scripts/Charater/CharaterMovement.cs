using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected Vector3 movementInput;
    private Animator animator;

    private void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
    }
    void Update()
    {
        this.GetMovementInput();
        this.LookAtTarget();
        this.Moving();
        this.UpdateAnimator();
    }

    protected virtual void GetMovementInput()
    {
        this.movementInput = InputManager.Instance.MovementInput;
    }

    protected virtual void LookAtTarget()
    {
        if (movementInput.x < 0) // Ấn phím A, quay qua trái
        {
            transform.parent.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (movementInput.x > 0) // Ấn phím D, quay qua phải
        {
            transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }



    protected virtual void Moving()
    {
        Vector3 movement = movementInput.normalized * speed;
        Vector3 newPosition = transform.parent.position + movement * Time.deltaTime;
        transform.parent.position = newPosition;
    }

    protected virtual void UpdateAnimator()
    {
        bool isRun = (movementInput.x != 0); // Kiểm tra xem có đang di chuyển (ấn phím A hoặc D) hay không
        animator.SetBool("isRun", isRun);
    }

}
