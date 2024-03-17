using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Vector3 _input;
    [SerializeField] private Transform _model;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;

    bool isMoving = false;
    public bool canMove = true;


    private void Update()
    {
        if (!canMove)
            return;

        GetInput();
        animator.SetBool("isMove", isMoving);

        Look();
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;
        Move();
    }

    private void Move()
    {

        _rb.MovePosition(transform.position + _input.ToIso() * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
    private void Look()
    {
        if (_input == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        _model.rotation = Quaternion.RotateTowards(_model.rotation, rot, _turnSpeed * Time.deltaTime);
    }


    void GetInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));

        if (_input.magnitude > 0 )
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
