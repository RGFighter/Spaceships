using Gameplay;
using Gameplay.Helpers;
using UnityEngine;

public class OutOfBorderDestructor : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _representation;
    
    void Update()
    {
        CheckBorders();
    }
    
    private void CheckBorders()
    {
        if(!GameAreaHelper.IsInGameplayArea(transform, _representation.bounds))
        {
            var registrableObject = GetComponent<IRegistrableGameObject> ();

            if (registrableObject != null)
                registrableObject.Unregister (); // Отмена регистрации в менеджере.

            Destroy (gameObject);
        }
    }
}
