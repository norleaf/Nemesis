using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprites
{
    public class SpriteGroup
    {
        public List<Sprite> Sprites { get; set; }
        private int spriteIndex;

        public SpriteGroup()
        {
            Sprites = new List<Sprite>();
        }

        public void Next()
        {
            spriteIndex++;
            if(spriteIndex >= Sprites.Count())
            {
                spriteIndex = 0;
            }
        }

        public Sprite Current
        {
            get {
                return Sprites[spriteIndex];
            }
        }
    }
}
