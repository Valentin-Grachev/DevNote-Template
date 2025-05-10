namespace DevNote
{
    public interface IWaitInitializable
    {
        public bool Initialized { get; }

        public void Initialize();

    }

}
