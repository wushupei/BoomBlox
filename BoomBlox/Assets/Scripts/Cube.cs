using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家发射的方块
/// </summary>
public class Cube : MonoBehaviour
{
    public float speed;
    Transform hitObj; //被照射的物体
    bool testing = true; //是否对旁边进行检测
    void Update()
    {
        //发射射线获取前方方块       
        if (hitObj == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.up, out hit))
                hitObj = hit.transform;
            else
                Destroy(gameObject); //发射时前方没敌人则销毁自身
        }
        else
            Follow();
    }
    void Follow() //跟随被前方射线打到的物体移动
    {
        //如果接近被前方方块
        if (Vector3.Distance(transform.position, hitObj.position) <= 1)
        {
            Destroy(GetComponent<TrailRenderer>());
            transform.position = hitObj.position + Vector3.down; //跟随被打到的物体移动
            if (testing)
                testing = false;
            TestingSide();//则检测两边方块
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, hitObj.position, Time.deltaTime * speed);
            testing = true;
        }
    }
    void TestingSide() //检测旁边的方块
    {
        //用射线检测两边所有方块
        RaycastHit[] left = Physics.RaycastAll(transform.position, Vector3.left);
        RaycastHit[] right = Physics.RaycastAll(transform.position, Vector3.right);

        if (left.Length + right.Length >= 3)//检测到自己那一排满了
        {
            //用集合存取这一排所有方块
            List<GameObject> cubes = new List<GameObject>();
            //将检测到的方块添加进集合中   
            for (int i = 0; i < left.Length; i++)
            {
                cubes.Add(left[i].collider.gameObject);
            }
            for (int i = 0; i < right.Length; i++)
            {
                cubes.Add(right[i].collider.gameObject);
            }
            cubes.Add(gameObject);
            //为天然关卡则删除该关卡
            if (cubes[0].transform.parent != null)
            {
                FindObjectOfType<CreateLevel>().DeleteLevel(cubes[0].transform.parent);
                Destroy(cubes[0].transform.parent.gameObject);
                Destroy(gameObject);
            }
            else //否则视为人造关卡,删除这一排所有方块
                foreach (var item in cubes)
                {
                    Destroy(item);
                }
            ShowEffect(cubes);
        }
    }
    void ShowEffect(List<GameObject> cubes) //加分和展示特效
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/Boom");
        GameObject boom = Resources.Load<GameObject>("Effect/Boom/Boom"); //加载特效      
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 10, -15)); //播放声音
        //播放特效
        for (int i = 0; i < cubes.Count; i++)
        {
            boom = Instantiate(boom, cubes[i].transform.position, Quaternion.identity);
            boom.GetComponent<ParticleSystem>().Play();
        }
        FindObjectOfType<ScoreManager>().AddScore(); //加分
    }
}
