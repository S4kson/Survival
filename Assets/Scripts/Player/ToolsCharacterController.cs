using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rb;
    [SerializeField] private float _offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) UseTool();
    }

    private void UseTool()
    {
        Vector2 position = _rb.position + _playerMovement.lastMotionVector * _offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.ExecutionProcess();
                break;
            }
        }
    }
}
