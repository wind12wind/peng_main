using UnityEngine;

public class ResourceManager
{
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