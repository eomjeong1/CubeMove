using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    private CheckMove behavior; // ĳ������ �ൿ ��ũ��Ʈ
    private Camera mainCamera; // ���� ī�޶�
    private Vector3 targetPos; // ĳ������ �̵� Ÿ�� ��ġ
    public RaycastHit hitLayerMask;

    void Start()
    {
        behavior = GetComponent<CheckMove>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        
        
        // ���콺 �Է��� �޾� �� ��
        if (Input.GetMouseButtonUp(0))
        {
            // ���콺�� ���� ��ġ�� ��ǥ ���� �����´�
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
            int layerMask = 1 << LayerMask.NameToLayer("Stage");
            
            if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
            {
                targetPos = hitLayerMask.point + new Vector3(0, 0.55f, 0);
            }
        }

        // ĳ���Ͱ� �����̰� �ִٸ�
        if (behavior.Run(targetPos))
        {
            // ȸ���� ���� �����ش�
            behavior.Turn(targetPos);

        }
        

    }
}

