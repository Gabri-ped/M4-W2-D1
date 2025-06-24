using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float _groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask _groundLayer;
    public bool IsGrounded { get; private set; }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * _groundCheckDistance);
    }

    void Update()
    {
        IsGrounded = Physics.Raycast(transform.position,-Vector3.up, _groundCheckDistance);
    }
}
