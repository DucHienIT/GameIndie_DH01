
using System.Collections.Generic;
using UnityEngine;
public class EquipCtrl : DucHienMonoBehaviour
{
    
    [SerializeField] protected WeaponSO weaponSO;
    public WeaponSO WeaponSO { get { return weaponSO; } }

    private bool isFlip = false;

    protected virtual void FixedUpdate()
    {
        this.ResetPosition();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySO();
    }
    protected virtual void LoadEnemySO()
    {
        if (this.weaponSO != null) return;
        string path = "Weapon/" + transform.name;
        this.weaponSO = Resources.Load<WeaponSO>(path);
    }
    protected virtual void ResetPosition()
    {
        if (this.transform.localPosition != Vector3.zero)
            this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = UpdateQuaternionEquipment();
    }

    protected virtual Quaternion UpdateQuaternionEquipment()
    {
        Vector3 direction = GetPositionEnemyNearest() - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (direction.x < 0)
        {   
            if(isFlip) return rotation;
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y) * -1;
            transform.localScale = scale;
            isFlip = true;
        }
        else
        {
            if(!isFlip) return rotation;
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y);
            transform.localScale = scale;
            isFlip = false;
        }

        return rotation;
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

}