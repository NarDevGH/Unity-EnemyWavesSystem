using System.Collections.Generic;
using UnityEngine;

public class Enemys_Manager : MonoBehaviour
{
    public bool allEnemysSpawn;
    private List<GameObject> _inGameEnemys;

    public static Enemys_Manager instance;

    private void Awake()
    {
        HandleInstances();
        _inGameEnemys = new List<GameObject>();
    }

    public void Add(GameObject enemy) 
    {
        _inGameEnemys.Add(enemy);
    }

    public void Remove(GameObject enemy)
    {
        _inGameEnemys.Remove(enemy);

        if (_inGameEnemys.Count <= 0 && allEnemysSpawn) 
        {
            allEnemysSpawn = false;
            Waves_Manager.instance.StartNextWave();
        }
    }

    public List<GameObject> GetInGameEnemys() 
    {
        return _inGameEnemys;
    }

    private void HandleInstances()
    {
        if (Enemys_Manager.instance == null)
        {
            Enemys_Manager.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
