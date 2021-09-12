using UnityEngine;

/// <summary>
/// Script responsável por gerenciar inputs do mouse.
/// </summary>
public class MouseController : MonoBehaviour, IMouseController
{
    private ICharacterMediator _player;

    #region UNITY METHODS
    private void Update()
    {
        MoveCharacter();
    }
    #endregion

    #region OWN METHODS
    public void Configure(ICharacterMediator character)
    {
        _player = character;
    } 
    private void MoveCharacter()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Physics.Raycast(ray,out hit);

        if(hit.collider != null)
        {
            float distanceSqr = Vector2.SqrMagnitude(new Vector2(hit.point.x, hit.point.z) - new Vector2(transform.position.x, transform.position.z));

            if(distanceSqr >= 2 * 2)
            { 
                Vector3 pos = hit.point;

                pos.y = 0;

                transform.LookAt(pos);
            } 
        }
    }
    #endregion
}
