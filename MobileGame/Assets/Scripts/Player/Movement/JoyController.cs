using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyController : Controller, IDragHandler, IEndDragHandler
{
    Vector3 dir;
    Vector3 initPos;
    [SerializeField] private Animator _anim;
    [SerializeField] private string _movingAnimationParameter;
    float maxDistance = 200;
    [SerializeField] RectTransform baseImg = null;

    [SerializeField] PlayerShootingTest _playerRef;

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
        _playerRef.Moving = true;
        _anim.SetBool(_movingAnimationParameter, true);
    }

    public void OnEndDrag(PointerEventData eventData)
{
        transform.position = initPos;
        dir = Vector3.zero;
        _anim.SetBool(_movingAnimationParameter, false);
        _playerRef.Moving = false;
    }
}
