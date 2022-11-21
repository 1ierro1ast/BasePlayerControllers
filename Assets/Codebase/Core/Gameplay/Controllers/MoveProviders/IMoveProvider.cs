using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.MoveProviders
{
    public interface IMoveProvider
    {
        void Move(Vector3 direction, float speed);
        void SetLocalPosition(Vector3 newPosition);
        void SetPosition(Vector3 newPosition);
    }
}