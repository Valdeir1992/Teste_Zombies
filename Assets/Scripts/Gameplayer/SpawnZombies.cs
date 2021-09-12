using System;
using System.Collections;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private SpawnData _data;
    private IGameplayer _gameplayer;
    private bool _completed = false;
    private int _count;
    private int _totalZombieInTheWave;
    private int _deadZombis;
    private float _time;

    private void Awake()
    {
        _gameplayer = Datafactory.Instance.GetGameplayerComponent();
    }
    private void Update()
    {
        if(_count < _data.ListWaves.Count && _time <= _data.ListWaves[_count].Seconds)
        { 
            _time += Time.deltaTime;
        }
        else
        {
            SpawnZombie();
            _time = 0;
        }
    }

    private void SpawnZombie()
    {
        int count = 0;

        if (!_completed)
        {
            while (_totalZombieInTheWave < _data.ListWaves[_count]._listZombies.Count  && count != _data.ListWaves[_count].NumberSpawnedZombies)
            { 
                Zombie newZombie = Instantiate(_data.ListWaves[_count]._listZombies[_totalZombieInTheWave], _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);

                newZombie.CallBackDead += (zombie) =>
                {
                    _deadZombis++;

                    _gameplayer.AddPoints(zombie.Data.Points);

                    if (_deadZombis == _data.TotalZombies)
                    {
                        _gameplayer.GameOver();
                    } 

                    Destroy(zombie.gameObject);
                };

                _totalZombieInTheWave++;

                count++;
            }
            if (_totalZombieInTheWave == _data.ListWaves[_count]._listZombies.Count)
            {
                _count++; 
                _totalZombieInTheWave = 0;
                if (_count == _data.ListWaves.Count)
                {
                    _completed = true;
                }
            }
        } 
    } 
}
