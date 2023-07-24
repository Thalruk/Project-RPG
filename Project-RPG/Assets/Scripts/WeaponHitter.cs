using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            if (other.TryGetComponent<Target>(out Target target))
            {
                Debug.Log("hit" + other.name);
                target.TakeDamage(WargearManager.Instance.wargear.weapon.damage);
            }
        }
    }
}
