using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.Runner
{
    public class StrafeRotationExtension : MonoBehaviour
    {
        private Transform _anchorTransform;
        private float _rotationMultiplier;
        private bool _rotateWhenStrafe;

        public void Construct(Transform anchorTransform,
            AnchorMoveSettings anchorMoveSettings)
        {
            _rotateWhenStrafe = anchorMoveSettings.RotateWhenStrafe;
            _rotationMultiplier = anchorMoveSettings.RotationMultiplier;
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