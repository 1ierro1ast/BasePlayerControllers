using System;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Settings;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controller
{
    public class ToAnchorMover : MonoBehaviour
    {
        private MoveSettings _moveSettings;
        private Anchor _anchor;
        private Vector3 _anchorPositionExcludeY;
        private const string Tag = "[ToAnchorMover]";

        private void Awake()
        {
            _moveSettings = AllServices.Container.Single<GameSettings>().MoveSettings;

            _anchor = FindObjectOfType<Anchor>();
            
            var anchorTransform = _anchor.transform;
            _anchorPositionExcludeY = new Vector3(
                anchorTransform.position.x, 
                transform.position.y, 
                anchorTransform.position.z);
        }

        private void LateUpdate()
        {
            if (_anchor == null)
            {
                throw new Exception($"{Tag}: Anchor not assigned!");
            }

            var anchorTransformPosition = _anchor.transform.position;
            
            _anchorPositionExcludeY.x = anchorTransformPosition.x;
            _anchorPositionExcludeY.z = anchorTransformPosition.z;
            
            transform.position = Vector3.Lerp(transform.position, _anchorPositionExcludeY,
                _moveSettings.StrafeSpeed * Time.deltaTime);
        }
    }
}