using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FoodSpawn : MonoBehaviourPunCallbacks
{
    public GameObject _foodPrefab;
    private BoxCollider2D _gridArea;

    void Start()
    {
        if(GameHolder._isFoodActive == false)
        {
            _gridArea = GameObject.FindGameObjectWithTag("Grid").GetComponent<BoxCollider2D>();
            RandomPosition();
            GameHolder._isFoodActive = true;
        }
    }

    private void RandomPosition()
    {
        Bounds bounds = _gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        PhotonNetwork.Instantiate(_foodPrefab.name, new Vector2(Mathf.Round(x), Mathf.Round(y)), Quaternion.identity);
    }
}
