using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.ShootingGalleryController
{
    public class AimMover : BoundMover
    {
        private Vector3 _direction;
        private AimRaycasterPoint _raycaster;

        protected override void OnMove()
        {
            ValidateRaycaster();
            if (_raycaster == null) return;
            
            RaycastResult raycastResult = _raycaster.Raycast();
            if(raycastResult.NotEmpty) transform.localPosition = raycastResult.Hit.point;
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