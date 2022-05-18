using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SnakeSpawn : MonoBehaviourPunCallbacks
{
    public BoxCollider2D _gridArea;
    public GameObject _snakePrefab;

    void Start()
    {
        RandomPosition();
    }

    private void RandomPosition()
    {
        Bounds bounds = _gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        PhotonNetwork.Instantiate(_snakePrefab.name, new Vector2(Mathf.Round(x), Mathf.Round(y)), Quaternion.identity);
    }

}
