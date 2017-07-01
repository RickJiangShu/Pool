/*
 * Author:  Rick
 * Create:  7/1/2017 1:39:58 PM
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 整合ObjectPool和GameObject.Instance
/// </summary>
public class ObjectFactory
{
    /*
    public static T Get<T>(GameObject prefab)
    {
        return null;
        //return Get(prefab).GetComponent<T>();
    }
     */
    public static GameObject Get(object key,GameObject prefab,Transform parent)
    {
        return null;
        /*

        GameObject.Instantiate
        GRect grect = ObjectPool.Get<GRect>(grectKey);
        if (grect == null)
        {
            GameObject go = GameObject.Instantiate(m_GroundPref);
            grect = go.GetComponent<GRect>();
            grect.transform.SetParent(Container);
        }
         */
    }
}
