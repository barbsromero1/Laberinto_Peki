using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Peki : MonoBehaviour
{

    // Start is called before the first frame update
    public float upForce;
    public float speed = 0.5f;
    private bool isDead = false;

    Vector3 localScale;

    private Rigidbody2D rigi;
    Animator anim;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            rigi.velocity = Vector2.zero;
            rigi.AddForce(new Vector2(0, upForce));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            var dir = Input.GetAxis("Horizontal");

            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Translate(Vector2.right * speed * dir * Time.deltaTime);
                transform.localScale = new Vector3(dir > 0 ? localScale.x : -localScale.x, localScale.y, localScale.z);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isDead = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
        }
    }
}
