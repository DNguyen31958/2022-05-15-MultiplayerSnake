using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private BoxCollider2D _gridArea;

    private void Start()
    {
        _gridArea = GameObject.FindGameObjectWithTag("Grid").GetComponent<BoxCollider2D>();
    }

    private void RandomPosition()
    {
        Bounds bounds = _gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Snake")
        {
            RandomPosition();
        }
    }
}
