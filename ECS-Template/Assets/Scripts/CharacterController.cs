using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rgb;
    [SerializeField] private float _speed;
    [SerializeField] private float _moveH;
    [SerializeField] private bool _jump;
    [SerializeField] private float _jumpForce;

    // Update is called once per frame
    void Update()
    {
        _moveH = Input.GetAxisRaw("Horizontal");
        _jump = Input.GetButtonDown("Jump");

        Move(_moveH, _jump);
    }

    private void Move(float horizontal, bool jump)
    {
        if (Mathf.Abs(horizontal) > 0)
            _rgb.velocity = new Vector2(_moveH * _speed, _rgb.velocity.y);
        if (jump)
        {
            _rgb.velocity = Vector2.zero;
            _rgb.AddForce(new Vector2(_rgb.velocity.x, _jumpForce), ForceMode2D.Impulse);
        }
    }

}
