using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.BoundMoveController
{
    public interface IPositionClamp
    {
        public Vector3 Clamp(Vector3 currentPosition);
    }
}