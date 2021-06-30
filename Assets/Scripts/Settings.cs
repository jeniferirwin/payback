using UnityEngine;

public class Settings : MonoBehaviour
{
    public int CarsDestroyed { get; private set; }
    public int FrogsSplatted { get; private set; }
    public int Difficulty { get; private set; }

    void Start()
    {
        CarsDestroyed = 0;
        FrogsSplatted = 0;
        Difficulty = 1;
    }
    
    public void OnCarDestroyed()
    {
        CarsDestroyed++;
    }
    
    public void OnFrogSplatted()
    {
        FrogsSplatted++;
    }
    
    public void Update()
    {
        Difficulty = CarsDestroyed / 20 - FrogsSplatted / 10;
    }
}