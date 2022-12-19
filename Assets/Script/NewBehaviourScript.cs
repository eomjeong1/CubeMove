using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public bool Run(Vector3 targetPos)
    {
        // 이동하고자하는 좌표 값과 현재 내 위치의 차이를 구한다.
        float dis = Vector3.Distance(transform.position, targetPos);
        if (dis >= 0.01f) // 차이가 아직 있다면
        {
            // 캐릭터를 이동시킨다.
            transform.localPosition = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            //SetAnim(PlayerAnim.ANIM_WALK); // 걷기 애니메이션 처리
            return true;
        }
        return false;

    }
}
