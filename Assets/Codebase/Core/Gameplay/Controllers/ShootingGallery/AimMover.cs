using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGallery
{
    public class AimMover : BoundMover
    {
        [SerializeField] private float _aimSpeed;
        
        private IInputService _inputService;
        private Vector3 _direction;
        private AimRaycasterPoint _raycaster;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _inputService = AllServices.Container.Single<IInputService>();
        }

        protected override void OnMove()
        {
            ValidateRaycaster();
            if (_raycaster == null) return;
            
            RaycastResult raycastResult = _raycaster.Raycast();
            if(raycastResult.NotEmpty) transform.localPosition = raycastResult.Hit.point;
            //_direction = new Vector3(_inputService.HorizontalSpeed, _inputService.VerticalSpeed).normalized;
            //transform.Translate(_direction * (_aimSpeed * Time.deltaTime));
        }

        private void ValidateRaycaster()
        {
            if (_raycaster == null)
            {
                _raycaster = FindObjectOfType<AimRaycasterPoint>();
            }
        }
    }
}