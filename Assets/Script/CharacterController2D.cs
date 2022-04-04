using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, 100)] [SerializeField] private float speed = 20;
    [Range(0, .3f)] private float movementSmoothing = .2f;

    

    //local variable
    Vector2 movement;
    Rigidbody2D rigidbody2D;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
    }


}
