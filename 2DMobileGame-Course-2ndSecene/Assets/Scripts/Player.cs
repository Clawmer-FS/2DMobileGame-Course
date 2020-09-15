using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //get handle to rigidbody
    private Rigidbody2D _rigid;
    //variable jump force
    [SerializeField]
    private float _jumpforce = 5.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        //assign handle of rigidbody
        _rigid = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //check horizontal input left, right
        float move= Input.GetAxisRaw("Horizontal");

        //access rigidboyd and set volicity
        //current volicity = new velocity (horizontal input, current.velocity.y)
        _rigid.velocity = new Vector2(move, _rigid.velocity.y);

        //check Input Spacebar & grounded = true
        //velocity (curent, input)
    }
}
