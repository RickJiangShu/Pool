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
/// ObjectPool
/// </summary>
public class ObjectPool : MonoBehaviour
{
    private static Transform container;
    private static GenericPool<Object> objects;

    // Use this for initialization
    void Start()
    {
        container = transform;
        objects = new GenericPool<Object>();
    }

    private static void AddChild(Transform child)
    {
        child.SetParent(container);
    }

    public static void Add(object key, Object obj)
    {
        objects.Add(key, obj);
    }

    public static Object Get(object key)
    {
        return objects.Get(key);
    }

    public static T Get<T>(object key) where T : Object
    {
        return (T)Get(key);
    }
}
