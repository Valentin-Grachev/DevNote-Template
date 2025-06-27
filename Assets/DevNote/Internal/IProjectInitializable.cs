namespace DevNote
{
    public interface IProjectInitializable
    {
        public bool Initialized { get; }

        public void Initialize();

    }

}
