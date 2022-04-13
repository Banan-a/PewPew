using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header ("Prefabs")]
    public Projectile projectile;
    

    [Header ("Fire Rate/ CoolDown")]
    public float coolDown = 0.1f;
    protected float coolDownTimer = 0f;

    
    [Header ("Offset")]
    public float offset;

    [Header ("Other")]
    public SpriteRenderer spriteRenderer;
    public float randomAngle = 1f;
    public Transform brarrel;

    //
    protected float rotationZ = 0f;

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer > 0f) {
            coolDownTimer -= Time.deltaTime;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * 180 / Mathf.PI;
        if (rotationZ < 0) {
            rotationZ += 360f;
        }
        
        if (rotationZ > 270f || rotationZ < 90f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }

        if (rotationZ > 16f && rotationZ < 165f) {
            spriteRenderer.sortingOrder = -1;
        } else {
            spriteRenderer.sortingOrder = 1;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);
    }

    public bool tryToTriggerWeapon() {
        if (coolDownTimer > 0f) {
            return false;
        }

        coolDownTimer = coolDown;
        
        triggerWeapon();

        return true;
    }

    protected void triggerWeapon() {
        instantiateBullet();
    }

    protected virtual void instantiateBullet() {
        if (CameraShaking.Instance != null) {
            CameraShaking.Instance.ShakeCamera(1f, .1f);
        }
        
        var angle = Random.Range(-5f, 5f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotationZ + angle);
        Instantiate(projectile, brarrel.position, rotation);
    }
}
