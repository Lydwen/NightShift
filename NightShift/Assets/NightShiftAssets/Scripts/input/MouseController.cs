using UnityEngine;
using System.Collections;
namespace dallagnol.tom.nightshift
{
    public class MouseController : MonoBehaviour
    {
        [SerializeField]
        private AMouseUpdatable[] _updatablesWithMouseInput;
        private MouseAxis _currentMouseAxis;

        public void Start()
        {
            _currentMouseAxis = new MouseAxis();
        }

        /// <summary>
        ///     Retrieve the mouse input and them to the different systems
        ///     that needs them.
        /// </summary>
        public void Update()
        {
            //calculate the camera angle
            _currentMouseAxis.horizontal = Input.GetAxis(InputHelper.MOUSEX);
            _currentMouseAxis.vertical = Input.GetAxis(InputHelper.MOUSEY);

            for (int updatablePosition = 0; updatablePosition < _updatablesWithMouseInput.Length; updatablePosition++)
            {
                _updatablesWithMouseInput[updatablePosition].UpdateWithMouseAxis(_currentMouseAxis);
            }
        }
    }
}
