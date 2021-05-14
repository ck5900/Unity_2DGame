using UnityEngine;

[CreateAssetMenu(fileName ="經驗值資料", menuName = "Bala/經驗值資料")]
public class ExpData : ScriptableObject
{
    // 陣列
    // 語法:在類型後面加上一對中誇號
    // 陣列的作用:處存多筆相形的資料
    [Header("每個等級經驗值需求,從一開始")]
    public float[] exp;
}
