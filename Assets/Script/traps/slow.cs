using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    public float slowdownFactor = 0.5f; // 물에서의 속도 감소 비율
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // 플레이어와 충돌했을 때
        {
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            if (CharacterMove != null)
            {
                // 플레이어의 속도를 감소시킴
                CharacterMove.ApplySlowdown(slowdownFactor);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // 플레이어와 충돌이 끝났을 때
        {
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            if (CharacterMove != null)
            {
                // 플레이어의 속도를 원래대로 복구시킴
                CharacterMove.ResetSpeed();
            }
        }
    }

}

