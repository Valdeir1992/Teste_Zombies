using UnityEngine;

/// <summary>
/// Script responsável  por gerenciar inputs do jogador.
/// </summary>
public class InputPlayer : IInput
{
    public Vector3 Direction()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public bool Fire()
    {
        return Input.GetMouseButton(0);
    }

    public int SelectedCharacter()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return -1;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            return 1;
        }
        return 0;
    }
}