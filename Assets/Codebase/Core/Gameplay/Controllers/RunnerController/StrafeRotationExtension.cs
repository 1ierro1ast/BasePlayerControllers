using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.RunnerController
{
    public class StrafeRotationExtension : MonoBehaviour
    {
        private Transform _anchorTransform;
        private float _rotationMultiplier;
        private bool _rotateWhenStrafe;

        public void Construct(Transform anchorTransform,
            MoveSettings moveSettings)
        {
            _rotateWhenStrafe = moveSettings.RotateWhenStrafe;
            _rotationMultiplier = moveSettings.RotationMultiplier;
            _anchorTransform = anchorTransform;
        }

        public void OnLateUpdate()
        {
            var transformPositionDelta = transform.position - _anchorTransform.position;
            if (_rotateWhenStrafe)
                transform.localRotation =
                    Quaternion.Euler(0, -1 * transformPositionDelta.x * _rotationMultiplier, 0);
        }
    }
}