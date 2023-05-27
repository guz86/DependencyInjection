using UnityEngine;

namespace Lesson5Singleton.Scripts.Systems
{
    public sealed class PlayerService : MonoBehaviour
    {
        public static PlayerService Instance { get; private set; }

        [SerializeField] private Player _player;

        private void Awake()
        {
            Instance = this;
            
            
            // к дочерним не будет применятся, только к корневым
            // if (Instance == null)
            // {
            //     Instance = this;
            //     DontDestroyOnLoad(gameObject);
            //     return;
            // }
            //
            // Destroy(gameObject);
            
        }
        // еще возможно нужнен приватный конструктор
        //private PlayerService() {}
        
        public Player GetPlayer()
        {
            return _player;
        }
    }
}