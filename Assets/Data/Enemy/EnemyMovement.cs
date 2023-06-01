using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : DucHienMonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected Transform enemyModel;  
    [SerializeField] protected float speed = 1f;

    [SerializeField]  private Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyModel();
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    protected virtual void LoadEnemyModel()
    {
        if (this.enemyModel != null) return;
        this.enemyModel = transform.parent.Find("Model");
   
    }


    protected virtual void FixedUpdate()
    {
        this.MovingToPlayer();
       
    }
    protected virtual void MovingToPlayer()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position; // Tính toán hướng từ enemy đến nhân vật
        direction.Normalize(); // Chuẩn hóa hướng thành vector đơn vị

        Vector3 movement = direction * speed * Time.fixedDeltaTime; // Tính toán vector di chuyển dựa trên hướng và tốc độ

        if (direction.x < 0) // Ấn phím A, quay qua trái
        {
            enemyModel.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (direction.x > 0) // Ấn phím D, quay qua phải
        {
            enemyModel.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        transform.parent.Translate(movement); // Di chuyển enemy theo vector di chuyển
    }
    


}
