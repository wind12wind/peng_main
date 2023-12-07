using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelectButton : MonoBehaviour
{
    [SerializeField] private GameObject abilitySelectUI;
    [SerializeField] private GameObject havePanelUI;

    public void PlayerAtkUpSelected()
    {
        Player.Instance.PlusAtk();

        Destroy(abilitySelectUI);
        Time.timeScale = 1.0f;
    }

    public void DoubleShotSelected()
    {
        if (Player.Instance.doubleShot == false)
        {
            Player.Instance.DoubleShotOn();

            Destroy(abilitySelectUI);
            Time.timeScale = 1.0f;
        }
        else
        {
            GameObject alreadyHavePanel = Resources.Load<GameObject>("ManagerAndUI/AlreadyHaveUI");
            Instantiate(alreadyHavePanel);
        }
    }

    public void HavePanelEnter()
    {
        Destroy(havePanelUI);
    }

}
