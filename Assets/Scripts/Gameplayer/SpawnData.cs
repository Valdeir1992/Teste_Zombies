using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototipo/Data/Spawn")]
public class SpawnData : ScriptableObject
{
    [SerializeField] private List<Wave> _listWaves;

    [SerializeField] private int _totalZombies; 
    public List<Wave> ListWaves { get => _listWaves; }  
    public int TotalZombies { get => _totalZombies; }


}
