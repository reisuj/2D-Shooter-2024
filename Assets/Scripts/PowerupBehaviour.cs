using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int PowerUpID; // 0 = TripleShot, 1 = Speed, 2 = Shield
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {  
                if (PowerUpID == 0)
                {
                    player.TripleShotActive();
                }
                else if (PowerUpID == 1)
                {
                    Debug.Log("Speed Powerup Collected");
                }
                else if (PowerUpID == 2)
                {
                    Debug.Log("Shield Powerup Collected");
                }                
            }
            Destroy(this.gameObject);
        }
    }
}
