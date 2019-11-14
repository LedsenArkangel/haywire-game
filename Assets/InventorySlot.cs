using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    string name;
    // Start is called before the first frame update
    public void AddItem(string name,Image icon)
    {

    }

    public void ClearSlot()
    {
       
        icon.sprite = null;
        icon.enabled = false;
    }
}
