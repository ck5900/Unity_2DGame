
using UnityEngine;

public class Player : MonoBehaviour
{
    //註解

    //欄位語法
    //修飾詞 類型 名稱 (指定 值) ;
    //私人 private 不顯示 (預設值)
    //公開 public  顯示

    //類型 四大類型
    //整數   int
    //浮點數 float
    //布林值 bool true 是、false 否
    //字串   string
    [Header("等級")]
    public int lv = 1;
    [Header("移動速度"), Range(0, 300)]
    public float speed = 10.5f;
    [Header("角色是否死亡")]
    public bool isDead = false;
    [Tooltip("角色名稱")]
    public string cName = "貓咪";
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;

    //方法語法 Method - 儲存複雜的程式區塊或演算法
    //修飾詞 類型 名稱 () { 程式區塊或演算法 }
    // void 無類型

    /// <summary>
    /// 移動 
    /// </summary>
    private void Move()
    {

        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        // 變形元件.位移(水平 * 速度 * 一幀的時間, 垂直 * 速度 * 一幀的時間 , 0) 
        tra.Translate(h * speed * Time.deltaTime,v * speed * Time.deltaTime, 0);

        ani.SetFloat("水平", h);
        ani.SetFloat("垂直", v);
    }

    private void Attack()
    {
 
    }

    private void Hit()
    {

    }

    private void Dead()
    {

    }

    //事件 - 特定時間會執行的方法
    // 開始事件 : 播放後執行一次
    private void Start()
    {

    }

    // 更新事件 : 大約一秒執行六十次 60FPS
    private void Update()
    {
        //呼叫方法
        //方法名稱();
        Move();
    }


}
