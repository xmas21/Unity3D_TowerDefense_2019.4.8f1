using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    [Header("攻擊力"), Range(10, 500)]
    public int attack = 10;
    [Header("攻擊頻率"), Range(0f, 3f)]
    public float cd = 1;
    [Header("追蹤速度"), Range(0.1f, 100)]
    public float turn = 10;
    [Header("攻擊範圍"), Range(1, 100)]
    public float range = 30;
    [Header("子彈")]
    public Transform bullet;
    [Header("子彈生成點")]
    public Transform bulletPoint;
    [Header("子彈速度"), Range(1, 10000)]
    public float speed = 300;

    private float timer;
    private Animator ani;
    private SpawmManager sm;

    public List<float> distances = new List<float>();

    public Transform target;

    private int index;

    private void Awake()
    {
        sm = FindObjectOfType<SpawmManager>();
    }

    private void Update()
    {
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, range);
    }

    private void Attack()
    {
        #region 判斷範圍內第一隻敵人並面向
        distances = sm.distances;

        for (int i = 0; i < distances.Count; i++) distances[i] = Vector3.Distance(transform.position, sm.enemys[i].transform.position);

        if (!target)
        {
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] <= range)
                {
                    index = i;
                    target = sm.enemys[i].transform;
                    return;
                }
            }
        }

        if (target)
        {
            if (distances[index] > range) target = null;
        }

        if (!target) return;

        Vector3 pos = target.position;
        pos.y = transform.position.y;

        Quaternion look = Quaternion.LookRotation(pos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * turn);
        #endregion


        if (target)
        {
            timer += Time.deltaTime;

            if (timer >= cd)
            {
                timer = 0;
                ParticleSystem[] ps = GetComponentsInChildren<ParticleSystem>();
                for (int i = 0; i < ps.Length; i++) ps[i].Play();

                Vector3 shootPoint = new Vector3(bulletPoint.position.x, bulletPoint.position.y - 2, bulletPoint.position.z);
                Transform temp = Instantiate(bullet, shootPoint, Quaternion.identity);
                temp.GetComponent<Rigidbody>().AddForce(transform.forward * speed * 6);
            }
        }

    }
}
