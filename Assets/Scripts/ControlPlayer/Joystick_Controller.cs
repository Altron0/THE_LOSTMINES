using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 parentPosition;
    Vector2 childPosition;

    Vector2 clamp;

    Vector2 localPosition;

    public Vector2 LocalPositionEnd;

    Vector2 Size;

    void Start()
    {
        transform.TryGetComponent(out RectTransform rectTransform);
        Size = rectTransform.rect.size;
    }

    public void OnDrag(PointerEventData mouse)
    {
        parentPosition = transform.parent.position;
        childPosition = mouse.position;

        localPosition = (parentPosition - childPosition) / (-2.25f);

        clamp = new Vector2(
            Mathf.Abs(localPosition.normalized.x),
            Mathf.Abs(localPosition.normalized.y)
        ) * (Size / 1.5f);

        LocalPositionEnd = new Vector2(
            Mathf.Clamp(localPosition.x, -clamp.x, clamp.x),
            Mathf.Clamp(localPosition.y, -clamp.y, clamp.y)
        ) * 2f;

        transform.localPosition = LocalPositionEnd;
    }

    public void OnEndDrag(PointerEventData mouse)
    {
        transform.localPosition = Vector2.zero;
        LocalPositionEnd = Vector2.zero;
    }
}
