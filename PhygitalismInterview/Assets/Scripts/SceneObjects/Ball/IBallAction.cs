namespace Assets.Scripts.SceneObjects.Ball
{
    public interface IBallAction
    {
        bool IsComplited { get; }
        void StartAction();        
        void Update();
    }
}
