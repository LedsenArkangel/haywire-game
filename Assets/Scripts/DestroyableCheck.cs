using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCheck : MonoBehaviour
{
    public List<DestroyableBehavior> destroyables;
    public string messageToFlowchart;
    bool message1 = false;
    bool message2 = false;
    bool message3 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var count = destroyables.FindAll(d => d.isDestroyed).Count;
        if (!message1 && count == 1) {
            message1 = true;
            Fungus.Flowchart.BroadcastFungusMessage("CutWire1");
        }
        if (!message2 && count == 2) {
            message2 = true;
            Fungus.Flowchart.BroadcastFungusMessage("CutWire2");
        }
        if (!message3 && count == 3) {
            message3 = true;
            Fungus.Flowchart.BroadcastFungusMessage("CutWire3");
        }
        // if all is destroyed
        if (count == destroyables.Count) {
            Fungus.Flowchart.BroadcastFungusMessage(messageToFlowchart);
        }
    }
}
