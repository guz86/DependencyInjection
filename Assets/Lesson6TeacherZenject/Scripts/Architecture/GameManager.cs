using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Architecture
{
    [AddComponentMenu("Lesson6/GameManager")]
    [DefaultExecutionOrder(-100)]
    public sealed class GameManager : MonoBehaviour, IGameManager
    {
        //public static GameManager Instance { get; private set; }
        
        [ShowInInspector, ReadOnly]
        public GameState CurrentState { get; private set; } = GameState.Idle;
        
        [SerializeField]
        private bool _autoRun = true;

        //private readonly GameManagerContext _context = new();

        [Inject]
        private readonly GameManagerContext _context;
        
        // private void Awake()
        // {
        //     if (Instance != null)
        //     {
        //         Destroy(this);
        //     }
        //     else
        //     {
        //         Instance = this;
        //     }
        // }
        
        private void Start()
        {
            if (_autoRun)
            {
                InitializeGame();
                StartGame();
            }
        }

        public void AddListener(IGameListener listener)
        {
            _context.AddListener(listener);
        }

        [Button]
        public void InitializeGame()
        {
            if (CurrentState != GameState.Idle)
            {
                Debug.LogWarning($"Expected state {GameState.Idle}, but actual state is {CurrentState}");
                return;
            }

            CurrentState = GameState.Initialized;
            
            _context.OnGameInitialized();
        }

        [Button]
        public void StartGame()
        {
            if (CurrentState != GameState.Initialized)
            {
                Debug.LogWarning($"Expected state {GameState.Initialized}, but actual state is {CurrentState}");
                return;
            }

            CurrentState = GameState.Playing;
            
            _context.OnGameStarted();
        }
        
        [Button]
        public void FinishGame()
        {
            if (CurrentState != GameState.Playing)
            {
                Debug.LogWarning($"Expected state {GameState.Playing}, but actual state is {CurrentState}");
                return;
            }

            CurrentState = GameState.Finished;
            
            _context.OnGameFinished();
        }
    }
}