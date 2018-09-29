using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡类,负责自己那一排的方块布局
/// </summary>
public class Level : MonoBehaviour
{
    public float speed;
    GameObject cube;
    void OnEnable()
    {
        cube = Resources.Load<GameObject>("Prefabs/Cube");
        CreateCube(transform.childCount);
    }
    void Update()
    {
        transform.Translate(0, Time.deltaTime * -speed, 0);
    }
    void CreateCube(int length) //生成方块
    {
        //随机挑出一个空位
        int index = Random.Range(0, transform.childCount);
        for (int i = 0; i < length; i++)
        {
            if (i != index)
            {
                GameObject obj = Instantiate(cube, transform.GetChild(i).position, cube.transform.rotation);
                Destroy(obj.GetComponent<TrailRenderer>());
                obj.transform.SetParent(transform);
            }    
        }
    }
}
