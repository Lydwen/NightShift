using UnityEngine;

namespace dallagnol.tom.nightshift
{
    /// <summary>
    ///     Component to move simply a transform
    /// </summary>
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 0.5f;
        [SerializeField]
        private Transform _transformToMove;

        /// <summary>
        ///     Update the position of the object
        ///     according to the inputs
        /// </summary>
        public void UpdateMovement(Vector3 currentLookPointForward, Vector3 currentLookPointRight)
        {
            Vector3 movementToApply = Vector3.zero;
            movementToApply += ApplyMovement(InputHelper.HORIZONTAL_AXIS, currentLookPointRight);
            movementToApply += ApplyMovement(InputHelper.VERTICAL_AXIS, currentLookPointForward);
            //we don't want the character to move up
            movementToApply.y = 0;
            _transformToMove.Translate(movementToApply, Space.Self);
        }

        private Vector3 ApplyMovement(string axis, Vector3 normalVector)
        {
            float axisValue = Input.GetAxis(axis);

            if (axisValue != 0f)
            {
                return normalVector * axisValue * _speed;
            }
            return Vector3.zero;
        }
    }
}
