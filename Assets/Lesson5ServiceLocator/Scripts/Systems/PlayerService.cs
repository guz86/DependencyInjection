using UnityEngine;

namespace Lesson5ServiceLocator.Scripts.Systems
{
    public sealed class PlayerService : MonoBehaviour
    {
        [SerializeField] private Player _player;


        public Player GetPlayer()
        {
            return _player;
        }
    }
}