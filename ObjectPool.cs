/*
 * Author:  Rick
 * Create:  2017/6/30 16:36:25
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UnityEngine.GameObject 和 UnityEngine.Compoent 对象池
/// </summary>
public class ObjectPool : MonoBehaviour
{
    //配置
    public bool setParent = true;//是否SetParent
    public bool setDisable = true;//是否SetActive(false)
    public bool resetParent = true;
    public bool resetEnable = true;//重置是否SetActive(true)

    private static ObjectPool ins;
    private static Transform container;
    
    private static GenericPool<ObjectItem> objects;
    private static GenericPool<ObjectItem> components;

    // Use this for initialization
    void Start()
    {
        ins = this;
        container = transform;
        objects = new GenericPool<ObjectItem>();
        components = new GenericPool<ObjectItem>();
    }


    /// <summary>
    /// 设置
    /// </summary>
    /// <param name="item"></param>
    private static ObjectItem Set(ObjectItem item)
    {
        if (ins.setParent)
            item.transform.SetParent(container);

        if (ins.setDisable)
            item.gameObject.SetActive(false);

        return item;
    }

    /// <summary>
    /// 重置
    /// </summary>
    /// <param name="o"></param>
    private static ObjectItem Reset(ObjectItem item)
    {   
        if (ins.resetParent)
            item.transform.SetParent(item.parent);

        if (ins.resetEnable)
            item.gameObject.SetActive(true);

        return item;
    }

#region 使用接口
    public static void Add(object key, GameObject obj)
    {
        ObjectItem item = new ObjectItem(obj);
        objects.Add(key, Set(item));
    }
    public static void Add<T>(object key, T component) where T : Component
    {
        ObjectItem item = new ObjectItem(component.gameObject, component);
        components.Add(key, Set(item));
    }

    public static GameObject Get(object key)
    {
        ObjectItem item = objects.Get(key);
        if (item == null) 
            return null;

        return Reset(item).gameObject;
    }

    public static T Get<T>(object key) where T : Component
    {
        ObjectItem item = components.Get(key);
        if (item == null)
            return null;

        return (T)Reset(item).component;
    }

    public static void Clear()
    {
    }
#endregion
}

/// <summary>
/// 对象池数据项
/// </summary>
/// <typeparam name="T"></typeparam>
internal class ObjectItem
{
    public GameObject gameObject;//对象
    public Component component;//组件
    public Transform transform;
    public Transform parent;//推进池之前的parent


    public ObjectItem(GameObject obj,Component com = null)
    {
        this.gameObject = obj;
        this.component = com;
        this.transform = obj.transform;
        this.parent = transform.parent;
    }

    public void Destory()
    {
        GameObject.Destroy(gameObject);
    }
}