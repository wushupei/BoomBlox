using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour //触发边界
{
    CreateLevel cl; //声明生成关卡脚本
    GameObject boom; //特效
    AudioClip clip; //声音
    public GameObject player;
    public GameObject menu;
    void Start()
    {
        cl = FindObjectOfType<CreateLevel>();
        boom = Resources.Load<GameObject>("Effect/Boom/Boom"); //加载特效
        clip = Resources.Load<AudioClip>("Audio/Boom"); //加载声音
    }
    void Update()
    {
        if (cl.isLife == false) //游戏结束往上走
            transform.Translate(0, Time.deltaTime * 10, 0);
    }
    void OnTriggerEnter(Collider cube) //触发一次
    {
        if (cube.gameObject != menu)//如果不是菜单
        {
            //结算分数
            menu.GetComponent<Menu>().SaveScore();
            //禁用主角
            player.SetActive(false);
            //停止生成关卡
            cl.isLife = false;
            //生成特效和声音
            Instantiate(boom, cube.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 10, -15));
            Destroy(cube.gameObject);
        }
        else //如果是菜单则展示
            menu.GetComponent<Menu>().show = true;
    }
}
