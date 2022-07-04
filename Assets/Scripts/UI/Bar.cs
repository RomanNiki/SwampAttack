﻿using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] protected Slider Slider;

        public void OnValueChanged(int value, int maxValue)
        {
            Slider.value = (float)value / maxValue;
        }
    }
}