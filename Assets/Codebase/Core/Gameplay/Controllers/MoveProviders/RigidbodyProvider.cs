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
            _rigidbody.velocity = direction * speed;
        }

        public void Rotate(Vector3 axis, float torqueForce)
        {
            throw new System.NotImplementedException();
        }

        public void Rotate(Quaternion rotation, float torqueForce)
        {
            throw new System.NotImplementedException();
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