using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    TextMesh scoreText;
    int score; //分数
    int scoreAmount = 10; //加分数
    int upgrade = 0; //升级点分数

    public delegate void DamagedEventHandler();//定义事件类
    public event DamagedEventHandler OnDamaged; //声明事件
    void Start()
    {
        upgrade = scoreAmount * 20; //设定升级点分数
        OnDamaged += FindObjectOfType<CreateLevel>().AddSpeed;//将关卡加速作为事件进行绑定
        scoreText = GetComponent<TextMesh>();
    }
    void Update()
    {
        
    }
    public void AddScore() //加分并显示
    {       
        score += scoreAmount;
        scoreText.text = score.ToString();
        ScorePlus();
    }

    void ScorePlus() //加分量会随着总分数累加
    {
        if (score >= upgrade) //到达升级点升级
        {            
            scoreAmount += 10;             
            upgrade = score + scoreAmount * 20;
            OnDamaged(); //触发事件,关卡加速
        }
    }
}
