using System.Globalization;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGallery.PlayerAiming
{
    public class AimCameraMover : MonoBehaviour
    {
        [SerializeField] private AimTarget _aimTarget;
        [SerializeField] private float _moveBorder = 0.2f;
        [Space] [SerializeField] private float _leftCameraPositionBorder;
        [SerializeField] private float _rightCameraPositionBorder;
        [SerializeField] private float _cameraMoveSpeed = 5;

        private Camera _camera;
        private float _leftBorder;
        private float _rightBorder;

        private void Awake()
        {
            _camera = Camera.main;

            _leftBorder = 0 + _moveBorder;
            _rightBorder = 1 - _moveBorder;
        }

        private void LateUpdate()
        {
            var aimProjectToViewport = _camera.WorldToViewportPoint(_aimTarget.Position);

            if (aimProjectToViewport.x >= _rightBorder &&
                _camera.transform.localPosition.x < _rightCameraPositionBorder)
                _camera.transform.Translate(Vector3.right * (_cameraMoveSpeed * Time.deltaTime));
            
            if (aimProjectToViewport.x <= _leftBorder &&
                _camera.transform.localPosition.x > _leftCameraPositionBorder)
                _camera.transform.Translate(Vector3.left * (_cameraMoveSpeed * Time.deltaTime));
        }
    }
}