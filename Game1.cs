using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace mina_projekt;


public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D p1;
    private Texture2D p2;
    private Texture2D draken;
    private Texture2D bakgrund;
    private Texture2D level2;
    private Texture2D level3;
    private Texture2D level4;
    private Texture2D fireballTexture;
    private Texture2D nyckelTexture;
    private Texture2D nyckelTexture2;
    private Texture2D nyckelTexture3;
    private Texture2D nyckelTexture4;
    private Texture2D fjäderTexture;
    private Texture2D svampTexture;
    private Texture2D svärdTexture;
    private Texture2D posionTexture;
    private Texture2D slutDel;
    private Texture2D startDel;
    private SpriteFont font;

    private Vector2 position = new Vector2(50, 389);
    private Vector2 position2 = new Vector2(90, 389);
    private Vector2 position3 = new Vector2(720, 17);
    private Vector2 position4 = new Vector2(623, 42);
    private Vector2 position5 = new Vector2(645, 50);
    private Vector2 position6 = new Vector2(120, 303);
    private Vector2 position7 = new Vector2(740, 160);
    private Vector2 position8 = new Vector2(120, 303);
    private Vector2 position10 = new Vector2(125, 62);
    private Vector2 position11 = new Vector2(110, 175);
    private Vector2 position12 = new Vector2(410, 85);
    private Vector2 position13 = new Vector2(760, 165);
    private Vector2 position14 = new Vector2(20, 145);
    private Vector2 position15 = new Vector2(635, 75);
    private Vector2 positionFire1 = new Vector2(723, 42);
    private Vector2 positionFire2 = new Vector2(548, 70);

    private Player player1;
    private Player player2;
    private Enemy drake;
    private Enemy drake2;
    private FireballList fire;
    private FireballList fire2;
    
    private bool hit;
    private bool isPlaying;
    private bool träffad;
    private bool paus;
    private bool lvl1 = true;
    private bool lvl2 = false;
    private bool lvl3 = false;
    private bool lvl4 = false;
    private bool slut = false;
    private double score = 0;
    private double highScore = 0;
    private int varv;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        bakgrund = Content.Load<Texture2D>("bakgrundprototyp");
        level2 = Content.Load<Texture2D>("levelt");
        level3 = Content.Load<Texture2D>("leveltre");
        level4 = Content.Load<Texture2D>("level4");
        slutDel = Content.Load<Texture2D>("slutdel");
        startDel = Content.Load<Texture2D>("start");

        p1 = Content.Load<Texture2D>("p1");
        player1 = new Player(p1, position, Keys.A, Keys.D, Keys.W);

        p2 = Content.Load<Texture2D>("p2");
        player2 = new Player(p2, position2, Keys.Left, Keys.Right, Keys.Up);

        fireballTexture = Content.Load<Texture2D>("fireball[1]");
        fire = new FireballList(fireballTexture, positionFire1);
        fire2 = new FireballList(fireballTexture, positionFire2);

        draken = Content.Load<Texture2D>("drake");
        drake = new Enemy(draken, position3);
        drake2 = new Enemy(draken, new Vector2(465, 50));

        nyckelTexture = Content.Load<Texture2D>("nykkel");
        nyckelTexture2 = Content.Load<Texture2D>("nykkel");
        nyckelTexture3 = Content.Load<Texture2D>("nykkel");
        nyckelTexture4 = Content.Load<Texture2D>("nykkel");
        fjäderTexture = Content.Load<Texture2D>("fjäder");
        svampTexture = Content.Load<Texture2D>("svampen");
        svärdTexture = Content.Load<Texture2D>("svärden");
        posionTexture = Content.Load<Texture2D>("dryck");

        font = Content.Load<SpriteFont>("font");

        

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        KeyboardState kState = Keyboard.GetState();

        if (kState.IsKeyDown(Keys.Enter) && !isPlaying)
        {
            isPlaying = true;
        }

        if (kState.IsKeyDown(Keys.Space) && slut)
        {
            isPlaying = false;
            score=0;
            Reset();
        }
        
        if(kState.IsKeyDown(Keys.P))
        {
            paus = true;
            isPlaying = false;
            träffad = false;
        }

        if (!isPlaying || slut)
            return;


        score += gameTime.ElapsedGameTime.TotalSeconds;

        if (lvl1)
        {
            player1.MoveOne(gameTime);
            player2.MoveOne(gameTime);
            fire.Update(gameTime);

            if (Träffad(p1, nyckelTexture, player1.Position, position5) || Träffad(p2, nyckelTexture, player2.Position, position5))
            {
                lvl1 = false;
                lvl2 = true;
                lvl3 = false;
                lvl4 = false;
                player1.Position = new Vector2(50, 389);
                player2.Position = new Vector2(90, 389);
                drake.Position = new Vector2(18, 27);
                fire.Position = new Vector2(100, 54);
                fire.Remove();
            }
            if (Träffad(p1, fjäderTexture, player1.Position, position6))
            {
                player1.HoppaHögre = true;
            }

            if (Träffad(p2, fjäderTexture, player2.Position, position6))
            {
                player2.HoppaHögre = true;
            }

        }
        else if (lvl2)
        {
            player1.MoveTwo(gameTime);
            player2.MoveTwo(gameTime);
            fire.UpdateTwo(gameTime);
            if (Träffad(p1, nyckelTexture2, player1.Position, position7) || Träffad(p2, nyckelTexture2, player2.Position, position7))
            {
                lvl1 = false;
                lvl2 = false;
                lvl3 = true;
                lvl4 = false;
                player1.Position = new Vector2(650, 399);
                player2.Position = new Vector2(700, 399);
                drake.Position = new Vector2(10, 140);
                fire.Position = new Vector2(89, 166);
                fire.Remove();
            }
            if (Träffad(p1, svampTexture, player1.Position, position10))
            {
                player1.SpringaSnabbare = true;
            }

            if (Träffad(p2, svampTexture, player2.Position, position10))
            {
                player2.SpringaSnabbare = true;

            }
        }
        else if (lvl3)
        {
            player1.MoveThree(gameTime);
            player2.MoveThree(gameTime);
            fire.UpdateThree(gameTime);
            if (Träffad(p1, nyckelTexture3, player1.Position, position11) || Träffad(p2, nyckelTexture3, player2.Position, position11))
            {
                lvl1 = false;
                lvl2 = false;
                lvl3 = false;
                lvl4 = true;
                player1.Position = new Vector2(50, 389);
                player2.Position = new Vector2(90, 389);
                drake.Position = new Vector2(300, 50);
                fire.Position = new Vector2(300, 70);
                fire.Remove();
            }

            if (Träffad(p1, posionTexture, player1.Position, position15))
            {
                player1.Drack = true;
            }
            if (Träffad(p2, posionTexture, player2.Position, position15))
            {
                player2.Drack = true;
            }
        }
        else if (lvl4)
        {
            player1.MoveFour(gameTime);
            player2.MoveFour(gameTime);

            if (player1.Drack)
            {
                if (kState.IsKeyDown(Keys.T))
                {
                    player1.Position = new Vector2(338, 175);
                }
            }

            if (player2.Drack)
            {
                if (kState.IsKeyDown(Keys.U))
                {
                    player2.Position = new Vector2(497, 144);
                }
            }

            if (Träffad(p1, nyckelTexture4, player1.Position, position12) && Träffad(p2, nyckelTexture4, player2.Position, position12))
            {
                lvl1 = false;
                lvl2 = false;
                lvl3 = false;
                lvl4 = false;
                slut = true;
                varv++;

                if(varv ==1)
                {
                    highScore = score;
                    
                }else if(score<=highScore)
                {
                    highScore = score;
                }
            }

            if (Träffad(p1, svärdTexture, player1.Position, position14) && Träffad(p2, svärdTexture, player2.Position, position13))
            {
                player1.Svärd = true;
                player2.Svärd = true;
                player1.Position = drake.Position;
                player2.Position = drake2.Position;
                fire.Remove();
            }else 
            {
                fire.UpdateFour(gameTime);
                fire2.UpdateFive(gameTime);
            }



            foreach (Fireball fireball in fire2.getFireballs())
            {
                if (Träffad(p1, fireballTexture, player1.Position, fireball.Position) || Träffad(p2, fireballTexture, player2.Position, fireball.Position))
                {
                    Reset();
                }
            }
        }

        if (player1.Position.Y > 500 || player2.Position.Y > 500)
        {
            Reset();
        }

        foreach (Fireball fireball in fire.getFireballs())
        {
            if (Träffad(p1, fireballTexture, player1.Position, fireball.Position) || Träffad(p2, fireballTexture, player2.Position, fireball.Position))
            {
                Reset();
            }
        }

        
        // TODO: Add your update logic here
        base.Update(gameTime);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();

       _spriteBatch.Draw(startDel, new Vector2(0,0), Color.White);

        if (isPlaying)
        {

            if (lvl1)
            {
                _spriteBatch.Draw(bakgrund, new Vector2(0, 0), Color.White);
                drake.Draw(_spriteBatch);
                _spriteBatch.Draw(nyckelTexture, position5, Color.White);

                _spriteBatch.DrawString(font, ((int)score).ToString(), new Vector2(10, 20), Color.White);

                fire.Draw(_spriteBatch);

                if (!player1.HoppaHögre)
                {
                    _spriteBatch.Draw(fjäderTexture, position6, Color.White);
                }
                if (!player2.HoppaHögre)
                {
                    _spriteBatch.Draw(fjäderTexture, position6, Color.White);
                }

                player1.Draw(_spriteBatch);
                player2.Draw(_spriteBatch);
            }
            else if (lvl2)
            {
                _spriteBatch.Draw(level2, new Vector2(0, 0), Color.White);
                drake.DrawTwo(_spriteBatch);
                _spriteBatch.DrawString(font, ((int)score).ToString(), new Vector2(10, 20), Color.White);
                _spriteBatch.Draw(nyckelTexture, position7, Color.White);

                fire.DrawTwo(_spriteBatch);

                if (!player1.SpringaSnabbare)
                {
                    _spriteBatch.Draw(svampTexture, position10, Color.White);
                }
                if (!player2.SpringaSnabbare)
                {
                    _spriteBatch.Draw(svampTexture, position10, Color.White);
                }
                player1.Draw(_spriteBatch);
                player2.Draw(_spriteBatch);

            }
            else if (lvl3)
            {
                _spriteBatch.Draw(level3, new Vector2(0, 0), Color.White);
                drake.DrawTwo(_spriteBatch);
                _spriteBatch.DrawString(font, ((int)score).ToString(), new Vector2(10, 20), Color.White);
                _spriteBatch.Draw(nyckelTexture, position11, Color.White);

                fire.DrawTwo(_spriteBatch);

                if (!player1.Drack)
                {
                    _spriteBatch.Draw(posionTexture, position15, Color.White);
                }

                if (!player2.Drack)
                {
                    _spriteBatch.Draw(posionTexture, position15, Color.White);
                }
                player1.Draw(_spriteBatch);
                player2.Draw(_spriteBatch);
            }
            else if (lvl4)
            {
                _spriteBatch.Draw(level4, new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(font, ((int)score).ToString(), new Vector2(10, 20), Color.White);
                _spriteBatch.Draw(nyckelTexture, position12, Color.White);
                player1.Draw(_spriteBatch);
                player2.Draw(_spriteBatch);


                if (!player1.Svärd && !player2.Svärd)
                {
                    _spriteBatch.Draw(svärdTexture, position13, Color.White);
                    fire2.DrawTwo(_spriteBatch);
                    drake2.DrawTwo(_spriteBatch);
                    fire.Draw(_spriteBatch);
                    drake.Draw(_spriteBatch);
                    _spriteBatch.Draw(svärdTexture, position14, Color.White);
                }
            }
            else if (slut)
            {
                _spriteBatch.Draw(slutDel, new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(font, "Your Highscore is:", new Vector2(350, 130), Color.White);
                _spriteBatch.DrawString(font, ((int)highScore).ToString(), new Vector2(350, 150), Color.White);
                _spriteBatch.DrawString(font, "Your score is:", new Vector2(350, 180), Color.White);
                _spriteBatch.DrawString(font, ((int)score).ToString(), new Vector2(350, 200), Color.White);
                _spriteBatch.DrawString(font, "You got all the keys!!", new Vector2(350, 220), Color.White);
                _spriteBatch.DrawString(font, "Press space to go again.", new Vector2(350, 280), Color.White);

                _spriteBatch.Draw(nyckelTexture, new Vector2(320, 250), Color.White);
                _spriteBatch.Draw(nyckelTexture2, new Vector2(380, 250), Color.White);
                _spriteBatch.Draw(nyckelTexture3, new Vector2(440, 250), Color.White);
                _spriteBatch.Draw(nyckelTexture4, new Vector2(500, 250), Color.White);
            }
        }
        else
        {
            _spriteBatch.DrawString(font, "Press enter to start!", new Vector2(170, 260), Color.Black);
            _spriteBatch.DrawString(font, "Press P to paus the game.", new Vector2(170, 290), Color.Black);
            _spriteBatch.DrawString(font, "To teleport in level 4 you have to press T and U (if you have played correct).", new Vector2(170, 320), Color.Black);
            if (träffad)
            {
                _spriteBatch.DrawString(font, "You are DEAD!", new Vector2(170, 230), Color.Black);
            }else if(!träffad)
            {
                _spriteBatch.DrawString(font, "The keys to the treasure were stolen by the dragon and his friends.", new Vector2(170, 200), Color.Black);
                _spriteBatch.DrawString(font, "The king gave you the challenge to cellect them!", new Vector2(170, 230), Color.Black);
                if(paus)
                {
                    _spriteBatch.DrawString(font, "You paused.", new Vector2(420, 100), Color.Black);
                }
            }
            
            
        }
        _spriteBatch.End();

        // TODO: Add your drawing code here (kan animera!!)

        base.Draw(gameTime);
    }


    public bool Träffad(Texture2D t1, Texture2D t2, Vector2 p1, Vector2 p2)
    {
        Rectangle oneBox = new Rectangle((int)p1.X, (int)p1.Y, t1.Width, t1.Height);
        Rectangle twoBox = new Rectangle((int)p2.X, (int)p2.Y, t2.Width, t2.Height);
        hit = false;
        //Överlappar vi?
        var kollision = Intersection(oneBox, twoBox);

        if (kollision.Width > 0 && kollision.Height > 0)
        {
            Rectangle r1 = Normalize(oneBox, kollision);
            Rectangle r2 = Normalize(twoBox, kollision);
            hit = TestCollision(t1, r1, t2, r2);
        }
        return hit;
    }

    public static Rectangle Normalize(Rectangle reference, Rectangle overlap)
    {
        //Räkna ut en rektangel som kan användas relativt till referensrektangeln
        return new Rectangle(
            overlap.X - reference.X,
            overlap.Y - reference.Y,
            overlap.Width,
            overlap.Height);
    }

    public static bool TestCollision(Texture2D t1, Rectangle r1, Texture2D t2, Rectangle r2)
    {
        //Beräkna hur många pixlar som finns i området som ska undersökas
        int pixelCount = r1.Width * r1.Height;
        uint[] texture1Pixels = new uint[pixelCount];
        uint[] texture2Pixels = new uint[pixelCount];

        //Kopiera ut pixlarna från båda områdena
        t1.GetData(0, r1, texture1Pixels, 0, pixelCount);
        t2.GetData(0, r2, texture2Pixels, 0, pixelCount);

        //Jämför om vi har några pixlar som överlappar varandra i områdena
        for (int i = 0; i < pixelCount; ++i)
        {
            if (((texture1Pixels[i] & 0xff000000) > 0) && ((texture2Pixels[i] & 0xff000000) > 0))
            {
                return true;
            }
        }
        return false;
    }

    public static Rectangle Intersection(Rectangle r1, Rectangle r2)
    {
        int x1 = Math.Max(r1.Left, r2.Left);
        int y1 = Math.Max(r1.Top, r2.Top);
        int x2 = Math.Min(r1.Right, r2.Right);
        int y2 = Math.Min(r1.Bottom, r2.Bottom);

        if ((x2 >= x1) && (y2 >= y1))
        {
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
        return Rectangle.Empty;
    }

    void Reset()
    {
        score = 0;
        player1.Position = position;
        player2.Position = position2;
        drake.Position = position3;
        fire.Position = positionFire1;

        isPlaying = false;
        träffad = true;
        player1.HoppaHögre = false;
        player2.HoppaHögre = false;
        player1.SpringaSnabbare = false;
        player2.SpringaSnabbare = false;
        player1.Drack = false;
        player2.Drack = false;
        player1.Svärd = false;
        player2.Svärd = false;

        lvl1 = true;
        lvl2 = false;
        lvl3 = false;
        lvl4 = false;
        slut= false;

        fire.Remove();
    }
}
