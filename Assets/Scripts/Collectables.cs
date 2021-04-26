using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int quantity = 1;
    public Transform myPrefab;
    public Transform ground;
    public float safeArea = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        float x = ground.lossyScale.x / 2;
        float z = ground.lossyScale.z / 2;

        for (int i = 0; i < quantity; i++)
        {
            float rangeX = Random.Range(ground.position.x - x, ground.position.x + x) * (1 - safeArea);
            float rangeZ = Random.Range(ground.position.z - z, ground.position.z + z) * (1 - safeArea);

            Instantiate(myPrefab, new Vector3(rangeX, ground.position.y + 1, rangeZ), myPrefab.rotation,
                this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}