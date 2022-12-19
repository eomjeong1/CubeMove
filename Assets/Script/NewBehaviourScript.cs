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
        // �̵��ϰ����ϴ� ��ǥ ���� ���� �� ��ġ�� ���̸� ���Ѵ�.
        float dis = Vector3.Distance(transform.position, targetPos);
        if (dis >= 0.01f) // ���̰� ���� �ִٸ�
        {
            // ĳ���͸� �̵���Ų��.
            transform.localPosition = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            //SetAnim(PlayerAnim.ANIM_WALK); // �ȱ� �ִϸ��̼� ó��
            return true;
        }
        return false;

    }
}
