using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour
{
    public GameObject cube;
    public float speed = 200;

   public void ShootFromPos()
   {
       //在自身位置生成方块,并改变颜色,为方块添加脚本且设置速度
       GameObject obj = Instantiate(cube, transform.position, cube.transform.rotation);
       obj.GetComponent<MeshRenderer>().material.color = Color.red;
       obj.AddComponent<Cube>().speed = speed;
   }
}
