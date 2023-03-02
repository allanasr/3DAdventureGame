using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(float damage, Vector3 dir);
    void Damage(float damage);
}
