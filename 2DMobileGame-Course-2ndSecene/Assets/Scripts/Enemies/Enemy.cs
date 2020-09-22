using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Base Stats")]

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;

    public virtual void Attack()
    {

    }

    public abstract void Update();




}
