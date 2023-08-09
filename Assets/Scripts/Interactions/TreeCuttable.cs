using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    private int _dropCount;
    [SerializeField] private float _duration = 2f; // Длительность рубки в секундах
    private bool _isChopping = false; // Флаг состояния рубки
    private float _chopTimer = 0f; // Таймер для отслеживания времени рубки
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
        // Проверяем, нажата ли кнопка Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Запускаем рубку дерева
            _isChopping = true;
            _chopTimer = _duration;
        }

        // Проверяем состояние рубки
        if (_isChopping)
        {
            // Рубим дерево (можно использовать анимацию или изменять спрайт персонажа)
            //Debug.Log("Chopping tree...");

            // Уменьшаем таймер рубки
            _chopTimer -= Time.deltaTime;

            // Проверяем, истекло ли время рубки
            if (_chopTimer <= 0f)
            {
                // Останавливаем рубку
                _isChopping = false;
                //Debug.Log("Tree chopped!");
                Hit();
            }
        }
        
    }

}
