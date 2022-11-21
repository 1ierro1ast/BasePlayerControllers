using System;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.BoundMoveController
{
    public abstract class BoundMover : MonoBehaviour
    {
        private IPositionClamp[] _positionClamps;

        private void Awake()
        {
            _positionClamps = GetComponents<IPositionClamp>();
            OnInitialize();
        }

        private void FixedUpdate()
        {
            OnFixedMove();
            ApplyBounds();
        }

        private void Update()
        {
            OnMove();
            ApplyBounds();
        }

        private void LateUpdate()
        {
            OnLateMove();
            ApplyBounds();
        }

        private void ApplyBounds()
        {
            foreach (var positionClamp in _positionClamps)
            {
                transform.localPosition = positionClamp.Clamp(transform.localPosition);
            }
        }

        protected virtual void OnInitialize()
        {
            
        }

        protected virtual void OnMove()
        {
            
        }
        
        protected virtual void OnFixedMove()
        {
            
        }
        
        protected virtual void OnLateMove()
        {
            
        }
    }
}