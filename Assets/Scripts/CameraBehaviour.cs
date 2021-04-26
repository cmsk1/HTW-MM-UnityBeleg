using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public float hor;
    public float ver;
    public float speeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, -ver, hor);
        Vector3 offsetRotation = target.rotation * offset;

        Quaternion targetRotation = Quaternion.LookRotation(offsetRotation);

        transform.position = target.position - offsetRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speeed * Time.deltaTime);
    }
}