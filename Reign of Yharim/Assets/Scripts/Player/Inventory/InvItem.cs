using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InvItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public TMP_Text countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        ReCount();
    }

    public void ReCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent; //format stuff
        transform.SetParent(transform.root); //format stuff
        transform.SetAsLastSibling(); //format stuff
        image.raycastTarget = false; //allows for us to check if there is a slot underneath
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        transform.position = mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag); //format stuff
        image.raycastTarget = true;
    }
}

