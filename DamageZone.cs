using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageRate;

    private float timer;
    private Destructible destructible;

    private void Update()
    {
        if (destructible == null) return;

        timer += Time.deltaTime;

        if(timer >= damageRate)
        {
            if(destructible != null)
            {
                destructible.ApplyDamage(damage);
            }
            
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        destructible = other.GetComponent<Destructible>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(destructible == other.GetComponent<Destructible>()) destructible = null;
    }
}
