using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerAnimation _playerAnim;
    

    [Header("Player Movement")]
    [SerializeField]
    private float _jumpforce = 5.0f;
    [SerializeField]
    private float _speed = 2.5f;
    [SerializeField]
    private bool resetJump = false;

    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
        
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnim.Attack();
        }
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        IsGrounded();
        Flip(move);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jumping(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        _playerAnim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                _playerAnim.Jumping(false);
                return true;
            }            
        }
        return false;
    }

    void Flip(float move)
    {
        if (move > 0)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.0f;
            _swordArcSprite.transform.localPosition = newPos;

        }
        else if (move < 0)
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.0f;
            _swordArcSprite.transform.localPosition = newPos;

        }
    }

    void Attack()
    {
        _playerAnim.Attack();
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump =true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
        
}
