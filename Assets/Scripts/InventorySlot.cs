using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Item item;
    public int ind;
    public Image selectedImage;
    public GameObject itemHolder;

    private void Start()
    {
        selectedImage.enabled = false;
        if (itemHolder.transform.childCount > 0) item = itemHolder.transform.GetChild(0).GetComponent<Item>();
    }
    public void OnClick()
    {
        if (GameManager.Instance.selectedSlot == this)
        {
            selectedImage.enabled = false;
            GameManager.Instance.selectedSlot = null;
        }
        else if (GameManager.Instance.selectedSlot == null)
        {
            selectedImage.enabled = true;
            GameManager.Instance.selectedSlot = this;
        }
        else
        {
            GameManager.Instance.selectedSlot.selectedImage.enabled = false;
            selectedImage.enabled = true;
            GameManager.Instance.selectedSlot = null;
            GameManager.Instance.selectedSlot = this;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        Item droppedItem = droppedObject.GetComponent<Item>();

        if (item == null)
        {
            droppedObject.GetComponent<Draggable>().parentAfterDrag = itemHolder.transform;
            item = droppedItem;
        }
        else
        {
            droppedObject.GetComponent<Draggable>().parentAfterDrag.parent.GetComponent<InventorySlot>().item = droppedItem;

        }
    }

}