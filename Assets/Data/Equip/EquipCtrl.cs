
using UnityEngine;

public class EquipCtrl : DucHienMonoBehaviour
{
    
    [SerializeField] protected WeaponSO weaponSO;
    public WeaponSO WeaponSO { get { return weaponSO; } }

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

    protected virtual Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; 
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return targetPosition;
    }

    protected virtual Quaternion UpdateQuaternionEquipment()
    {
          // Tính toán góc giữa đối tượng bắn và vị trí chuột
        Vector3 direction = this.GetMousePosition() - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return rotation;
    }
}