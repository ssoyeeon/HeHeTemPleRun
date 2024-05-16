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
    private bool _Run;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        IsJumping = false;
        _Run = true;
    }

    void Update()
    {
        Jump();
        Sit();
        Run();
        LR();
    }

    void LR()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("실행");
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("실행행");
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
    }

    void Run()
    {
        if (_Run == true)
        {
            Vector3 dir = cam.transform.localRotation * Vector3.forward;
            gameObject.transform.Translate(dir * PlayPower * Time.deltaTime);
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
