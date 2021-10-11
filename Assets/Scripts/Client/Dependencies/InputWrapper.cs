using GameLogic.Dependencies;
using UnityEngine.InputSystem;

namespace Client.Dependencies
{
    public class InputWrapper : IInput
    {
        private InputAction _playerForwardMovement;
        private InputAction _playerRotationMovement;

        public InputWrapper()
        {
            var input = new SpaceShipInput();
            _playerForwardMovement = input.Player.Forward;
            _playerRotationMovement = input.Player.Rotation;
            _playerForwardMovement.Enable();
            _playerRotationMovement.Enable();
        }

        public float Forward => _playerForwardMovement.ReadValue<float>();
        public float Rotation => _playerRotationMovement.ReadValue<float>();
    }
}