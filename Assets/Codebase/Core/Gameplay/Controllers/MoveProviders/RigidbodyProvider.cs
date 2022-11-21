using System;
using UnityEngine;

namespace Codebase.Core.Gameplay.Controllers.MoveProviders
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyProvider : MonoBehaviour, IMoveProvider
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction, float speed)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * speed);
        }

        public void SetLocalPosition(Vector3 newPosition)
        {
            transform.localPosition = newPosition;
        }

        public void SetPosition(Vector3 newPosition)
        {
            _rigidbody.position = newPosition;
        }
    }
}