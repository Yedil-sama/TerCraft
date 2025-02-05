using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public Item item;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.parent.parent.GetComponent<InventorySlot>() != null) transform.parent.parent.GetComponent<InventorySlot>().item = null;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.parent.parent.parent.transform);
        transform.SetAsLastSibling();
        item.icon.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        item.icon.raycastTarget = true;
    }
}
