using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [SerializeField] private GameObject _field;

    // Start is called before the first frame update
    void Start()
    {
        ResourceManager.Instance.Instantiate("Prefabs/Field");
        _field.transform.position = new Vector3(0, 0, 0);
    }
}
