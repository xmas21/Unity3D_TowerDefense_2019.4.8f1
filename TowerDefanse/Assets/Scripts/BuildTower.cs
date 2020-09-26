using UnityEngine;

public class BuildTower : MonoBehaviour
{
    /// <summary>
    /// 塔陣列：所有的塔
    /// </summary>
    public GameObject[] tower;

    public Vector3[] angles;

    /// <summary>
    /// 選取塔的編號
    /// </summary>
    public int index { get; set; }

    /// <summary>
    /// 是否選到塔
    /// </summary>
    public bool chooseTower { get; set; }

    /// <summary>
    /// 是否點擊放置區域
    /// </summary>
    public bool click { get; set; }

    /// <summary>
    /// 暫時的塔
    /// </summary>
    private GameObject tempTower;

    public Material mArea;

    private void Update()
    {
        Build();
    }

    /// <summary>
    /// 建造
    /// </summary>
    public void Build()
    {
        // 如果 有選塔
        if (chooseTower)
        {
            Time.timeScale = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                                                // 從滑鼠發射射線
            RaycastHit hit;                                                                                             // 射線打到的物件

            if (!click && Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(ray, out hit, 1000, 1 << 8))              // 如果 沒有點擊過 並且 按下左鍵 並且 射線打到放置區域
            {
                click = true;                                                                                           // 有點擊過
                tempTower = Instantiate(tower[index], hit.transform.position, Quaternion.Euler(angles[index]));         // 暫時的塔 = 生成塔
            }
        }
    }

    public void Show()
    {
        mArea.color = new Color(4 , 4, 4, 20f / 255f);
    }

    public void OK()
    {
        chooseTower = false;
        click = false;
        mArea.color = new Color(1, 1, 1, 0);
        Time.timeScale = 1;
    }

    public void Cancel()
    {
        chooseTower = false;
        click = false;
        Destroy(tempTower);
        mArea.color = new Color(1, 1, 1, 0);
        Time.timeScale = 1;
    }
}
