using Hexxle.Interfaces;
using Hexxle.Unity.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hexxle.Unity.Input
{
    public class TileTurnEventHandler : MonoBehaviour
    {
        bool _buttonPressed = false;
        int _rotation = 0;

        UnityHand unityHand;

        InputManager inputManager;

        private void Awake()
        {
            unityHand = GameObjectFinder.UnityHand;
            inputManager = new InputManager();
        }

        private void OnEnable()
        {
            inputManager.TilePlacement.TileRotation.Enable();
            inputManager.TilePlacement.TileRotation.performed += context => TurnTileAction(context);
        }

        private void OnDisable()
        {
            inputManager.TilePlacement.TileRotation.Disable();
            inputManager.TilePlacement.TileRotation.performed -= context => TurnTileAction(context);
        }

        private void Update()
        {
            if (_buttonPressed)
            {
                ITile tile = unityHand.Peek();
                tile.Rotate(_rotation);
                _rotation = 0;
                _buttonPressed = false;
                GameObjectFinder.MouseEventLogic.UpdateTiles();
                GameObjectFinder.AudioManager.Play(Audio.GameSoundTypes.ROTATE);
            }
        }

        private void TurnTileAction(InputAction.CallbackContext context)
        {
            if (unityHand.IsTileSelected())
            {
                if (context.performed)
                {
                    _buttonPressed = true;
                    var turnVector = context.ReadValue<Single>();
                    if (turnVector < 0)
                    {
                        _rotation = -1;
                    }
                    else if (turnVector > 0)
                    {
                        _rotation = 1;
                    }
                }
            }
        }
    }
}

