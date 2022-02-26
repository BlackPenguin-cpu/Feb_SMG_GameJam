using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool isNotSingle;
    public bool isNotDontdestroy;
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T t;
                t = FindObjectOfType(typeof(T)) as T;
                if (t == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    obj.AddComponent<T>();
                    instance = obj.GetComponent<T>();
                }

                else
                {
                    instance = t.GetComponent<T>();
                }
            }
            return instance;
        }
        set
        {

        }
    }
    protected virtual void Awake()
    {
        if (!isNotSingle)
        {
            T[] objects = FindObjectsOfType<T>();
            foreach (T obj in objects)
            {
                if (obj.gameObject != this.gameObject)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        if (!isNotDontdestroy) DontDestroyOnLoad(gameObject);
    }
}
