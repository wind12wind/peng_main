using UnityEngine;

public class FieldManager : MonoBehaviour
{
    private GameObject _field;

    private void Awake()
    {
        CreateTileMap("Field");
    }

    public void CreateTileMap(string mapName)
    {
        _field = Resources.Load<GameObject>($"ManagerAndUI/{mapName}");
        Instantiate(_field);
        _field.transform.position = new Vector3(0, 0, 0);
    }
}
