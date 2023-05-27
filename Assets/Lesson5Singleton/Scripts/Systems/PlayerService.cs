using UnityEngine;

namespace Lesson5Singleton.Scripts.Systems
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public Player GetPlayer()
        {
            return _player;
        }
    }
}