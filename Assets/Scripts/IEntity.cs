using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity 
{
    int Hp { get; }
    int MaxHp { get; }

    void Damage(int damage);
    void Heal(int heal);
}
