using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBox : MonoBehaviour
{
    [SerializeField] private GameObject abilitySelectUI;
    public List<Sprite> abilityImages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D abilityBox)
    //{
    //    if (abilityBox.CompareTag("Character"))
    //    {
    //        Destroy(gameObject);
    //        Invoke("AbilitySelect", 0f);
    //    }
    //}

    //private void AbilitySelect()
    //{
    //    abilitySelectUI.SetActive(true);
    //}
}
