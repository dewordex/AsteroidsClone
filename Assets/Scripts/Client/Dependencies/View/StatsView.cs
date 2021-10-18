using Client.Dependencies.Addressable;
using GameLogic.Dependencies.View;
using TMPro;
using UnityEngine;

namespace Client.Dependencies.View
{
    public class StatsView : BaseView, IStatsView
    {
        [SerializeField] private TextMeshProUGUI _textMesh;

        public void SetStats(string stats) => _textMesh.text = stats;
    }
}