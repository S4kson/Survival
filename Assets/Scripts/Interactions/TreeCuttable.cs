using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    private int _dropCount;
    [SerializeField] private float _duration = 2f; // ������������ ����� � ��������
    private bool _isChopping = false; // ���� ��������� �����
    private float _chopTimer = 0f; // ������ ��� ������������ ������� �����
    [SerializeField] private GameObject _pickUpDrop;
    [SerializeField] private float spread = 0.7f;
    
    private void Awake()
    { 
       _dropCount = UnityEngine.Random.Range(2, 5);
    }
    public override void Hit()
    {
        while (_dropCount > 0)
        {
            _dropCount--;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject gameObject = Instantiate(_pickUpDrop);
            gameObject.transform.position = position;
        }

        Destroy(gameObject);
    }

    public override void ExecutionProcess()
    {
        // ���������, ������ �� ������ Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // ��������� ����� ������
            _isChopping = true;
            _chopTimer = _duration;
        }

        // ��������� ��������� �����
        if (_isChopping)
        {
            // ����� ������ (����� ������������ �������� ��� �������� ������ ���������)
            //Debug.Log("Chopping tree...");

            // ��������� ������ �����
            _chopTimer -= Time.deltaTime;

            // ���������, ������� �� ����� �����
            if (_chopTimer <= 0f)
            {
                // ������������� �����
                _isChopping = false;
                //Debug.Log("Tree chopped!");
                Hit();
            }
        }
        
    }

}
