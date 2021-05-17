using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARPlayerCubeBehaviour : MonoBehaviour
{
    public Component parent;
    private Vector4 _vector4;
    private float _angle;
    private float _sprintSpeed = 1;
    private float _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour[] buttons = parent.GetComponentsInChildren<VirtualButtonBehaviour>();
        foreach (VirtualButtonBehaviour btn in buttons)
        {
            btn.RegisterOnButtonPressed(OnButtonPressed);
            btn.RegisterOnButtonReleased(OnButtonReleased);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = _vector4.x + _vector4.y;
        float horizontal = _vector4.z + _vector4.w;

        /*
         if (Input.GetKey(KeyCode.LeftShift))
        {
            _sprintSpeed = 2;
        }
        else
        {
            _sprintSpeed = 1;
        }
         */
        _angle += horizontal * Time.deltaTime;
        float speed = (3 * vertical * Time.deltaTime) * _sprintSpeed;
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

    private void OnButtonPressed(VirtualButtonBehaviour button)
    {
        switch (button.VirtualButtonName)
        {
            case "forward":
                _vector4.x = 1;
                break;
            case "backward":
                _vector4.y = -1;
                break;
            case "right":
                _vector4.w = 1;
                break;
            case "left":
                _vector4.z = -1;
                break;
        }
    }

    private void OnButtonReleased(VirtualButtonBehaviour button)
    {
        switch (button.VirtualButtonName)
        {
            case "forward":
                _vector4.x = 0;
                break;
            case "backward":
                _vector4.y = 0;
                break;
            case "right":
                _vector4.w = 0;
                break;
            case "left":
                _vector4.z = 0;
                break;
        }
    }
}