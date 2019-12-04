using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCheck : MonoBehaviour
{
    public List<DestroyableBehavior> destroyables;
    public string messageToFlowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if all is destroyed
        if (!(destroyables.Exists(d => !d.isDestroyed))) {
            Fungus.Flowchart.BroadcastFungusMessage(messageToFlowchart);
        }
    }
}
