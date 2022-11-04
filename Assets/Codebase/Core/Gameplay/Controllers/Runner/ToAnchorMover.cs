using System;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.Runner
{
    public class ToAnchorMover : MonoBehaviour
    {
        private StrafeRotationExtension _strafeRotationExtension;
        private AnchorMoveSettings _anchorMoveSettings;
        private Anchor _anchor;
        private const string Tag = "[ToAnchorMover]";

        private void Awake()
        {
            _anchorMoveSettings = AllServices.Container.Single<GameSettings>().AnchorMoveSettings;
            _anchor = FindObjectOfType<Anchor>();
            _strafeRotationExtension = GetComponent<StrafeRotationExtension>();
            _strafeRotationExtension?.Construct(_anchor.transform, _anchorMoveSettings);
        }

        private void LateUpdate()
        {
            if (_anchor == null)
            {
                throw new Exception($"{Tag}: Anchor not assigned!");
            }

            _strafeRotationExtension?.OnLateUpdate();
            
            var anchorTransformPosition = _anchor.transform.position;
            
            transform.position = Vector3.Lerp(transform.position, anchorTransformPosition,
                _anchorMoveSettings.StrafeSpeed * Time.deltaTime);
        }
    }
}