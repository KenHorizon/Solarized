namespace Solarized.Level
{
    public class ResourceLocation<T>
    {
        public string NameSpace;
        public string FilePath;
        public ResourceLocation(string nameSpace, string filePath) 
        {
            this.NameSpace = nameSpace;
            this.FilePath = filePath;
        }
        public ResourceLocation(string filePath)
        {
            this.NameSpace = GamePanel.GAME_ID;
            this.FilePath = filePath;
        }

        public T Get()
        {
            return GamePanel.ContentManager.Load<T>(@"" + this.FilePath);
        }
    }
}
