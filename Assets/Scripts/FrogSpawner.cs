using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    public GameObject frogPrefab;
    private float cooldown;

    private void Awake()
    {
        cooldown = GetCooldown();
    }
    
    private float GetCooldown()
    {
        return Random.Range(10f,15f);
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            cooldown = GetCooldown();
            ReleaseFrog();
        }
    }
    
    void ReleaseFrog()
    {
        var newFrog = GameObject.Instantiate(frogPrefab,transform.position,transform.rotation);
        newFrog.transform.Rotate(0,-90,0);
        var frogController = newFrog.GetComponent<FrogController>();
        switch (Random.Range(1,6))
        {
            case 1:
              frogController.Blue();
              break;
            case 2:
              frogController.BalckOnRedSpot();
              break;
            case 3:
              frogController.OrangeBlackBlue();
              break;
            case 4:
              frogController.RedGreenBlack();
              break;
            case 5:
              frogController.Yellow();
              break;
            default:
              frogController.YellowOnBlack();
              break;
        }
    }
}
