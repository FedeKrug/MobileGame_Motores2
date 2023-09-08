using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyController : Controller, IDragHandler, IEndDragHandler
{
    Vector3 dir;
    Vector3 initPos;

    float maxDistance = 200;
    [SerializeField] RectTransform baseImg = null;

    private void Start()
{
        initPos = transform.position;
        maxDistance = baseImg.rect.width / 2;
    }

    public override Vector3 MoveDir()
    {
        Vector3 dirTemp = new Vector3(dir.x, 0, dir.y);
        return dirTemp / maxDistance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dir = Vector3.ClampMagnitude((Vector3)eventData.position - initPos, maxDistance);
        transform.position = initPos + dir;
        
    }

    public void OnEndDrag(PointerEventData eventData)
{
        transform.position = initPos;
        dir = Vector3.zero;
    }
}
