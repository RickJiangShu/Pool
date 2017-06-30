/*
 * Author:  Rick
 * Create:  2017/6/30 16:12:13
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 最高效的对象池
/// </summary>
public class Pool<T>
{
    private Dictionary<object, T> values = new Dictionary<object,T>();
    // Use this for initialization
    void Start()
    {

    }

    public void Add(object key, T value)
    {

    }
    public T Get(object key)
    {
        T value;
        values.TryGetValue(key, out value);
      //  values.TryGetValue(key, out value);
        return values[key];
    }

}
