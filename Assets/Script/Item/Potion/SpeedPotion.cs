using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D speedPotion)
    {
        if (speedPotion.CompareTag("Character"))
        {
            Destroy(gameObject);

            CharacterMove _player = speedPotion.GetComponent<CharacterMove>();
            if (_player != null)
            {
                _player._Speed += 0.2f;
                Debug.Log($"체력 회복 ! 현재 속도 {_player._Speed}");
            }
            else
            {
                Debug.Log($"Player가 없어");
            }
        }
    }
}
