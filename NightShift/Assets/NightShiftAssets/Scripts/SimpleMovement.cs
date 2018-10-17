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

        // Update is called once per frame
        void Update()
        {
            Vector3 movementToApply = Vector3.zero;
            movementToApply += ApplyMovement(InputHelper.HORIZONTAL_AXIS, _transformToMove.right);
            movementToApply += ApplyMovement(InputHelper.VERTICAL_AXIS, _transformToMove.forward);

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
