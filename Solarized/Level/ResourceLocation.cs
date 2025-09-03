using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level
{
    public class ResourceLocation
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
    }
}
