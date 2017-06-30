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
    public bool resetEnable = true;//重置是否SetActive(true)

    private static ObjectPool ins;
    private static Transform container;
    
    private static GenericPool<ObjectItem> objects;
    private static GenericPool<ObjectItem<Component>> components;

    // Use this for initialization
    void Start()
    {
        ins = this;
        container = transform;
        objects = new GenericPool<ObjectItem>();
        components = new GenericPool<ObjectItem<Component>>();
    }

    private static ObjectItem<T> Serialize<T>(T component) where T : Component
    {
        return new ObjectItem<T>(component);
    }
    private static ObjectItem Serialize(GameObject obj)
    {
        return new ObjectItem(obj);
    }

    /// <summary>
    /// 设置
    /// </summary>
    /// <param name="o"></param>
    private static void Set(GameObject o)
    {
        if (ins.setParent)
            o.transform.SetParent(container);

        if (ins.setDisable)
            o.SetActive(false);
    }

    /// <summary>
    /// 重置
    /// </summary>
    /// <param name="o"></param>
    private static void Reset(GameObject o)
    {
        if (ins.resetEnable)
            o.SetActive(true);
    }

#region 使用接口
    public static void Add(object key, GameObject obj)
    {
        Set(obj);
        objects.Add(key, obj);
    }
    public static void Add<T>(object key, T component) where T : Component
    {
        Set(component.gameObject);
        components.Add(key, component);
    }

    public static GameObject Get(object key)
    {
        return objects.Get(key);
    }

    public static T Get<T>(object key) where T : Component
    {
        return (T)components.Get(key);
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
    public GameObject obj;//对象
    public Transform parent;//推进池之前的parent

    public ObjectItem(GameObject obj)
    {
        this.obj = obj;
    }

    public void Destory()
    {
        GameObject.Destroy(obj);
    }
}

internal class ObjectItem<T> : ObjectItem where T : Component
{
    public T component;
    public ObjectItem(T component) : base(component.gameObject)
    {
        this.component = component;
    }
}