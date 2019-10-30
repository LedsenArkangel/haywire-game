using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFloatMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDiff = mainCharacter.transform.position.x - transform.position.x;
        if (xDiff > 0)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
    }
}
