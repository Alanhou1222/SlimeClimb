using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeMode : MonoBehaviour
{
    public float speed;
    private float HmoveInput;
    private float VmoveInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        HmoveInput = Input.GetAxisRaw("Horizontal");
        VmoveInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(HmoveInput * speed, VmoveInput*speed);

    }
}
