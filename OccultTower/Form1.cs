using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OccultTower
{
    public partial class Form1 : Form
    {
        Rectangle moveHolder = new Rectangle();
        int spriteOperator = 0;

        String chosenCharacter = "Cultist";
        Image chosenCharacterDisplay = Properties.Resources.Cultist__01_;

        int shadowDash = 0;
        int dashDuration = 8;
        int shadowY = 0;
        int shadowX = 0;
        int shadowSkinOp = 1;

        Rectangle healthBar = new Rectangle();
        Rectangle manaBar = new Rectangle();
        Rectangle staminaBar = new Rectangle();

        Rectangle healthBarOutline = new Rectangle();
        Rectangle manaBarOutline = new Rectangle();
        Rectangle staminaBarOutline = new Rectangle();

        //Look Here Setup
        Rectangle target = new Rectangle(0, 0, 35, 35);

        SolidBrush healthBrush = new SolidBrush(Color.Red);
        SolidBrush manaBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush staminaBrush = new SolidBrush(Color.Yellow);

        Rectangle player = new Rectangle();
        int pAccelerationX = 0;
        int pAccelerationY = 0;
        int accelerationValue = 4;

        int maxHealth = 100;
        int health;

        int maxMana = 100;
        int mana;

        int maxStamina = 100;
        int stamina;

        Image[] cultistDown = new Image[8];
        Image[] cultistLeft = new Image[8];
        Image[] cultistRight = new Image[8];
        Image[] cultistUp = new Image[8];

        public class Character
        {
            public Image BaseDisplay;
            public int speed;
            public Image primaryStarter;
            public Image secondaryStarter;
            public Image Item;

            public void Setup(Image _BaseDisplay, int _speed, Image _primaryStarter, Image _secondaryStarter, Image _Item)
            {
                BaseDisplay = _BaseDisplay;
                speed = _speed;
                primaryStarter = _primaryStarter;
                secondaryStarter = _secondaryStarter;
                Item = _Item;
            }
        }

        public class Weapon
        {
            public Image BaseDisplay;
            public Image ProjectileDisplay;
            public int Damage;
            public String Effect;
            public String PathType;
            public int FadeDistance;
            public int DropOffMultiplier;

            public void Setup(Image _BaseDisplay, Image _ProjectileDisplay, int _Damage, String _Effect, String _PathType, int _FadeDistance, int _DropOffMultiplier)
            {
                BaseDisplay = _BaseDisplay;
                ProjectileDisplay = _ProjectileDisplay;
                Damage = _Damage;
                Effect = _Effect;
                PathType = _PathType;
                FadeDistance = _FadeDistance;
                DropOffMultiplier = _DropOffMultiplier;
            }
        }

        public class Item
        {
            public Image BaseDisplay;
            public int Duration;
            public String Effect;

            public void Setup(Image _BaseDisplay, int _Duration, String _Effect)
            {
                BaseDisplay = _BaseDisplay;
                Duration = _Duration;
                Effect = _Effect;
            }
        }

        public class Projectile
        {
            public Image ProjectileDisplay;
            public int Damage;
            public String Effect;
            public String PathType;
            public int FadeDistance;
            public int DropOffMultiplier;

            public void Setup(Image _ProjectileDisplay, int _Damage, String _Effect, String _PathType, int _FadeDistance, int _DropOffMultiplier)
            {
                ProjectileDisplay = _ProjectileDisplay;
                Damage = _Damage;
                Effect = _Effect;
                PathType = _PathType;
                FadeDistance = _FadeDistance;
                DropOffMultiplier = _DropOffMultiplier;
            }
        }

        public Character Cultist = new Character();

        bool pressed = false;
        bool wPressed = false;
        bool aPressed = false;
        bool sPressed = false;
        bool dPressed = false;
        bool qPressed = false;
        bool ePressed = false;
        bool spacePressed = false;
        bool shiftPressed = false;

        public Form1()
        {
            InitializeComponent();

            Cultist.Setup(Properties.Resources.Cultist__01_, 9, Properties.Resources.Cultist__01_, Properties.Resources.Cultist__01_, Properties.Resources.Cultist__01_);

            healthBarOutline.Location = new Point(this.Width - maxHealth * 2 + 50, 0);
            healthBar.Location = new Point(healthBarOutline.X + 15, healthBarOutline.Y + healthBarOutline.Height / 2 + 30);

            manaBarOutline.Location = new Point(this.Width - maxMana * 2 + 57, 35);
            manaBar.Location = new Point(manaBarOutline.X + 17, manaBarOutline.Y + manaBarOutline.Height / 2 + 35);

            staminaBarOutline.Location = new Point(this.Width - maxStamina * 2 + 50, 90);

            staminaBar.Location = new Point(staminaBarOutline.X + 15, staminaBarOutline.Y + staminaBarOutline.Height / 2 + 35);

            player = new Rectangle(this.Width / 2 - 55, this.Height / 2 - 75, 45, 55);

            cultistDown[0] = Properties.Resources.Cultist__01_;
            cultistDown[1] = Properties.Resources.Cultist__03_;
            cultistDown[2] = Properties.Resources.Cultist__05_;
            cultistDown[3] = Properties.Resources.Cultist__061_;
            cultistDown[4] = Properties.Resources.Cultist__02_;
            cultistDown[5] = Properties.Resources.Cultist__04_;
            cultistDown[6] = Properties.Resources.Cultist__06_;
            cultistDown[7] = Properties.Resources.Cultist__062_;

            cultistLeft[0] = Properties.Resources.Cultist__07_;
            cultistLeft[1] = Properties.Resources.Cultist__08_;
            cultistLeft[2] = Properties.Resources.Cultist__09_;
            cultistLeft[3] = Properties.Resources.Cultist__10_;
            cultistLeft[4] = Properties.Resources.Cultist__11_;
            cultistLeft[5] = Properties.Resources.Cultist__12_;
            cultistLeft[6] = Properties.Resources.Cultist__13_;
            cultistLeft[7] = Properties.Resources.Cultist__14_;

            cultistRight[0] = Properties.Resources.Cultist__15_;
            cultistRight[1] = Properties.Resources.Cultist__16_;
            cultistRight[2] = Properties.Resources.Cultist__17_;
            cultistRight[3] = Properties.Resources.Cultist__18_;
            cultistRight[4] = Properties.Resources.Cultist__19_;
            cultistRight[5] = Properties.Resources.Cultist__20_;
            cultistRight[6] = Properties.Resources.Cultist__21_;
            cultistRight[7] = Properties.Resources.Cultist__22_;

            cultistUp[0] = Properties.Resources.Cultist__23_;
            cultistUp[1] = Properties.Resources.Cultist__24_;
            cultistUp[2] = Properties.Resources.Cultist__25_;
            cultistUp[3] = Properties.Resources.Cultist__26_;
            cultistUp[4] = Properties.Resources.Cultist__27_;
            cultistUp[5] = Properties.Resources.Cultist__28_;
            cultistUp[6] = Properties.Resources.Cultist__29_;
            cultistUp[7] = Properties.Resources.Cultist__30_;

            health = maxHealth;

            mana = maxMana;

            stamina = maxStamina;

            healthBarOutline.Size = new Size(health * 2, 75);
            manaBarOutline.Size = new Size(mana * 2 - 8, 75);
            staminaBarOutline.Size = new Size(stamina * 2, 75);

            gameOperator.Enabled = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressed = false;
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Q:
                    qPressed = false;
                    break;
                case Keys.E:
                    ePressed = false;
                    break;
                case Keys.Space:
                    spacePressed = false;
                    break;
                case Keys.ShiftKey:
                    shiftPressed = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressed = true;
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Q:
                    qPressed = true;
                    break;
                case Keys.E:
                    ePressed = true;
                    break;
                case Keys.Space:
                    spacePressed = true;
                    break;
                case Keys.ShiftKey:
                    shiftPressed = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(chosenCharacterDisplay, player);

            e.Graphics.FillRectangle(healthBrush, healthBar);
            e.Graphics.FillRectangle(manaBrush, manaBar);
            e.Graphics.FillRectangle(staminaBrush, staminaBar);

            e.Graphics.DrawImage(Properties.Resources.HealthBarOutline, healthBarOutline);
            e.Graphics.DrawImage(Properties.Resources.ManaBarOutline, manaBarOutline);
            e.Graphics.DrawImage(Properties.Resources.StaminaBarOutline, staminaBarOutline);

            e.Graphics.DrawImage(Properties.Resources.PentagramTarget, target);
        }

        public void Reset()
        {
            if (chosenCharacter == "Cultist")
            {
                chosenCharacterDisplay = Properties.Resources.Cultist__01_;
            }
        }

        private async void gameOperator_Tick(object sender, EventArgs e)
        {
            //Set rectangle to hold the new location
            moveHolder.Location = player.Location;

            //Activate Shadow Dash
            if (shadowDash > 0)
            {
                if (wPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        shadowY -= Cultist.speed;

                        if (shadowSkinOp == 1)
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistUpShadow1;
                            shadowSkinOp = 2;
                        }

                        else
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistUpShadow2;
                            shadowSkinOp = 1;
                        }
                    }
                }

                if (aPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        shadowX -= Cultist.speed;

                        if (shadowSkinOp == 1)
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistLftShadow1;
                            shadowSkinOp = 2;
                        }

                        else
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistLftShadow2;
                            shadowSkinOp = 1;
                        }
                    }
                }

                if (sPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        shadowY += Cultist.speed;

                        if (shadowSkinOp == 1)
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistDwnShadow1;
                            shadowSkinOp = 2;
                        }

                        else
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistDwnShadow2;
                            shadowSkinOp = 1;
                        }
                    }
                }

                if (dPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        shadowX += Cultist.speed;

                        if (shadowSkinOp == 1)
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistRghShadow1;
                            shadowSkinOp = 2;
                        }

                        else
                        {
                            chosenCharacterDisplay = Properties.Resources.CultistRghShadow2;
                            shadowSkinOp = 1;
                        }
                    }
                }

                moveHolder.X += shadowX;
                moveHolder.Y += shadowY;
                player.Location = moveHolder.Location;

                shadowDash--;

                if (shadowDash <= 0)
                {
                    shadowX = 0;
                    shadowY = 0;
                    shadowDash = dashDuration * -5;

                    chosenCharacterDisplay = cultistDown[spriteOperator];
                }
            }

            //Move player
            else
            {
                if (wPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        moveHolder.Y -= Cultist.speed;
                    }
                }

                if (aPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        moveHolder.X -= Cultist.speed;
                    }
                }

                if (sPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        moveHolder.Y += Cultist.speed;
                    }
                }

                if (dPressed == true)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        moveHolder.X += Cultist.speed;
                    }
                }

                if (spacePressed == true && shadowDash == 0)
                {
                    shadowDash = dashDuration;
                }

                if (moveHolder.X < player.X)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        chosenCharacterDisplay = cultistLeft[spriteOperator];

                        spriteOperator++;

                        if (spriteOperator > 7)
                        {
                            spriteOperator = 0;
                        }
                    }

                    if (shiftPressed == true && stamina % 10 == 0 && stamina > 0)
                    {
                        pAccelerationX -= accelerationValue;
                    }
                }

                else if (moveHolder.X > player.X)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        chosenCharacterDisplay = cultistRight[spriteOperator];

                        spriteOperator++;

                        if (spriteOperator > 7)
                        {
                            spriteOperator = 0;
                        }
                    }

                    if (shiftPressed == true && stamina % 10 == 0 && stamina > 0)
                    {
                        pAccelerationX += accelerationValue;
                    }
                }

                else if (moveHolder.Y < player.Y)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        chosenCharacterDisplay = cultistUp[spriteOperator];

                        spriteOperator++;

                        if (spriteOperator > 7)
                        {
                            spriteOperator = 0;
                        }
                    }

                    if (shiftPressed == true && stamina % 10 == 0 && stamina > 0)
                    {
                        pAccelerationY -= accelerationValue;
                    }
                }

                else if (moveHolder.Y > player.Y)
                {
                    if (chosenCharacter == "Cultist")
                    {
                        chosenCharacterDisplay = cultistDown[spriteOperator];

                        spriteOperator++;

                        if (spriteOperator > 7)
                        {
                            spriteOperator = 0;
                        }
                    }

                    if (shiftPressed == true && stamina % 10 == 0 && stamina > 0)
                    {
                        pAccelerationY += accelerationValue;
                    }
                }

                if (shiftPressed == true && stamina > 0)
                {
                    stamina--;
                }

                else
                {
                    if (stamina < maxStamina)
                    {
                        stamina++;
                    }

                    if (pAccelerationX > 0)
                    {
                        pAccelerationX--;
                    }

                    else if (pAccelerationX < 0)
                    {
                        pAccelerationX++;
                    }

                    if (pAccelerationY > 0)
                    {
                        pAccelerationY--;
                    }

                    else if (pAccelerationY < 0)
                    {
                        pAccelerationY++;
                    }
                }

                if (shadowDash < 0)
                {
                    shadowDash++;
                }
            }
            moveHolder.X += pAccelerationX;
            moveHolder.Y += pAccelerationY;
            player.Location = moveHolder.Location;

            healthBar.Size = new Size(Convert.ToInt16(Math.Round(health * 1.8)), 15);
            manaBar.Size = new Size(Convert.ToInt16(Math.Round(mana * 1.8) - 9), 15);
            staminaBar.Size = new Size(Convert.ToInt16(Math.Round(stamina * 1.8)), 15);

            //Look Here
            target.Location = new Point(Convert.ToInt16(MousePosition.X - target.X), Convert.ToInt16(MousePosition.Y - target.Y));

            Refresh();
        }
    }
}
