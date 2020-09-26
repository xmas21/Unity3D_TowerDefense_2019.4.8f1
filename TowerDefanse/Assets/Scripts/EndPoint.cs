using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "怪物")
        {
            DestoryEnemy(other.gameObject);
        }
    }

    private void DestoryEnemy(GameObject prop)
    {
        Destroy(prop);
    }
}
