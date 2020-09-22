using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _targetWaypoint;

    private Animator _anim;
    private SpriteRenderer _mossGiantSprite;


    // Start is called before the first frame update
    public void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _mossGiantSprite = GetComponentInChildren<SpriteRenderer>();


    }


    public override void Update()
    {
        Sentry();
        Facing();
    }

    void Sentry()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        if (transform.position == pointA.position)
        {
            _targetWaypoint = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _targetWaypoint = pointA.position;
            _anim.SetTrigger("Idle");

        }

        transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint, speed * Time.deltaTime);
    }

    void Facing()
    {
        if (_targetWaypoint == pointA.position)
        {
            _mossGiantSprite.flipX = true;
            Debug.Log("I Flip Right");

        }
        else if (_targetWaypoint == pointB.position)
        {
            _mossGiantSprite.flipX = false;
            Debug.Log("I Flip Left");
        }
    }


}
