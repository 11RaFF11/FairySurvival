using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, IEntity
{
    private delegate void checkHp ();
    private event checkHp death;

    [SerializeField] private GameObject prefab;
    [SerializeField] private int maxHp;
    private int hp;

    public int Hp => hp;
    public int MaxHp => maxHp;

    private void Start()
    {
        hp = maxHp;
        death += Death;
    }

    public void Damage(int damage)
    {
        if (damage <= 0)
            return;

        hp -= damage;

        if (hp <= 0)
            death.Invoke();
    }

    public void Heal(int heal)
    {
        if (heal <= 0) 
            return;

        hp += heal;
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        death -= Death;
    }
}
