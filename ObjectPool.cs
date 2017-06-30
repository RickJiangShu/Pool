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
    private static Pool<GameObject> objects;
    private static Pool<Component> components;

    // Use this for initialization
    void Start()
    {
        container = transform;
        objects = new Pool<GameObject>();
        components = new Pool<Component>();
    }


    private static void AddChild(Transform child)
    {
        child.SetParent(container);
    }

    public static void Add(object key, GameObject obj)
    {
        objects.Add(key, obj);
    }

    public static void Add<T>(object key, T component) where T : Component
    {
        components.Add(key, component);
    }

    public static GameObject Get(object key)
    {
        return objects.Get(key);
    }

    public static T Get<T>(object key) where T : MonoBehaviour
    {
        return components.Get(key);
    }
}
