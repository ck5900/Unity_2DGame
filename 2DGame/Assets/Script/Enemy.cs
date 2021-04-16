using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("追蹤範圍"), Range(0, 500)]
    public float rangeTrack = 2;
    [Header("攻擊範圍"), Range(0, 50)]
    public float rangeAttack = 0.5f;
    [Header("移動速度"), Range(0, 50)]
    public float speed = 2;

    private Transform player;

    private void Start()
    {
        // 玩家變形 = 尋找遊戲物件("物件名稱").變形
        player = GameObject.Find("玩家").transform;
    }

    // 繪製圖示事件:在 Unity 內顯示輔助開發
    private void OnDrawGizmos()
    {
        // 先指定顏色在畫圖
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        // 繪製球體(中心點,半徑)
        Gizmos.DrawSphere(transform.position, rangeTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    private void Update()
    {
        Track();
    }

    ///<summary>
    /// 追蹤玩家
    ///</summary>
    private void Track()
    {
        //距離 等於 三維向量 的 距離(A 點, B 點)
        float dis = Vector3.Distance(transform.position, player.position);

        //如果 距離 小於等於 追蹤範圍 才開始追蹤
        if (dis <= rangeTrack)
        {
            // 物件 的 座標 更新為 三維向量 的 往前移動(物件 的 座標,目標 的座標,速度)
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

}
