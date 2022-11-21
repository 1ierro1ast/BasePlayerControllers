using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.RunnerController
{
    public class ByNormalMover : BoundMover
    {
        private MoveSettings _moveSettings;
        private Ray _ray;
        private RaycastHit _hit;

        protected override void OnInitialize()
        {
            _moveSettings = AllServices.Container.Single<GameSettings>().MoveSettings;
        }

        protected override void OnFixedMove()
        {
            if (CheckGround())
                ProjectY();
            else
                ApplyGravity();
        }

        private void ApplyGravity()
        {
            var currentLocalPosition = transform.localPosition;
            transform.localPosition += new Vector3(currentLocalPosition.x, -1, currentLocalPosition.z) *
                                       (9f * Time.fixedDeltaTime);
        }

        private void ProjectY()
        {
            var currentLocalPosition = transform.position;
            Vector3 localPoint = _hit.point;
            localPoint.x = currentLocalPosition.x;
            localPoint.z = currentLocalPosition.z;

            transform.position = localPoint;
        }

        private bool CheckGround()
        {
            _ray = new Ray(transform.position + _moveSettings.OffsetFromGround, -transform.up);
            return Physics.Raycast(_ray, out _hit, _moveSettings.RaycastDistance, _moveSettings.GroundLayerMask,
                QueryTriggerInteraction.Ignore);
        }
    }
}