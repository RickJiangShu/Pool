/*
 * Author:  Rick
 * Create:  2017/6/30 16:12:13
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 最高效的对象池
/// </summary>
public class GenericPool<T> where T : class
{
    private Dictionary<object, List<T>> cache = new Dictionary<object, List<T>>();

    public void Add(object key, T value)
    {
        List<T> list;
        if (cache.TryGetValue(key, out list))
        {
            list.Add(value);
        }
        else
        {
            list = new List<T>() { value };
            cache.Add(key, list);
        }
    }
    public T Get(object key)
    {
        List<T> list;
        if (cache.TryGetValue(key, out list) && list.Count > 0)
        {
            T value = list[0];
            list.RemoveAt(0);
            return value;
        }
        return null;
    }

}
