using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.MoveProviders
{
    public class TransformProvider : MonoBehaviour, IMoveProvider
    {
        public void Move(Vector3 direction, float speed)
        {
            transform.Translate(direction * speed);
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