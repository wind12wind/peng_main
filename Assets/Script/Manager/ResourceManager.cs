using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, string name, Transform parent = null)
    {
        Debug.Log($"{path}/{name}");

        GameObject prefab = Resources.Load<GameObject>($"{path}/{name}");
        if(prefab == null)
        {
            Debug.Log($"File to load Prefab : {path}/{name}");
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