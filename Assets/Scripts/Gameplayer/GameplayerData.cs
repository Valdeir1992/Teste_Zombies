using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/Gameplayer")]
public class GameplayerData : ScriptableObject, IGameplayerData
{
    private int _selectedCharacter;

    public int SelectedCharacter
    {
        get => _selectedCharacter;
    }

    public void SetCharacter(int value)
    {
        _selectedCharacter = value;
    }
}
