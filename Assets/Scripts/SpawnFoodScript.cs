using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFoodScript : MonoBehaviour
{
    [SerializeField]
    private GameObject FoodPrefab;
    public float x1 = 0;
    public float x2 = 0;
    public float y1 = 0;
    public float y2 = 0;

    private int maxFood = 20;
    private int foodNum = 0;

    void Start()
    {
        for(int i = 0; i < maxFood; i++)
        {
            GameObject food = Instantiate(FoodPrefab);
            food.transform.position = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
