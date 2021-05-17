using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCollectables : MonoBehaviour
{
    public int amount = 1;
    public Transform coinPrefab;
    public float safeArea = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 p = transform.position;
        Vector3 s = transform.lossyScale;

        for (int i = 0; i < amount; i++)
        {
            float rangeX = Random.Range(p.x - s.x, p.x + s.x) * (1 - safeArea);
            float rangeZ = Random.Range(p.z - s.z, p.z + s.z) * (1 - safeArea);
            Instantiate(coinPrefab, new Vector3(rangeX, p.y, rangeZ), coinPrefab.rotation, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}