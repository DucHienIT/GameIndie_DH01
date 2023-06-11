using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : DucHienMonoBehaviour
{
    [SerializeField] protected List<GameObject> healthDot;

    protected int countHealthDot = 10;
    protected int currentHealthDot = 10;

    protected virtual void FixedUpdate()
    {
        this.UpdateHealthDot();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();  
        this.LoadHealthDot();
    }
    protected virtual void LoadHealthDot()
    {
        if (this.healthDot.Count > 0) return;
        for (int i = 0; i < this.countHealthDot; i++)
        {
            this.healthDot.Add(transform.Find("ListHealthDot").GetChild(i).gameObject);
        }
    }


    protected virtual void UpdateHealthDot()
    {
        this.SetHealthDot();
        if (this.currentHealthDot == this.healthDot.Count) return;
        if (this.currentHealthDot > this.healthDot.Count) return;
        if (this.currentHealthDot < 0) return;

        for (int i = 0; i < this.healthDot.Count; i++)
        {
            if (i < this.currentHealthDot)
            {
                this.healthDot[i].SetActive(true);
            }
            else
            {
                this.healthDot[i].SetActive(false);
            }
        }
    }
    public virtual void SetHealthDot()
    {
        this.currentHealthDot = PlayerCtrl.Instance.Status.Health;
    }

}
