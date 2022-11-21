using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.MoveProviders
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerProvider : MonoBehaviour, IMoveProvider
    {
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void Move(Vector3 direction, float speed)
        {
            _characterController.Move(direction * speed);
        }

        public void SetLocalPosition(Vector3 newPosition)
        {
            transform.localPosition = newPosition;
        }

        public void SetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}