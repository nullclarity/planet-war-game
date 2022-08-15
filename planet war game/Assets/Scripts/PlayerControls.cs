using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _anim;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private float _horizontal, _vertical;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal") * _moveSpeed;
        _vertical = Input.GetAxis("Vertical") * _moveSpeed;
        Vector3 _moveDir = new Vector3(_horizontal, 0, _vertical);
        if(_moveDir.magnitude > Mathf.Abs(0.1f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_moveDir), Time.deltaTime * _rotationSpeed);
        _anim.SetFloat("speed", Vector3.ClampMagnitude(_moveDir, 1).magnitude);
        _rb.velocity = Vector3.ClampMagnitude(_moveDir, 1) * _moveSpeed;
    }
}
