namespace Lesson6TeacherZenject.Scripts.Architecture
{
    public interface IGameManager
    {
        public GameState CurrentState { get; }
        
        public void AddListener(IGameListener listener);
        
        public void InitializeGame();

        public void StartGame();

        public void FinishGame();
    }
}