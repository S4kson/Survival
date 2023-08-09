using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public float offset;
    private int sortingOrderBase = 2;
    private Renderer renderer;
    private void Awake()
    {
        renderer = GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y + offset); 
    }
}
