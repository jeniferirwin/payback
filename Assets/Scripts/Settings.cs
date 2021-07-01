using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject UpgradeOne;
    public GameObject UpgradeTwo;
    public GameObject UpgradeThree;
    public GameObject UpgradeFour;
    public GameObject UpgradeFive;

    public int CarsDestroyed { get; private set; }
    public int FrogsSplatted { get; private set; }
    public int FrogsSaved { get; private set; }
    public int Difficulty { get; private set; }
    public int weaponType { get; private set; }

    void Awake()
    {
        CarsDestroyed = 0;
        FrogsSplatted = 0;
        FrogsSaved = 0;
        Difficulty = 1;
        UpgradeOne.SetActive(true);
    }
    
    public void OnCarDestroyed()
    {
        CarsDestroyed++;
        if (CarsDestroyed == 30) UpgradeTwo.SetActive(true);
        if (CarsDestroyed == 60) UpgradeThree.SetActive(true);
        if (CarsDestroyed == 90) UpgradeFour.SetActive(true);
        if (CarsDestroyed == 120) UpgradeFive.SetActive(true);
    }
    
    public void OnFrogSplatted()
    {
        FrogsSplatted++;
    }
    
    public void OnFrogSaved()
    {
        FrogsSaved++;
    }
    
    public void Update()
    {
        Difficulty = Mathf.Max(1, FrogsSaved / 10);
    }
}