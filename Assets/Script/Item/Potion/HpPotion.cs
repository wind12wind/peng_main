using UnityEngine;

public class HpPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hpPotion)
    {
        if (hpPotion.CompareTag("Character"))
        {
            Destroy(gameObject);

            Player _player = hpPotion.GetComponent<Player>();
            if (_player != null)
            {
                _player.CurrentHp = ((_player.CurrentHp + 20) > 100) ? 100 : _player.CurrentHp + 20;
                //Debug.Log($"체력 회복 ! 현재 HP {_player.CurrentHp}");
            }
            else
            {
                Debug.Log($"Player가 없어");
            }
        }
    }
}
