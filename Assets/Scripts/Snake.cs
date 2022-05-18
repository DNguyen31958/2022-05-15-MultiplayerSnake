using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Snake : MonoBehaviourPunCallbacks
{
    public Transform _segmentPrefab;
    private List<Transform> _segmentList = new List<Transform>();
    private Vector2 _direction = Vector2.right;
    private BoxCollider2D _gridArea;
    private PhotonView _pView;
    private GameHolder _gameHolderScript;

    private void Start()
    {
        _segmentList.Add(this.transform);
        _gridArea = GameObject.FindGameObjectWithTag("Grid").GetComponent<BoxCollider2D>();
        _pView = GetComponent<PhotonView>();
        _gameHolderScript = GameObject.FindGameObjectWithTag("GameHolder").GetComponent<GameHolder>();
    }

    private void RandomPosition()
    {
        Bounds bounds = _gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    private void Update()
    {
        if(_pView.IsMine)
        {
            DirectionChange();
        }

    }

    private void DirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            _direction = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segmentList.Count - 1; i > 0; i--) 
        {
            _segmentList[i].position = _segmentList[i - 1].position;
        }
        float x = Mathf.Round(this.transform.position.x) + _direction.x;
        float y = Mathf.Round(this.transform.position.y) + _direction.y;
        this.transform.position = new Vector2(x, y);
    }

    public void Grow()
    {
        GameObject segment = PhotonNetwork.Instantiate(_segmentPrefab.name, _segmentList[_segmentList.Count - 1].position, Quaternion.identity);
        _segmentList.Add(segment.transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        } 
        if (other.tag == "Wall") 
        {
            _gameHolderScript.SetMessageText("Hit Wall");
            Reset();
        }
        if(other.tag == "Snake")
        {
            _gameHolderScript.SetMessageText("Hit Self");
            Reset();
        }
    }

    private void Reset()
    {
        for(int i = 1; i < _segmentList.Count; i++)
        {
            PhotonNetwork.Destroy(_segmentList[i].gameObject);
        }
        _segmentList.Clear();
        _segmentList.Add(this.transform);
        RandomPosition();
    }

}
