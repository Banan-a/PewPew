using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header ("Information")]
    public float speed = 20f;
    public float lifeTime = 6f;
    public float distance = 0.5f;

    [Header ("Damage")]
    public int damage = 1;

    [Header ("Effect")]
    public GameObject destroyEffect;
    
    [Header ("Layers")]
    public LayerMask solidLayer;
    public LayerMask entitiesLayer;

    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, entitiesLayer);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Character")) {
                Debug.Log("damaged");
                hitInfo.collider.GetComponent<HealthSystem>().TakeDamage(damage);
            }
            destroyProjectile();
        }
        position = new Vector2 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }

    protected void destroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == (int)Mathf.Log(solidLayer.value, 2)) {
            destroyProjectile();
        }
    }

}
