using Gameplay;
using Gameplay.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI {
	// Добавлен класс с результатами игры и возможностью начать игру заново (в соответствии с требованиями ТЗ).
	[AddComponentMenu ("Spaceships/UI/GameOver")]
    public class GameOver : MonoBehaviour {
		[SerializeField]
		private TMP_Text _score; // Текст с количеством набранных очков.
		[SerializeField]
		private Button _restart; // Кнопка позволяющая начать игру заново.

		public void Init () {
			_restart.onClick.AddListener (() => { Restart (); });
		}
		public void Open () {
			gameObject.SetActive (true);
			Time.timeScale = 0f;
			_score.text = $"Score: {Gameplay.Data.Player.Score}";
		}
		public void Restart () {
			gameObject.SetActive (false);
			Time.timeScale = 1f;
			Player.Reset ();
			GameObjectsManager.Restart ();
		}
	}
}
