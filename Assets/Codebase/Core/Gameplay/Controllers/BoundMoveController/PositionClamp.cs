using System;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.BoundMoveController
{
    public class PositionClamp : MonoBehaviour, IPositionClamp
    {
        [SerializeField] private ClampAxis _axis;
        [SerializeField] private float _minBorder;
        [SerializeField] private float _maxBorder;

        private void Awake()
        {
            if (!TryGetComponent(out BoundMover boundMover))
                Debug.LogWarning("PositionClamp needs a component that inherits BoundMover!");
        }

        public Vector3 Clamp(Vector3 currentPosition)
        {
            switch (_axis)
            {
                case ClampAxis.X:
                    currentPosition.x = Mathf.Clamp(currentPosition.x, _minBorder, _maxBorder);
                    break;
                case ClampAxis.Y:
                    currentPosition.y = Mathf.Clamp(currentPosition.y, _minBorder, _maxBorder);
                    break;
                case ClampAxis.Z:
                    currentPosition.z = Mathf.Clamp(currentPosition.z, _minBorder, _maxBorder);
                    break;
                default:
                    break;
            }

            return currentPosition;
        }
    }
}