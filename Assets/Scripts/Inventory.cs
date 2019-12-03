using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> panels;
    List<GameObject> items;
    int selectedItem = -1;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
        foreach(GameObject panel in panels)
        {
            var txtName = panel.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
            txtName.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        var panel = panels[items.IndexOf(item)];
        var txtName = panel.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        // Change name
        txtName.text = item.name;
        // Add item to panel
        item.transform.position = panel.transform.position;
    }
}
