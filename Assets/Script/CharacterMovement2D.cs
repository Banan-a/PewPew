using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    [Range(0, 50)] [SerializeField] private float speed = 20;

    public Gun gun;

    //local variable
    Vector2 movement;
    Rigidbody2D rigidbody2D;
    Camera cam;
    Vector2 mousePos;
    Animator animator;

    bool isMoving;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        isMoving = !movement.Equals(new Vector2(0,0));

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * 180 / Mathf.PI;

        var vectorMouse = new Vector2(mousePos.x, mousePos.y).normalized;

        if (Input.GetMouseButtonDown(0)) {
            gun.tryToTriggerWeapon();
            Debug.Log("Check");
        }

        animator.SetFloat("MouseHorizontal", mousePos.x);
        animator.SetFloat("MouseVertical", mousePos.y);
        animator.SetBool("IsMoving", isMoving);
    }

    private void FixedUpdate() {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
    }



}
