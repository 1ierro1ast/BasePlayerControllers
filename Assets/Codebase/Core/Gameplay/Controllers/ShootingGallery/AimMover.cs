using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGallery
{
    public class AimMover : BoundMover
    {
        [SerializeField] private float _aimSpeed;
        
        //private IInputService _inputService;
        private Vector3 _direction;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            //_inputService = AllServices.Container.Single<IInputService>();
        }

        protected override void OnMove()
        {
            //_direction = new Vector3(_inputService.HorizontalSpeed, _inputService.VerticalSpeed).normalized;
            _direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            transform.Translate(_direction * (_aimSpeed * Time.deltaTime));
        }
    }
}