using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [Header("Player Movement")]
    [SerializeField]
    private float _jumpforce = 5.0f;
    [SerializeField]
    private float _speed = 2.5f;
    [SerializeField]
    private bool resetJump = false;
    
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                return true;
            }            
        }
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump =true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
        
}
