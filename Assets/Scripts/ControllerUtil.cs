﻿using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ControllerUtil : MonoBehaviour
    {
        public float buttonPressDelayInSeconds;
        private float _lastTimeButtonPressed;
        private bool _isMenuOpen;

        private void Start()
        {
            _lastTimeButtonPressed = Time.time;
        }

        public float GetHorizontalAxisRaw()
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                return 0;
            }

            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            return FinishedMovementDelay(horizontalAxis) ? horizontalAxis : 0;
        }

        public float GetVerticalAxisRaw()
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                return 0;
            }

            float verticalAxis = Input.GetAxisRaw("Vertical");
            return FinishedMovementDelay(verticalAxis) ? verticalAxis : 0;
        }

        public float GetHorizontalPanningAxis()
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                return 0;
            }

            return Input.GetAxis("HorizontalPanning");
        }

        public float GetVerticalPanningAxis()
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                return 0;
            }

            return Input.GetAxis("VerticalPanning");
        }

        /**
         * This is Deprecated.
         */
        public bool PaintSelectionUIToggled()
        {
            return Input.GetButtonDown("PaintSelectionUI");
        }

        /**
         * This is so that a single movement press doesn't trigger two blocks of movement.
         */
        private bool FinishedMovementDelay(float movement)
        {
            if (movement != 0 && Time.time - _lastTimeButtonPressed > buttonPressDelayInSeconds)
            {
                _lastTimeButtonPressed = Time.time;
                return true;
            }

            return false;
        }

        public bool GetXAxisPaintSelectAxis(out int axis)
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                axis = 0;
                return false;
            }

            axis = Input.GetAxisRaw("XAxisPaintSelect") > 0
                ? 1
                : (Input.GetAxisRaw("XAxisPaintSelect") < 0
                    ? -1
                    : 0);
            return FinishedMovementDelay(axis);
        }

        public bool GetZAxisPaintSelectAxis(out int axis)
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                axis = 0;
                return false;
            }

            axis = Input.GetAxisRaw("ZAxisPaintSelect") > 0
                ? 1
                : (Input.GetAxisRaw("ZAxisPaintSelect") < 0
                    ? -1
                    : 0);
            return FinishedMovementDelay(axis);
        }

        /**
         * This should be deprecated.
         */
        public bool GetYAxisPaintSelectAxis(out int axis)
        {
            axis = Input.GetAxisRaw("YAxisPaintSelect") > 0
                ? 1
                : (Input.GetAxisRaw("YAxisPaintSelect") < 0
                    ? -1
                    : 0);
            return FinishedMovementDelay(axis);
        }

        public bool GetColourWheelPressed()
        {
            if (_isMenuOpen)
            {
                return false;
            }

            return Input.GetAxisRaw("PaintHUD") < 0 || Input.GetKeyDown(KeyCode.Tab);
        }

        public bool GetColourWheelNotPressed()
        {
            return Input.GetAxisRaw("PaintHUD") == 0 || Input.GetKeyUp(KeyCode.Tab);
        }

        public float GetColourWheelSelectXAxis()
        {
            return Input.GetAxis("ColourWheelSelectXAxis");
        }

        public float GetColourWheelSelectYAxis()
        {
            return Input.GetAxis("ColourWheelSelectYAxis");
        }

        public bool GetPaintButtonDown()
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                return false;
            }

            return Input.GetAxisRaw("Paint") > 0;
        }

        public bool GetInteractButtonDown()
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                return false;
            }

            return Input.GetButtonDown("Interact");
        }


        public bool GetRotationChangePressed()
        {
            if (GetColourWheelPressed() || _isMenuOpen)
            {
                return false;
            }

            return Input.GetAxisRaw("RotateCamera") != 0;
        }

        public bool GetMenuButtonPressed()
        {
            bool isPressed = Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Menu");
            if (isPressed)
            {
                _isMenuOpen = !_isMenuOpen;
            }

            return isPressed;
        }
    }
}