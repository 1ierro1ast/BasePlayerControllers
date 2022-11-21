using System;
using Codebase.Core.Gameplay.Controllers.BoundMoveController;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.RunnerController
{
    public class ToAnchorMover : BoundMover
    {
        private StrafeRotationExtension _strafeRotationExtension;
        private MoveSettings _moveSettings;
        private Anchor _anchor;
        private const string Tag = "[ToAnchorMover]";

        protected override void OnInitialize()
        {
            _moveSettings = AllServices.Container.Single<GameSettings>().MoveSettings;
            _anchor = FindObjectOfType<Anchor>();
            _strafeRotationExtension = GetComponent<StrafeRotationExtension>();
            _strafeRotationExtension?.Construct(_anchor.transform, _moveSettings);
        }

        protected override void OnLateMove()
        {
            if (_anchor == null)
            {
                throw new Exception($"{Tag}: Anchor not assigned!");
            }

            _strafeRotationExtension?.OnLateUpdate();
            
            var anchorTransformPosition = _anchor.transform.position;
            
            transform.position = Vector3.Lerp(transform.position, anchorTransformPosition,
                _moveSettings.StrafeSpeed * Time.deltaTime);
        }
    }
}