using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerUpID; // 0 = TripleShot, 1 = Speed, 2 = Shield
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

            switch(_powerUpID)
            {
                case 0:
                    player.TripleShotActive();
                    break;
                case 1:
                    player.SpeedPowerupActive();
                    break;
                case 2:
                    player.ShieldPowerupActive();
                    break;
                default:
                    Debug.Log("Default Value");
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
