using UnityEngine;

public class SpawmManager : MonoBehaviour
{
    [Header("怪物")]
    public Transform[] enemy;
    [Header("間隔時間"), Range(0f, 5f)]
    public float interval = 1;
    [Header("生成點")]
    public GameObject point;
    [Header("生成數量"), Range(10, 100)]
    public int spawnNumber = 10;

    private void Start()
    {

    }

    private void Spawn()
    {
    }
}
