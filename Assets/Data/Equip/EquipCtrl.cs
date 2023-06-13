
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
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

}