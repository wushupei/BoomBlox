using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家控制发射方块
/// </summary>
public class PlayerController : MonoBehaviour
{
    public GameObject cube; //预制体
    public float speed;
    void Update()
    {
        ShootCube();
    }
    void ShootCube() //发射
    {
        if (Input.anyKeyDown)
        {
            int index = -1;
            if (Input.GetKeyDown(KeyCode.Q))
                index = 0;
            if (Input.GetKeyDown(KeyCode.W))
                index = 1;
            if (Input.GetKeyDown(KeyCode.E))
                index = 2;
            if (Input.GetKeyDown(KeyCode.R))
                index = 3;
            if (index >= 0)
            {
                //生成方块,设置颜色和添加脚本
                GameObject obj = Instantiate(cube, transform.GetChild(index).position, cube.transform.rotation);
                obj.GetComponent<MeshRenderer>().material.color = Color.blue;
                obj.AddComponent<Cube>().speed = speed;            
            }
        }
    }
}
