using System;
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
            var bulletAttack = input.Player.BulletAttack;
            var laserAttack = input.Player.LaserAttack;
            _playerForwardMovement.Enable();
            _playerRotationMovement.Enable();
            bulletAttack.Enable();
            laserAttack.Enable();

            bulletAttack.started += context => BulletAttack();
            laserAttack.started += context => LaserAttack();
        }

        public float Forward => _playerForwardMovement.ReadValue<float>();
        public float Rotation => _playerRotationMovement.ReadValue<float>();
        public event Action BulletAttack = delegate { };
        public event Action LaserAttack = delegate { };
    }
}