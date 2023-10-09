using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOB.Scripts
{
    internal class SnowManThing : GameObject
    {
        private AnimatedSprite sprite;

        public SnowManThing(SpriteSheet s, float x, float y) {
            this.sprite = new AnimatedSprite(s);

            SetPosition(new System.Numerics.Vector2 (x, y));
        }

        public override AnimatedSprite GetSprite() => sprite;
    }
}
