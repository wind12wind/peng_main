using System.Collections.Generic;
using UnityEngine;

public class AbilityBox : MonoBehaviour
{
    [SerializeField] private GameObject abilitySelectUI;

    private void OnTriggerEnter2D(Collider2D abilityBox)
    {
        if (abilityBox.CompareTag("Character"))
        {
            Destroy(gameObject);
            GameObject abilityPanel = Resources.Load<GameObject>("ManagerAndUI/AbilitySelectUI");
            Instantiate(abilityPanel);

            Time.timeScale = 0.0f;
        }
    }
}
