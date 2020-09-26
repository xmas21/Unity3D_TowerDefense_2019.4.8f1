using UnityEngine;
using System.Collections.Generic;

public class SpawmManager : MonoBehaviour
{
    [Header("怪物")]
    public Transform[] enemy;
    [Header("間隔時間"), Range(0f, 5f)]
    public float cd = 2;
    [Header("生成點")]
    public GameObject point;
    [Header("生成數量"), Range(1, 100)]
    public int spawnNumber = 5;

    private float timer;
    private int count;

    public List<Enemy> enemys = new List<Enemy>();
    public List<float> distances = new List<float>();

    private void Start()
    {
        InvokeRepeating("Spawn", 0, cd);
    }

    private void Spawn()
    {
        count++;

        if (count > spawnNumber) return;

        int r = Random.Range(0, enemy.Length);

        Transform temp = Instantiate(enemy[r]);

        enemys.Add(temp.GetComponent<Enemy>());
        distances.Add(0);
    }
}
