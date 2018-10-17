using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    LineRenderer line; //画线组件
    float width = 5; //初始宽度
    Transform panel; //子物体Panel
    public bool show = false; //是否展示自身菜单
    public TextMesh score; //当前分
    public TextMesh topScore; //最高分Text
    void Start()
    {
        line = GetComponent<LineRenderer>();
        panel = transform.GetChild(0);
    }
    void Update()
    {
        if (show)
        {
            ShowMenu();
            if (Input.GetKeyDown(KeyCode.Return))
                GameAgain();
        }
    }
    void ShowMenu()
    {
        //迷雾变宽
        width = Mathf.Lerp(width, 50, Time.deltaTime * 2);
        line.startWidth = width;
        line.endWidth = width;
        //Panel落下来
        panel.position = Vector3.Lerp(panel.position, new Vector3(0, 12, 4), Time.deltaTime);
    }
    public void GameAgain() //重新开始游戏
    {
        SceneManager.LoadScene("Scene");
    }  
    public void SaveScore() //结算分数保存最高分
    { 
        if (PlayerPrefs.HasKey("最高分"))
            topScore.text = PlayerPrefs.GetString("最高分");
        //如果本局分数比最高分大
        if (Convert.ToInt32(score.text) > Convert.ToInt32(topScore.text))
        {
            topScore.text = "最高分 " + score.text; //将当前分数显示在最高分数那里
            PlayerPrefs.SetString("最高分", score.text);//存储本局分数
        }
    }
}
