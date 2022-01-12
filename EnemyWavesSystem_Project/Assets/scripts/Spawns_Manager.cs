using UnityEngine;

public class Spawns_Manager : MonoBehaviour
{

    [SerializeField] private GameObject Spawn;
    private ISpawner _spawn;

    public static Spawns_Manager instance;

    private void Awake()
    {
        HandleInstances();
        _spawn = Spawn.GetComponent<ISpawner>();
        if (_spawn == null)
        {
            Debug.LogError("Spawner gameobject doesnt have ISpawner Component");
        }
    }


    public void SpawnWave(WaveData wave) 
    {
        _spawn.StartWave(wave);
    }

    private void HandleInstances()
    {
        if (Spawns_Manager.instance == null)
        {
            Spawns_Manager.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
