using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _pickUpDistance = 1.5f;
    [SerializeField] private float _ttl = 10f;       //Time to live

    private void Awake()
    {
        _player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        _ttl -= Time.deltaTime;
        if (_ttl < 0) Destroy(gameObject);

        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance > _pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, 
            _player.position, 
            _speed * Time.deltaTime
            );

        if (distance < 0.1f) 
        {
            Destroy(gameObject);
        }
    }
}
