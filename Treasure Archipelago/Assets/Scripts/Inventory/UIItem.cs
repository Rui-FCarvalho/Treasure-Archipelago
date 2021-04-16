using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Display
    public Item item;
    private Image spriteImage;
    public Text stack;

    //Drag and drop stuff
    Vector3 _startPos;
    Transform _originalParent;
    Transform canvas;
    public SlotIndexUI _parentSlot;

    private void Awake()
    {
        _parentSlot = GetComponentInParent<SlotIndexUI>();
        canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        
        spriteImage = GetComponent<Image>();
        stack = GetComponentInChildren<Text>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.Icon;
            stack.text = this.item.stack.ToString();
        }
        else
        {
            spriteImage.color = Color.clear;
            spriteImage.sprite = null;
            stack.text = null;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPos = transform.position;
        _originalParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(canvas);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = _startPos;
        transform.SetParent(_originalParent);
    }
}
