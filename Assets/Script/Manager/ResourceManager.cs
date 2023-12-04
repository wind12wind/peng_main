using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public void Awake()
    {
        Debug.Log("ResourceAwake");
        if (Instance == null)
        {
            Debug.Log("ResourceInstantiate");
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("ResourceOnlyOne");
            Destroy(Instance);
        }

        DontDestroyOnLoad(Instance);
    }

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        Debug.Log($"Prefabs/{path}");

        GameObject prefab = Resources.Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"File to load Prefab : {path}");
            Debug.Log($"null");
            return null;
        }

        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject gameObject)
    {
        if(gameObject == null)
        {
            return;
        }

        Object.Destroy(gameObject);
    }
}