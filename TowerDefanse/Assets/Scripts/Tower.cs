using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("攻擊力"), Range(10, 500)]
    public int attack = 10;
    [Header("攻擊頻率"), Range(0f, 3f)]
    public float cd = 1;
    [Header("追蹤速度"), Range(0.1f, 100)]
    public float turn = 10;

    private float timer;
    private Animator ani;

    private void Attack()
    {
        //Quaternion look = Quaternion.LookRotation(Enemy.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * turn);

        timer += Time.deltaTime;

        if (timer >= cd)
        {
            timer = 0;
            ani.SetTrigger("攻擊觸發");
        }
    }
}
