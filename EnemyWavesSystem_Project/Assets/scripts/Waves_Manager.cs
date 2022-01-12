using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves_Manager : MonoBehaviour
{
    [SerializeField] private WaveData[] _waves;

    public struct CurrentWaveData 
    {
        public int waveNumber;
        public WaveData waveData;
    }
    CurrentWaveData _currentWaveData;

    public static Waves_Manager instance;

    private void Awake()
    {
        HandleInstances();
    }

    private void Start()
    {
        InitCurrentWaveData();
        StartCurrentWave();
    }

    private void StartCurrentWave() 
    {
        Spawns_Manager.instance.SpawnWave(_currentWaveData.waveData);
    }

    public void StartNextWave() 
    {
        ++_currentWaveData.waveNumber;

        if (_currentWaveData.waveNumber >= _waves.Length) 
        {
            Debug.Log("No more waves left");
            return;
        }

        _currentWaveData.waveData = _waves[_currentWaveData.waveNumber];
        StartCurrentWave();
    }

    public CurrentWaveData GetCurrentWaveData() 
    {
        return _currentWaveData;
    }
    private void InitCurrentWaveData()
    {
        _currentWaveData.waveNumber = 0;
        _currentWaveData.waveData = _waves[0];
    }
    private void HandleInstances()
    {
        if (Waves_Manager.instance == null)
        {
            Waves_Manager.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
