using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    private CheckMove behavior; // 캐릭터의 행동 스크립트
    private Camera mainCamera; // 메인 카메라
    private Vector3 targetPos; // 캐릭터의 이동 타겟 위치
    public RaycastHit hitLayerMask;

    void Start()
    {
        behavior = GetComponent<CheckMove>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        
        
        // 마우스 입력을 받았 을 때
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스로 찍은 위치의 좌표 값을 가져온다
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
            int layerMask = 1 << LayerMask.NameToLayer("Stage");
            
            if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
            {
                targetPos = hitLayerMask.point + new Vector3(0, 0.55f, 0);
            }
        }

        // 캐릭터가 움직이고 있다면
        if (behavior.Run(targetPos))
        {
            // 회전도 같이 시켜준다
            behavior.Turn(targetPos);

        }
        

    }
}

