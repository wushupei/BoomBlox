using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 生成一排排关卡,每一排关卡里的方块排列由关卡类自行处理
/// </summary>
public class CreateLevel : MonoBehaviour
{
    public GameObject level; //预制体
    List<GameObject> levels = new List<GameObject>();
    public float speed;
    float timerSpace; //时间间隔
    public bool isLife = true; //活着
    void Update()
    {
        if (isLife)
        {      
            //每走1米生产一次
            timerSpace += Time.deltaTime;
            if (timerSpace > 1 / speed)
            {
                Create();
                timerSpace = 0;
            }
        }
        else //死了所有关卡速度为0
            foreach (var item in levels)
            {
                item.GetComponent<Level>().speed =0;
            }
    }
    void Create() //创建关卡
    {
        GameObject obj = Instantiate(level, transform.position, Quaternion.identity);
        obj.AddComponent<Level>().speed = speed;
        levels.Add(obj);
    }
    public void DeleteLevel(Transform level) //删除关卡
    {
        int index = levels.IndexOf(level.gameObject); //拿到索引
        Cover(index);
        levels.RemoveAt(index);
    }
    void Cover(int index) //关卡补位(当一个关卡被删除由其它关卡将移到它的位置)
    {
        for (int i = 0; i < index; i++)
        {
            levels[i].transform.position = levels[i + 1].transform.position;
        }
    }
    public void AddSpeed() //速度累加
    {
        speed += 0.5f;
        foreach (var item in levels)
        {
            item.GetComponent<Level>().speed = speed;
        }
    }
}
