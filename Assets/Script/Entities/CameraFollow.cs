using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // 따라다닐 대상 캐릭터

    void LateUpdate()
    {
        if (target != null)
        {
            // 캐릭터의 위치를 따라가게 조정
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
