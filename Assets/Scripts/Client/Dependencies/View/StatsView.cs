using Client.Dependencies.Addressable;
using GameLogic.Dependencies.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Dependencies.View
{
    public class StatsView : BaseView, IStatsView
    {
        [SerializeField] private TextMeshProUGUI _position;
        [SerializeField] private TextMeshProUGUI _angle;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _laserCount;
        [SerializeField] private TextMeshProUGUI _laserTime;

        public void UpdateSpeed(string speed) => _speed.text = $"Мгновенная скорость: {speed}";
        public void UpdatePosition(string x, string y) => _position.text = $"Позиция: ({x}, {y})";
        public void UpdateAngle(string angle) => _angle.text = $"Угол поворота: {angle}";
        public void UpdateLaserCount(string currentCount, string maxCount) => _laserCount.text = $"Число зарядов лазера: {currentCount}/{maxCount}";
        public void SetLaserTime(string time) => _laserTime.text = $"Время восстановления лазера: {time}";
    }
}