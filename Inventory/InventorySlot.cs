using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Settings")]
    [SerializeField] private Transform canvas;
    [SerializeField] private Transform inventorySlots;

    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGO;
    public GameObject textAmount;
    //public TMP_Text itemAmountText;

    private void Awake()
    {
        iconGO = transform.GetChild(0).gameObject;

        //itemAmountText = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public void Init()
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = item.icon;

        textAmount.GetComponent<TextMeshProUGUI>().text = "x" + amount.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = canvas;
    }
    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = inventorySlots;
    }
}
