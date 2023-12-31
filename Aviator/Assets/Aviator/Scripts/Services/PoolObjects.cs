using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects<T> where T : MonoBehaviour
{
    protected static List<T> _objects = new List<T>();

    public static T GetObject(T prefabObject)
    {
        foreach (var currentObject in _objects)
        {
            if (currentObject.gameObject.activeSelf == false)
            {
                currentObject.gameObject.SetActive(true);
                return currentObject;
            }
        }

        return AddObject(prefabObject);
    }

    protected static T AddObject(T prefabObject)
    {
        var createdObject = UnityEngine.Object.Instantiate(prefabObject);
        _objects.Add(createdObject);
        return createdObject;
    }

    public static void DisactiveObjects()
    {
        foreach (var currentObject in _objects)
        {
            if (currentObject.gameObject.activeSelf)
                currentObject.gameObject.SetActive(false);
        }
    }
}
