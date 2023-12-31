using UnityEngine;

public class MpPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D mpPotion)
    {
        if (mpPotion.CompareTag("Character"))
        {
            Destroy(gameObject);

            Player _player = mpPotion.GetComponent<Player>();
            if (_player != null)
            {
                _player.CurrentMp += 20;
                //Debug.Log($"마나 회복 ! 현재 MP {_player.CurrentMp}");
            }
            else
            {
                Debug.Log($"Player가 없어");
            }
        }
    }
}
