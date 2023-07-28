using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitter : MonoBehaviour
{
    public bool isOnPlayer = true;
    public Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (isOnPlayer)
        {
            if (other.tag != "Player")
            {
                if (other.TryGetComponent<Target>(out Target target))
                {
                    target.TakeDamage(WargearManager.Instance.wargear.weapon.damage);
                }
                if(other.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.TakeDamage(WargearManager.Instance.wargear.weapon.damage);
                }
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                if (other.TryGetComponent<Player>(out Player player))
                {
                    player.TakeDamage(enemy.weapon.damage);
                }
            }
        }
    }
}
