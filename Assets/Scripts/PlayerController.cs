using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    float halfScreenWidth;
    float halfPlayerWidth;
    public event System.Action OnPlayerDeath;
    public GameObject explosionPrefab;
    public AudioSource explodeSound;
    void Start()
    {
        halfPlayerWidth = transform.localScale.x/2f;
        halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float velocity = speed * input;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -halfScreenWidth - halfPlayerWidth){
            transform.position = new Vector2(halfScreenWidth, transform.position.y);
        }

        if (transform.position.x > halfScreenWidth + halfPlayerWidth){
            transform.position = new Vector2(-halfScreenWidth, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider){
        if(triggerCollider.tag == "Falling Block"){
            if(OnPlayerDeath != null){
                Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
                explodeSound.PlayOneShot(explodeSound.clip);
                Destroy(gameObject);
                OnPlayerDeath();
            }
            // Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            // Destroy(gameObject);
        }
    }
}
