using UnityEngine;

namespace Lesson5DI.Scripts.GameSystem
{
    [RequireComponent(typeof(GameManager))] //Team
    public sealed class GameManagerInstaller : MonoBehaviour //Team
    {
        private void Awake() //Team
        {
            var gameManager = this.GetComponent<GameManager>();
            var listeners = this.GetComponentsInChildren<IGameListener>();
            
            foreach (var listener in listeners)
            {
                gameManager.AddListener(listener);
            }
        }
    }
}