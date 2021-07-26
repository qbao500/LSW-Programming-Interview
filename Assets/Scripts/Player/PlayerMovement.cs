using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    private PlayerInteraction interaction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        interaction = GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement vector
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement = (transform.right * x + transform.up * y).normalized * speed;
    }

    private void FixedUpdate()
    {
        if (!interaction.IsInShop)
        {
            rb.MovePosition(rb.position + movement * Time.deltaTime);
        }     
    }

}
