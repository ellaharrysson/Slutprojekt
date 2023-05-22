using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mina_projekt
{
    public class Player
    {
        private Texture2D texture;
        private float angle;
        private Vector2 position;    
        private Vector2 jumpSpeed;   
        private bool isJumping; 
        private Keys left;
        private Keys right;
        private Keys up;
        private bool drack;
        private bool hoppaHögre;
        private bool springaSnabbare;
        private bool svärd;


         public bool Svärd
        {
            get {return svärd;}
            set {svärd = value;}
        }   

        public bool SpringaSnabbare
        {
            get {return springaSnabbare;}
            set {springaSnabbare = value;}
        }   

        public Vector2 Position
        {
            get{return position;}
            set{position = value;}
        }  

        public bool HoppaHögre
        {
            get {return hoppaHögre;}
            set {hoppaHögre = value;}
        }

        public bool Drack
        {
            get {return drack;}
            set {drack = value;}
        }


        public Player(Texture2D texture, Vector2 startPosition, Keys l, Keys r, Keys u) 
        {
            this.texture = texture;
            position = startPosition;
            left = l;
            right = r;
            up =u;
        }

        public void MoveOne(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(right) && position.X < 760 )
            {
                position.X +=1.43f;
            }

            if(keyboardState.IsKeyDown(left) && position.X > 0)
            {
                position.X -=1.43f;
            }

            position += jumpSpeed;
            jumpSpeed +=new Vector2(0,0.17F);

            if(keyboardState.IsKeyDown(up) && !isJumping && !hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-4.5F); 
                isJumping =true;
            }else if(keyboardState.IsKeyDown(up) && !isJumping && hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-6F); 
                isJumping =true;
            }

            if(position.Y > 389)                                    
            {
                Jump(389);
            }else if (position.X > 325 && position.X < 518 && position.Y > 345 || position.X > 670 && position.X < 780 && position.Y > 345 )
            {
               Jump(345);
            }else if(position.X>760 && position.Y>280)
            {
                isJumping=false;
                    
                if(position.Y<245)
                    {
                        jumpSpeed = Vector2.Zero;
                    }

            }else if(position.X<685 && position.X>595  && position.Y<245 && position.Y>237 || position.X<248 && position.X>144 && position.Y<245 && position.Y>237 )
            {
                Jump(237);   
            }else if(position.X>475 && position.X<600 && position.Y<200 && position.Y>191) 
            {
                Jump(191); 
            }else if(position.X<485 && position.X>293  && position.Y<158 && position.Y>147) 
            {
                Jump(147);              
            }else if(position.X>487 && position.X<590  && position.Y<85 && position.Y>73) 
            {
                Jump(73);
            }else if( position.X < 780 && position.X>576  && position.Y<38 && position.Y>28) 
            {
                Jump(28);
            }else if(position.X<160 && position.X>65 && position.Y<290 && position.Y>280) 
            {
                Jump(280); 
            }
        }
        

        public void MoveTwo (GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(right) && position.X < 760 && !springaSnabbare)
            {
                position.X +=1.43f;
            }else if(keyboardState.IsKeyDown(right) && position.X < 760 && springaSnabbare)
            {
                position.X +=2.4f;
            }

            if(keyboardState.IsKeyDown(left) && position.X >0 && !springaSnabbare ){
                position.X -=1.43f;
            }else if(keyboardState.IsKeyDown(left) && position.X >0 && springaSnabbare)
            {
                position.X -=2.4f;
            }

            position += jumpSpeed;
            jumpSpeed +=new Vector2(0,0.17F);

            if(keyboardState.IsKeyDown(up) && !isJumping && !hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-4.5F); 
                isJumping =true;
            }else if(keyboardState.IsKeyDown(up) && !isJumping && hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-6F); 
                isJumping =true;
            }

            if(position.Y > 389 && position.X>-10 && position.X<248 || position.Y > 389 && position.X>320 && position.X<780 )                                   
            {
                Jump(389);

            }else if ( position.X > 690 && position.X < 780 && position.Y > 345 )
            {
               Jump(345);

            }else if(position.X<665 && position.X>564  && position.Y<309 && position.Y>291 )
            {
                Jump(291);   

            }else if(position.X>500 && position.X<584 && position.Y<269 && position.Y>258)
            {
                Jump(258); 
            }else if(position.X<530 && position.X>350  && position.Y<219 && position.Y>205)
            {
                Jump(205);              
            }else if(position.X>264 && position.X<379  && position.Y<170 && position.Y>160)
            {
                Jump(160);
            }else if( position.X < 250 && position.X>195  && position.Y<135 && position.Y>126)
            {
                Jump(126);
            }else if(position.X<205 && position.X>140  && position.Y<89 && position.Y>81)
            {
                Jump(81); 
            }else if(position.X<165 && position.X>-20  && position.Y<45 && position.Y>39)
            {
                Jump(39); 
            }else if(position.X<700 && position.X>635  && position.Y<189 && position.Y>181)
            {
                Jump(181); 
            }else if(position.X<780 && position.X>685  && position.Y<141 && position.Y>136)
            {
                Jump(136); 
            }
        }

        public void MoveThree(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(right) && position.X < 760 && !springaSnabbare){
                position.X +=1.43f;
            }else if(keyboardState.IsKeyDown(right) && position.X < 760 && springaSnabbare)
            {
                  position.X +=2.4f;
            }

             
            if(keyboardState.IsKeyDown(left) && position.X >0 && !springaSnabbare )
            {
            position.X -=1.43f;
            }else if(keyboardState.IsKeyDown(left) && position.X >0 && springaSnabbare)
            {
                  position.X -=2.4f;
            }
            
            position += jumpSpeed;
            jumpSpeed +=new Vector2(0,0.17F);

            if(keyboardState.IsKeyDown(up) && !isJumping && !hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-4.5F); 
                isJumping =true;
            }else if(keyboardState.IsKeyDown(up) && !isJumping && hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-6F); 
                isJumping =true;
            }

            if(position.Y > 396 && position.X>-10 && position.X<255 || position.Y > 396 && position.X>336 && position.X<535)                                   
            {
                Jump(396);
            }else if(position.Y > 399 && position.X>603 && position.X<780)
            {
                Jump(399);
            }else if(position.X<160 && position.X>50 && position.Y<357 && position.Y>351 )
            {
                Jump(351);   
            }else if(position.X<80 && position.X>-10 && position.Y<314 && position.Y>305 )
            {
                Jump(305);   
            }else if(position.X<425 && position.X>180  && position.Y<265 && position.Y>258 )
            {
                Jump(258);   
            }else if(position.X<600 && position.X>400 &&  position.Y<226 && position.Y>217 )
            {
                Jump(217);              
            }else if(position.X>575 && position.X<682  && position.Y<165 && position.Y>152|| position.X<165 && position.X>-10  && position.Y<165 && position.Y>152)
            {
                Jump(152);
            }else if( position.X < 780 && position.X>693  && position.Y<129 && position.Y>120)
            {
                Jump(120);
            }else if( position.X < 780 && position.X>750  && position.Y<85 && position.Y>75 || position.X < 540 && position.X>430  && position.Y<85 && position.Y>75 || position.X < 340 && position.X>220  && position.Y<85 && position.Y>75)
            {
                Jump(75);
            }else if( position.X < 660 && position.X>540 && position.Y<59 && position.Y>51)
            {
                Jump(51);
            }else if( position.X < 420 && position.X>300  && position.Y<105 && position.Y>95)
            {
                Jump(95);
            } 
        }

        public void MoveFour(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();


            if(keyboardState.IsKeyDown(right) && position.X < 760 && !springaSnabbare){
                position.X +=1.43f;
            }else if(keyboardState.IsKeyDown(right) && position.X < 760 && springaSnabbare)
            {
                position.X +=2.4f;
            }

            if(keyboardState.IsKeyDown(left) && position.X >0 && !springaSnabbare ){
                position.X -=1.43f;
            }else if(keyboardState.IsKeyDown(left) && position.X >0 && springaSnabbare)
            {
                position.X -=2.4f;
            }
            
            position += jumpSpeed;
            jumpSpeed +=new Vector2(0,0.17F);

            if(keyboardState.IsKeyDown(up) && !isJumping && !hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-4.5F); 
                isJumping =true;
            }else if(keyboardState.IsKeyDown(up) && !isJumping && hoppaHögre )
            {
                jumpSpeed= new Vector2(0,-6F); 
                isJumping =true;
            }

            if(position.Y > 389 && position.X>-10 && position.X<250 || position.Y > 389 && position.X>320 && position.X<510 || position.Y > 389 && position.X>660 && position.X<780 )                                   
            {
                Jump(389);
            }else if ( position.X > 715 && position.X < 780 && position.Y > 343 || position.X > 360 && position.X < 469 && position.Y > 343  && position.Y<353)
            {
               Jump(343);
            }else if(position.X<265 && position.X>170  && position.Y<276 && position.Y>267)
            {
                Jump(267);   
            }else if(position.X>73 && position.X<180 && position.Y<240 && position.Y>232 ||position.X>573 && position.X<680 && position.Y<240 && position.Y>232  )
            {
                Jump(232); 
            }else if(position.X<77 && position.X>-10  && position.Y<136 && position.Y>125)
            {
                Jump(125);              
            }else if(position.X>640 && position.X<719  && position.Y<199 && position.Y>188 || position.X>320 && position.X<359  && position.Y<199 && position.Y>188)
            {
                Jump(188);
            }else if(position.X<780 && position.X>687  && position.Y<152 && position.Y>145|| position.X<533 && position.X>490  && position.Y<152 && position.Y>145)
            {
                Jump(145); 
            }else if(position.X<540 && position.X>267  && position.Y<72 && position.Y>60)
            {
                Jump(60);
            }
        }

        private void Jump(int jump)
        {
            position = new Vector2(position.X, jump);
            jumpSpeed = Vector2.Zero;
            isJumping = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(left))
            spriteBatch.Draw(texture,new Rectangle((int)position.X, (int)position.Y,42,50),null, Color.White, angle, new Vector2(texture.Width/texture.Width, texture.Height/texture.Height), SpriteEffects.FlipHorizontally, 0);
            else
            spriteBatch.Draw(texture,new Rectangle((int)position.X, (int)position.Y,42,50),null, Color.White, angle, new Vector2(texture.Width/texture.Width, texture.Height/texture.Height), SpriteEffects.None, 0);
        }
    }
}