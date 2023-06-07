using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shoot
{
    [SerializeField] protected bool shooting = false;
    [SerializeField] protected float shootDelay = 3f;
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
        Vector3 direction = this.GetCharacterPositon() - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet_2, transform.position, rotation);
        if (newBullet == null) return;

        newBullet.GetComponent<BulletCtrl>().SetShooter(transform.parent);
        newBullet.gameObject.SetActive(true);
    }


    protected override void SetShooting()
    {
        this.shooting = true;
    }

    protected virtual Vector3 GetCharacterPositon()
    {
        return CharacterPosition.Instance.CharacterTransform.position;
    }    
}
