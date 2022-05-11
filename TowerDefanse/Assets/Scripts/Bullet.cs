using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "怪物")
        {
          //  other.GetComponent<Enemy>().Hurt(25);
        }
    }
}
