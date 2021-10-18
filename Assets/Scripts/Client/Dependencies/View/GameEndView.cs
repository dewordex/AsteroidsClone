using Client.Dependencies.Addressable;
using GameLogic.Dependencies.View;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Dependencies.View
{
    public class GameEndView : BaseView, IGameEndView
    {
        [SerializeField] private TextMeshProUGUI _textMesh;

        public void Show(int score)
        {
            gameObject.SetActive(true);
            _textMesh.text = $"Вы набрали: {score} очков";
        }

        public void NewGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}