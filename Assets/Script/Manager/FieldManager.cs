using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public static FieldManager Instance { get; private set; }

    private GameObject _field;

    private void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        CreateTileMap("Field");
    }

    public void CreateTileMap(string mapName)
    {
        _field = Resources.Load<GameObject>($"ManagerAndUI/{mapName}");
        Instantiate(_field);
        _field.transform.position = new Vector3(0, 0, 0);
    }
}
