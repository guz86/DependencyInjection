using System;
using UnityEngine;

namespace Lesson5DI3
{
    public interface IPlayerService
    {
        Player GetPlayer();
    }

    [Serializable]
    public sealed class PlayerService : IPlayerService
    {
        [SerializeField] private Player _player;

        public Player GetPlayer()
        {
            return _player;
        }
    }
}