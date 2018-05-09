using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public enum Alignment { Player = 0, Enemy = 1 }

    public Alignment UnitAlignment;

    public GameObject ExplosionPrefab;
    public GameObject HealthBarPrefab;
    
    public List<Image> HealthBarImages;

    private int _health;
    public int FullHealth =100;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            SetHealthBarFills((float)_health / (float)FullHealth);
            if (_health <= 0)
            {
                Explode();
            }
        }
    }


    public virtual void Start()
    {
        HealthBarImages = new List<Image>();

        foreach(var unitsUI in GameManager.Instance.UnitsUIList)
        {
            var go = Instantiate(HealthBarPrefab, unitsUI.transform);
            var healthbar = go.GetComponent<HealthBar>();
            healthbar.Unit = this;
            HealthBarImages.Add(healthbar.HealthFill);
            healthbar.Camera = unitsUI.Camera;
        }

    }
    public void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy();
    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
    private void SetHealthBarFills(float percentage)
    {
        foreach (var healthbar in HealthBarImages)
            healthbar.fillAmount = percentage;
    }
}
