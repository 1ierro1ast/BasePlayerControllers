using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.MoveProviders
{
    public interface IMoveProvider
    {
        void Move(Vector3 direction, float speed);
        void Rotate(Vector3 axis, float torqueForce);
        void Rotate(Quaternion rotation, float torqueForce);
        void SetLocalPosition(Vector3 newPosition);
        void SetPosition(Vector3 newPosition);
    }
}