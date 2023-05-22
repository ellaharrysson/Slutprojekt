using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mina_projekt
{
    public class Enemy
    {
        private Texture2D drake;
        private Vector2 position;
        private float angle;
        
        public Vector2 Position
        {
            get{return position;}
            set{position = value;}
        }

        public Enemy(Texture2D texture, Vector2 position)
        {
            drake = texture;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(drake,new Rectangle((int)position.X, (int)position.Y,84,65),null, Color.White, angle, new Vector2(drake.Width/drake.Width, drake.Height/drake.Height), SpriteEffects.None, 0);
        }

        public void DrawTwo(SpriteBatch spriteBatch)
        {               
            spriteBatch.Draw(drake,new Rectangle((int)position.X, (int)position.Y,84,65),null, Color.White, angle, new Vector2(drake.Width/drake.Width, drake.Height/drake.Height), SpriteEffects.FlipHorizontally, 0);
        }

    }
}