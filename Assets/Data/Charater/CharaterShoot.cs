﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterShoot : Shoot
{
    [SerializeField] protected bool shooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;


    protected override void Shooting()
    {
        if (this.shootTimer < this.shootDelay)
        {
            this.shootTimer += Time.fixedDeltaTime;
            return;
        }    
        if (!this.shooting) return;
        this.shootTimer = 0f;

        // Tính toán góc giữa đối tượng bắn và vị trí chuột
        Vector3 direction = this.GetPositionEnemyNearest() - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, transform.position, rotation);
        if (newBullet == null) return;

        newBullet.GetComponent<BulletCtrl>().SetShooter(transform.parent);
        newBullet.gameObject.SetActive(true);
    }


    protected override void SetShooting()
    {
        this.UpdateDelay();
        if (EnemySpawner.Instance == null) return;
        EnemySpawner.Instance.UpdateEnemies();
        if (GetPositionEnemyNearest () == Vector3.zero)
        {
            this.shooting = false;
            return;
        }
        this.shooting = true;
    }


    protected virtual Vector3 GetPositionEnemyNearest()
    {
        if (EnemySpawner.Instance == null) return Vector3.zero;
        // Lấy danh sách enemy
        List<Transform> enemies = EnemySpawner.Instance.Enemies;

        // Nếu không có enemy nào thì trả về Vector3.zero
        if (enemies.Count == 0) return Vector3.zero;
        Vector3 targetPosition = Vector3.zero;

        // Tìm enemy gần nhất

        float minDistance = float.MaxValue;
        foreach (Transform enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetPosition = enemy.position;
            }
        }

        return targetPosition;
    }    

    protected virtual void UpdateDelay()
    {
        this.shootDelay = 1f * 100 / PlayerCtrl.Instance.Status.AttackSpeed;
    }

}
