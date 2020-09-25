using UnityEngine;
using UnityEngine.UI;

public class UIinfor : MonoBehaviour
{
    [Header("剩餘生命")]
    public Text lasthp;
    [Header("剩餘敵人")]
    public Text enemy;
    [Header("波次")]
    public Text round;
    [Header("金幣")]
    public Text money;
    [Header("遊戲結束畫面")]
    public GameObject EndPanel;

    private int damage = 1;
    public int Hp = 5;



    private void OnTriggerEnter(Collider other)
    {
        Hp -= damage;

        if (Hp == 0) Dead();
    }

    private void Dead()
    {
        EndPanel.SetActive(true);
    }

}
