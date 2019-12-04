using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public List<GameObject> spawns;
    public int total = 1;
    public int maxAtATime = 50;
    public int delay = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn() {
        for(int i = 0; i < total / maxAtATime; i++) {
            for(int j = 0; j <= maxAtATime; j += spawns.Count) {
                foreach (GameObject spawn in spawns) {
                    Instantiate(spawn, transform.position, Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
