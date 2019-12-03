using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> panels;
    public GameObject selector;
    public Vector3 offset = new Vector3(0, 0, 0);

    List<GameObject> items;
    int selectedItem = -1; // index in items
    float maxWidth = 675.5F;
    float maxHeight = 336.5F;

    public GameObject GetSelectedItem()
    {
        if (selectedItem == -1) {
            return null;
        } else {
            return items[selectedItem];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
        foreach(GameObject panel in panels)
        {
            var itemName = panel.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
            itemName.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (items.Count > 0) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                selectedItem = 0;
                ShowSelectedItem(selectedItem);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                selectedItem = Mathf.Min(1, items.Count - 1);
                ShowSelectedItem(selectedItem);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                selectedItem = Mathf.Min(2, items.Count - 1);
                ShowSelectedItem(selectedItem);
            }
        } else {
            selectedItem = -1;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "PickUp" && Input.GetAxis("Jump") != 0) {
            AddItem(other.gameObject);
        }
    }

    void AddItem(GameObject item)
    {
        items.Add(item);
        var panel = panels[items.IndexOf(item)];
        var itemName = panel.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        var imgObj = panel.transform.GetChild(1).gameObject;
        var imgRectTransform = imgObj.GetComponent<RectTransform>();
        var itemImage = imgObj.GetComponent<UnityEngine.UI.Image>();
        // Change name
        itemName.text = item.name;
        // Add item to panel
        itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        if (item.name == "ID Card") {
            imgRectTransform.sizeDelta = new Vector2(itemImage.sprite.rect.width * 10, itemImage.sprite.rect.height * 10);
        } else if (item.name == "Scissors") {
            imgRectTransform.Rotate(0.0F, 0.0F, 99.29301F);
            imgRectTransform.sizeDelta = new Vector2(itemImage.sprite.rect.width * 10, itemImage.sprite.rect.height * 10);
        } else {
            imgRectTransform.sizeDelta = new Vector2(Mathf.Min(maxWidth, itemImage.sprite.rect.width), Mathf.Min(maxHeight, itemImage.sprite.rect.height));
        }

        // Destroy object
        Destroy(item);
    }

    void ShowSelectedItem(int index)
    {
        var selectorImg = selector.GetComponent<UnityEngine.UI.Image>();
        if (index == -1) {
            selectorImg.color = new Color(selectorImg.color.r, selectorImg.color.g, selectorImg.color.b, 0.0F);
        } else {
            if (selectorImg.color.a == 0.0F) {
                selectorImg.color = new Color(selectorImg.color.r, selectorImg.color.g, selectorImg.color.b, 0.9F);
            }

            selector.transform.position = panels[index].transform.position + offset;
        }
    }
}
