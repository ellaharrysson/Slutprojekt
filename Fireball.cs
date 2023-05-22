using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mina_projekt
{
    public class Fireball
    {
        private Texture2D texture;
        private Vector2 position;
        private float timeToLive;
        private float timeLived;
        private Vector2 velocity;
        private float angle;
        private Vector2 speed = new Vector2(-1.3f,1.8f);
        private Vector2 speed2 = new Vector2(1.3f,1.8f);
        public bool isDead{get{return timeLived >= timeToLive;}}

        public Vector2 Position
        {
            get{return position;}
            set{position=value;}
        }

        public float TimeLived
        {
            get {return timeLived;}
            set {timeLived = value; }
        }


        public Fireball(Texture2D texture, Vector2 startPosition, int minTimeToLive, int maxTimeToLive, Vector2 velocity )
        {
            position = startPosition;
            Random rand =new Random();
            timeToLive = (float)(rand.NextDouble()*(maxTimeToLive-minTimeToLive)) + minTimeToLive;
            this.texture = texture;
            this.velocity = velocity;
        }

        public void Update(GameTime gameTime)
        {
            if(position.X>600 && position.Y>10 && position.Y<70)
            {   
                position += speed;
            }
            else if(position.X<610  && position.Y>70 && position.Y<114)
            {
                position += speed;
            }else if(position.X<524 && position.Y>114 && position.Y<189)
            {
                position += speed;
            }else if(position.X<524 && position.Y>114 && position.Y<189)
            {
                position += speed;
            }
            else if(position.X<321  && position.Y>189 && position.Y<276 )
            {
                position +=speed;
            }else if (position.X<177 && position.X>50 && position.Y>276 && position.Y<320)
            {
                position += speed;
            }else
                position +=velocity;

            timeLived += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public void UpdateTwo(GameTime gameTime)
        {
            if(position.X>0  && position.Y>0 && position.Y<79)
            {
                position += speed2;
            }
            else if(position.X>171 && position.Y>79 && position.Y<122)
            {
                position += speed2;
            }else if(position.X>215 && position.Y>122 && position.Y<167)
            {
                position += speed2;
            }
            else if(position.X>266  && position.Y>167 && position.Y<200 )
            {
                position +=new Vector2(1.6f,1.8f);
            }else if (position.X>390 && position.Y>200 && position.Y<245)
            {
                position += speed2;
            }else if(position.X>542 && position.Y>245 && position.Y<300)
            {
                position += speed2;
            }else if(position.X>594 && position.Y>300 && position.Y<331)
            {
                position += speed2;
            }else if(position.X>680 && position.Y>331 && position.Y<386)
            {
                position += speed2;
            }
            else
                position -=velocity;


            timeLived += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
        public void UpdateThree(GameTime gameTime)
        {
            if(position.X>0  && position.Y>0 && position.Y<194)
            {
                position += speed2;
            }else if(position.X>172  && position.Y>194 && position.Y<259)
            {
                 position += new Vector2(1.6f,0.4f);
            }else if(position.X>610  && position.Y>259 && position.Y<439)
            {
                position += speed2;
            }
            else
                position -=velocity;


            timeLived += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
        public void UpdateFour(GameTime gameTime)
        {
            if(position.X<380  && position.Y>50 && position.Y<168)
            {
                position += new Vector2(-1.3f,0.6f);
            }
            else
                position +=velocity;


            timeLived += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void UpdateFive(GameTime gameTime)
        {

             if(position.X>350  && position.Y>0 && position.Y<188  )
            {
                position += new Vector2(1.3f,0.8f);
            }
            else
                position -=velocity;

            timeLived += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public void Draw(SpriteBatch spriteBatch)
        {          
            spriteBatch.Draw(texture,new Rectangle((int)position.X, (int)position.Y,10,10),null, Color.White, angle, new Vector2(texture.Width/2, texture.Height/2), SpriteEffects.None, 0);
        }

        public void DrawTwo(SpriteBatch spriteBatch)
        {          
            spriteBatch.Draw(texture,new Rectangle((int)position.X, (int)position.Y,10,10),null, Color.White, angle, new Vector2(texture.Width/2, texture.Height/2), SpriteEffects.FlipHorizontally, 0);
        }
    }
}





        