using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0.1f, 10)]
    public float speed = 2;
    [Header("血量"), Range(100, 600)]
    public float hp = 200;
    [Header("金錢"), Range(10, 100)]
    public int coin = 20;

    private Rigidbody rig;
    private NavMeshAgent nav;
    private Animator ani;
    private Transform EndPoint;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        nav.speed = speed;

        EndPoint = GameObject.Find("終點").transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        nav.SetDestination(EndPoint.position);
        ani.SetFloat("移動", nav.velocity.magnitude);
    }

    //public void Hurt(int damage)
    //{
    //    hp -= damage;

    //    if (hp <= 0)
    //    {
    //        Die();
    //    }
    //}

    //void Die()
    //{
    //    Destroy(gameObject, 1.5f);
    //}

}
