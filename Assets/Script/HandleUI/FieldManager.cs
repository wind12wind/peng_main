using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [SerializeField] private GameObject _field;

    public void CreateTileMap(string mapName)
    {
        GameManager.Instance.Resource.Instantiate(mapName);
        _field.transform.position = new Vector3(0, 0, 0);
    }

    public void OpenNewDoor(int level)
    {

    }
}
