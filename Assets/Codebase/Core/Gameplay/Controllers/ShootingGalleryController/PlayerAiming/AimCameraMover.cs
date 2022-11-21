using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Core.Gameplay.Controllers.MoveProviders;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGalleryController.PlayerAiming
{
    public class AimCameraMover : BoundMover
    {
        [SerializeField] private AimTarget _aimTarget;
        [SerializeField] private float _moveBorder = 0.2f;
        [Space] 
        [SerializeField] private float _leftCameraPositionBorder;
        [SerializeField] private float _rightCameraPositionBorder;
        [SerializeField] private float _cameraMoveSpeed = 5;

        private IMoveProvider _moveProvider;
        private Camera _camera;
        private float _leftBorder;
        private float _rightBorder;

        protected override void OnInitialize()
        {
            _moveProvider = GetComponent<IMoveProvider>();
            _camera = Camera.main;

            _leftBorder = 0 + _moveBorder;
            _rightBorder = 1 - _moveBorder;
        }

        protected override void OnLateMove()
        {
            var aimProjectToViewport = _camera.WorldToViewportPoint(_aimTarget.Position);

            if (aimProjectToViewport.x >= _rightBorder &&
                transform.localPosition.x < _rightCameraPositionBorder)
                _moveProvider.Move(Vector3.right, _cameraMoveSpeed * Time.deltaTime);

            if (aimProjectToViewport.x <= _leftBorder &&
                transform.localPosition.x > _leftCameraPositionBorder)
                _moveProvider.Move(Vector3.left, _cameraMoveSpeed * Time.deltaTime);
        }
    }
}