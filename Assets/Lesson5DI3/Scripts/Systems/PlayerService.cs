using UnityEngine;

namespace Lesson5DI3
{
    public interface IPlayerService
    {
        Player GetPlayer();
    }
    
    public sealed class PlayerService : MonoBehaviour, IPlayerService
    {
        [SerializeField] private Player _player;
 
        public Player GetPlayer()
        {
            return _player;
        }
    }
}