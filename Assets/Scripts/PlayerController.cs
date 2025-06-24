using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    private Rigidbody _rb;
    [SerializeField] private GroundCheck _groundCheck;
    private int _jumpCount = 0;
    private int _maxJumps = 2;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
        
    }


    void Update()
    {
        if (_groundCheck.IsGrounded)
        {
            _jumpCount = 0; 
        }

        Jump();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion smoothed = Quaternion.Slerp(_rb.rotation, targetRotation, 25f * Time.deltaTime);
            _rb.MoveRotation(smoothed);
        }
        
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed *= 4f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 5f;
        }

        _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));

       
    }

  private void Jump()
    {
       if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumps)
         {
           _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumpCount++;
         }
    }
 }   
 

