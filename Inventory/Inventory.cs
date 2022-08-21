using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Inventory : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject Camera;
    public Transform inventoryPanelSlots;

    public List<InventorySlot> slots = new List<InventorySlot>();
    void Start()
    {
        for (int i = 0; i < inventoryPanelSlots.childCount; i++)
        {
            if (inventoryPanelSlots.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanelSlots.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Tab"))
        {
            if (InventoryPanel.activeSelf)
            {
                InventoryPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                gameObject.GetComponent<PlayerController>().canMove = true;
                Camera.GetComponent<CinemachineFreeLook>().enabled = true;
            }
            else
            {
                InventoryPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                gameObject.GetComponent<PlayerController>().canMove = false;
                Camera.GetComponent<CinemachineFreeLook>().enabled = false;
            }
        }
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount >= _item.maximumAmount)
                {
                    if (slot.isEmpty == true)
                    {
                        slot.item = _item;
                        slot.amount = _amount;
                        slot.isEmpty = false;

                        slot.Init();
                        break;
                    }
                } else
                {
                    slot.amount += _amount;

                    slot.Init();
                    return;
                }
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;

                slot.Init();

                break;
            }
        }
    }
}
