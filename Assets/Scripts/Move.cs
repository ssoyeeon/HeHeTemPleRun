using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public int JumpPower;
    public int SitPower;
    public float PlayPower;
    public Camera cam;

    private Rigidbody rigid;

    private bool IsJumping;
    private bool IsSit;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        IsJumping = false;
    }

    void Update()
    {
        Jump();
        Sit();
        LR();
    }

    void LR()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
    }

    void Sit()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {

            if(!IsSit)
            {
                IsSit = true;
                rigid.AddForce(Vector3.down * SitPower, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }
    }

    void Jump ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!IsJumping)
            {
                IsJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);

            }
            else
            {
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
            IsSit = false;
        }
    }
}
