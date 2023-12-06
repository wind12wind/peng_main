using System.Collections.Generic;
using UnityEngine;

public class AbilityBox : MonoBehaviour
{
    [SerializeField] private GameObject abilitySelectUI;
    public List<Sprite> abilityImages;

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
