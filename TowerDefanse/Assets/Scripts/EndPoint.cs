using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (Collision.gameObject.tag == "怪物")
        {
            DestoryEnemy(Collision.gameObject);
        }
    }

    private void DestoryEnemy(GameObject prop)
    {
        Destroy(prop);
    }
}
