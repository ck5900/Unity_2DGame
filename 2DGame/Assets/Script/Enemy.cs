using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("追蹤範圍"), Range(0, 500)]
    public float rangeTrack = 2;
    [Header("攻擊範圍"), Range(0, 50)]
    public float rangeAttack = 0.5f;
    [Header("移動速度"), Range(0, 50)]
    public float speed = 2;
    [Header("攻擊特效")]
    public ParticleSystem psAttack;
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float cdAttack = 3;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 20;
    [Header("經驗值"), Range(0, 500)]
    public float exp = 30;

    private bool isDead = false;


    private Transform player;
    private Player _player;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;

    [Header("血量")]
    public float hp = 200;
    [Header("血條系統")]
    public HpManager hpManager;

    private float hpMax;

    private void Start()
    {
        hpMax = hp;    //取得血量最大值

        // 玩家變形 = 尋找遊戲物件("物件名稱").變形
        player = GameObject.Find("玩家").transform;
        _player = player.GetComponent<Player>();
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
        if (isDead) return;

        //距離 等於 三維向量 的 距離(A 點, B 點)
        float dis = Vector3.Distance(transform.position, player.position);

        //如果 距離 小於等於 攻擊範圍 進入攻擊狀態
        //如果 距離 小於等於 追蹤範圍 才開始追蹤
        if (dis <= rangeAttack)
        {
            Attack();
        }
        else if (dis <=rangeTrack)
        {
            // 物件 的 座標 更新為 三維向量 的 往前移動(物件 的 座標,目標 的座標,速度)
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;    //累加時間

        //如果 計時器 大於等於 冷卻時間 就攻擊
        if (timer >= cdAttack)
        {
            timer = 0;              //計時器 歸零
            psAttack.Play();        //播放 攻擊特效
            Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeAttack,1 << 9);
            hit.GetComponent<Player>().Hit(attack);
        }
    }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">接收到的傷害值</param>
        public void Hit(float damage)
        {
            hp -= damage;                                    //扣除傷害值
            hpManager.UpdateHpBar(hp, hpMax);                //更新血條
            StartCoroutine(hpManager.ShowDamage(damage));    //啟動同協程式(顯示傷害值)

            if (hp <= 0) Dead();                             //如果 血量 <= 就死亡
        }
        
        private void Dead()
        {
            hp = 0;
            isDead = true;
            Destroy(gameObject, 1.5f);
        }

    
}
