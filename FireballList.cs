using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace mina_projekt
{
    public class FireballList
    {

        private Vector2 position;
        private Texture2D texture;
        private List<Fireball> fireballs = new List<Fireball>();
        private int maxFireballs = 10;
        private int fireballTimer = 30;
     

        public List<Fireball> getFireballs() 
        {
            return fireballs;
        }


        public Vector2 Position
        {
            get{return position;}
            set{position = value;}
        }  

        public void Remove()
        {
           foreach (Fireball fireball in fireballs)
            {
                fireball.TimeLived = 15;
            }
        }


        public FireballList(Texture2D texture, Vector2 p)
        {
            this.texture = texture;
            position =p;
        }


        public void Update(GameTime gameTime)
        {
            foreach (Fireball fireball in fireballs)
            {
                fireball.Update(gameTime);
            }

            RemoveFireball();

            fireballTimer --;

            if(fireballTimer <= 0 )
            {
                SpawnFireball();
                fireballTimer = 240;
            }
        }

        public void UpdateTwo(GameTime gameTime)
        {
           foreach (Fireball fireball in fireballs)
            {
                fireball.UpdateTwo(gameTime);
            }

            RemoveFireball();

            fireballTimer --;

            if(fireballTimer <= 0 )
            {
                SpawnFireball();
                fireballTimer = 200;
            }
        }

        public void UpdateThree(GameTime gameTime)
        {          
            foreach (Fireball fireball in fireballs)
            {
                fireball.UpdateThree(gameTime);
            }

            RemoveFireball();

            fireballTimer --;

            if(fireballTimer <= 0 )
            {
                SpawnFireball();
                fireballTimer = 200;
            }
        }

        public void UpdateFour(GameTime gameTime)
        {      
            foreach (Fireball fireball in fireballs)
            {
                fireball.UpdateFour(gameTime);
            }

            RemoveFireball();

            fireballTimer --;

            if(fireballTimer <= 0 )
            {
                SpawnFireball();
                fireballTimer = 180;
            }
        }

        public void UpdateFive(GameTime gameTime)
        {
            foreach (Fireball fireball in fireballs)
            {
                fireball.UpdateFive(gameTime);
            }

            RemoveFireball();

            fireballTimer --;

            if(fireballTimer <= 0 )
            {
                SpawnFireball();
                fireballTimer = 180;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Fireball fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
        }


        public void DrawTwo(SpriteBatch spriteBatch)
        {
            foreach (Fireball fireball in fireballs)
            {
                fireball.DrawTwo(spriteBatch);
            }
        }


        private void RemoveFireball()
        {
            for(int i=0; i< fireballs.Count;i++)
            {
                if (fireballs[i].isDead)
                {
                    fireballs.RemoveAt(i);
                    i--;
                }
            }
        }

        private void SpawnFireball()
        {
            if(fireballs.Count>= maxFireballs)
                return;

            fireballs.Add(new Fireball(texture, position,1,15, new Vector2(-1.3f,0)));
        }

    }
}