using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.0f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _nextFire = 0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();  
        
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {            
            FireLaser();
        }
    }

    void PlayerMovement()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        float _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _horizontalInput * _playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * _verticalInput * _playerSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.0f, 0), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _nextFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}

