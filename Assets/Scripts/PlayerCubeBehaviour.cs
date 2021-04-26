using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeBehaviour : MonoBehaviour
{
    private float _angle = 0;
    private float _sprintSpeed = 1;
    private float _score = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _sprintSpeed = 2;
        }
        else
        {
            _sprintSpeed = 1;
        }

        _angle += horizontal * Time.deltaTime;
        float speed = (4 * vertical * Time.deltaTime) * _sprintSpeed;
        Vector3 direction = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle));
        transform.rotation = Quaternion.LookRotation(direction);
        transform.position += speed * direction;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            _score++;
            Debug.Log("Score: " + _score);
        }
    }
}