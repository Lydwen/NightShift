using System;
using UnityEngine;

namespace dallagnol.tom.nightshift
{
    [Serializable]
    public abstract class AMouseUpdatable : MonoBehaviour
    {
        public abstract void UpdateWithMouseAxis(MouseAxis mouseAxis);
    }

    public struct MouseAxis
    {
        public float horizontal;
        public float vertical;
    }
}