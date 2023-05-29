using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterShoot : MonoBehaviour
{
    [SerializeField] protected bool shooting = false;
    [SerializeField] protected float shootDelay = 0.5f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform bulletPrefab;

    void Update()
    {
        this.SetShooting();
        //this.Shoot();
    }
    void FixedUpdate()
    {
        this.Shoot();
    }

    protected virtual void Shoot()
    {
        if (!this.shooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        // Lấy vị trí chuột trên màn hình
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Khoảng cách từ Camera đến mặt phẳng màn hình

        // Chuyển đổi vị trí chuột từ không gian màn hình sang không gian thế giới
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Tính toán góc giữa đối tượng bắn và vị trí chuột
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, transform.position, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
    }


    protected virtual void SetShooting()
    {
        this.shooting = InputManager.Instance.OnShooting == 1;
        Debug.Log(shooting);
    }

}
