using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Settings settings;
    public GameObject[] carPrefabs;
    private float cooldown;

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0f)
        {
            var percentage = 1f - (settings.Difficulty + 10) / 10 * -1;
            Debug.Log($"Percentage is {percentage}.");
            var minCooldown = 2 * percentage;
            var maxCooldown = 5 * percentage;
            Debug.Log($"Setting cooldown between {minCooldown} and {maxCooldown}...");
            cooldown = Random.Range(2 * percentage, 5 * percentage);
            Debug.Log($"Cooldown is {cooldown}.");
            SpawnCar();
        }
    }
    
    private void SpawnCar()
    {
        var type = Random.Range(0, carPrefabs.Length);
        var newCar = GameObject.Instantiate(carPrefabs[type],transform.position,transform.rotation);
        newCar.AddComponent<CarBehavior>();
        newCar.SetActive(true);
    }
}
