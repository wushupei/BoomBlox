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
                SceneManager.LoadScene("Scene");
        }
    }
    void ShowMenu()
    {
        //变宽
        width = Mathf.Lerp(width, 50, Time.deltaTime * 2);
        line.startWidth = width;
        line.endWidth = width;
        //Panel落下来
        panel.position = Vector3.Lerp(panel.position, new Vector3(0, 12, 4), Time.deltaTime);
    }
}
