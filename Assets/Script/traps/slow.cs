using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    public float slowdownFactor = 0.5f; // 물에서의 속도 감소 비율
    public bool isInWater = false; //물속에있는지 체크
  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // 플레이어와 충돌했을 때
        { 
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            //if (CharacterMove != null)
            //{
                CharacterMove.ApplySlowdown(slowdownFactor);
            //    isInWater = true;
            //}
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // 플레이어와 충돌이 끝났을 때
        {
          
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            CharacterMove.ResetSpeed();

        }
    }
    //public bool IsPlayerStillInWater()
    //{
    //    // 물위에 있는 상태인지 체크
    //    return isInWater;
    //}

}

