using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/* Grady Rueffer
 * 152446035
 * OccultTower
 */
//At the moment the menus are purely decorative
//StartGameFromStart is currently required to play the game as key inputs are not being read when the menus are active
//Projectiles are currently not created, so the game acts as a survival game
//Enjoy!


namespace OccultTower
{
    public partial class Form1 : Form
    {
        bool StartGameFromStart = false;

        System.Windows.Media.MediaPlayer menuMusic = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer gameMusic = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer deathMusic = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer torchAmbiance = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer lowHealthMusic = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer gameStart = new System.Windows.Media.MediaPlayer();

        Stopwatch SurvivalWatch = new Stopwatch();

        Rectangle moveHolder = new Rectangle();
        int spriteOperator = 0;

        String chosenCharacter = "Cultist";
        Image chosenCharacterDisplay = Properties.Resources.Cultist__01_;

        int shadowDash = 0;
        int dashDuration = 8;
        int shadowY = 0;
        int shadowX = 0;
        int shadowSkinOp = 1;

        Random rnd = new Random();

        Rectangle healthBar = new Rectangle();
        Rectangle manaBar = new Rectangle();
        Rectangle staminaBar = new Rectangle();

        Rectangle healthBarOutline = new Rectangle();
        Rectangle manaBarOutline = new Rectangle();
        Rectangle staminaBarOutline = new Rectangle();

        Rectangle target = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 35, 35);

        SolidBrush healthBrush = new SolidBrush(Color.Red);
        SolidBrush manaBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush staminaBrush = new SolidBrush(Color.Yellow);

        SolidBrush itemsBrush = new SolidBrush(Color.DarkSlateBlue);

        Rectangle weaponOutline = new Rectangle();
        Rectangle weaponDisplay = new Rectangle();

        Rectangle itemOutline = new Rectangle();
        Rectangle itemDisplay = new Rectangle();

        Rectangle pauseButton = new Rectangle(10, 10, 75, 75);

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

        int leftCooldown = 0;
        int middleCooldown = 0;
        int rightCooldown = 0;

        Image[] walls = new Image[4];
        Rectangle topWall = new Rectangle();
        Rectangle bottomWall = new Rectangle();
        Rectangle leftWall = new Rectangle();
        Rectangle rightWall = new Rectangle();

        int backStorer;
        int wallStorer;
        int wallOutlineStorer;

        TextureBrush wallBrush = new TextureBrush(Properties.Resources.GroundType1);
        TextureBrush wallOutline = new TextureBrush(Properties.Resources.GroundType1);
        Pen wallOutlinePen = new Pen(Color.Navy, 5);

        Image[] cultistDown = new Image[8];
        Image[] cultistLeft = new Image[8];
        Image[] cultistRight = new Image[8];
        Image[] cultistUp = new Image[8];

        Image HealthBarOutline = Properties.Resources.HealthBarOutline;
        Image ManaBarOutline = Properties.Resources.ManaBarOutline;
        Image StaminaBarOutline = Properties.Resources.StaminaBarOutline;

        Image Frame = Properties.Resources.Frame;

        Image PentagramTarget = Properties.Resources.PentagramTarget;

        Image Keris = Properties.Resources.Keris;
        Image Necronomicon = Properties.Resources.Necronomicon;
        Image Sigil = Properties.Resources.Sigil;

        Image Pause = Properties.Resources.PauseIcon;

        Image[] skeletonUp = new Image[9];
        Image[] skeletonLeft = new Image[9];
        Image[] skeletonRight = new Image[9];
        Image[] skeletonDown = new Image[9];

        Rectangle bigDoorA = new Rectangle(0, 0, 150, 110);
        Rectangle bigDoorB = new Rectangle(0, 0, 150, 110);
        Rectangle bigDoorC = new Rectangle(0, 0, 150, 110);

        Image[] bigDoorAImages = new Image[10];
        Image[] bigDoorBImages = new Image[6];
        Image[] bigDoorCImages = new Image[9];

        int bigDoorAAnimationPoint = 0;
        int bigDoorBAnimationPoint = 0;
        int bigDoorCAnimationPoint = 0;

        bool bigDoorAIsOpening = false;
        bool bigDoorBIsOpening = false;
        bool bigDoorCIsOpening = false;

        Rectangle smallDoorLeftA = new Rectangle(0, 0, 15, 75);
        Rectangle smallDoorLeftB = new Rectangle(0, 0, 15, 75);
        Rectangle smallDoorLeftC = new Rectangle(0, 0, 15, 75);

        Image[] smallDoorLeftAImages = new Image[5];
        Image[] smallDoorLeftBImages = new Image[5];
        Image[] smallDoorLeftCImages = new Image[5];

        int smallDoorLeftAAnimationPoint = 0;
        int smallDoorLeftBAnimationPoint = 0;
        int smallDoorLeftCAnimationPoint = 0;

        bool smallDoorLeftAIsOpening = false;
        bool smallDoorLeftBIsOpening = false;
        bool smallDoorLeftCIsOpening = false;

        Rectangle smallDoorRightA = new Rectangle(0, 0, 15, 75);
        Rectangle smallDoorRightB = new Rectangle(0, 0, 15, 75);
        Rectangle smallDoorRightC = new Rectangle(0, 0, 15, 75);

        Image[] smallDoorRightAImages = new Image[5];
        Image[] smallDoorRightBImages = new Image[5];
        Image[] smallDoorRightCImages = new Image[5];

        int smallDoorRightAAnimationPoint = 0;
        int smallDoorRightBAnimationPoint = 0;
        int smallDoorRightCAnimationPoint = 0;

        bool smallDoorRightAIsOpening = false;
        bool smallDoorRightBIsOpening = false;
        bool smallDoorRightCIsOpening = false;

        Rectangle torchUpLeft = new Rectangle(0, 0, 25, 75);
        Rectangle torchDownLeft = new Rectangle(0, 0, 25, 75);

        int torchUpLeftAnimationPoint = 0;
        int torchDownLeftAnimationPoint = 0;

        Rectangle torchUpRight = new Rectangle(0, 0, 25, 75);
        Rectangle torchDownRight = new Rectangle(0, 0, 25, 75);

        int torchUpRightAnimationPoint = 0;
        int torchDownRightAnimationPoint = 0;

        Rectangle torchTopLeft = new Rectangle(0, 0, 25, 75);
        Rectangle torchTopRight = new Rectangle(0, 0, 25, 75);

        int torchTopLeftAnimationPoint = 0;
        int torchTopRightAnimationPoint = 0;

        Image[] torch = new Image[8];
        Image[] torchBlue = new Image[11];

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

        //Set Up Objects
        public struct Projectiles
        {
            public Rectangle area;
            public int xSpeed;
            public int ySpeed;
            public int xSpeedMultiplier;
            public int ySpeedMultiplier;
            public int bounce;
            public bool directionY;
            public bool directionX;
            public int r;
            public int g;
            public int b;
        }

        List<Projectiles> projectileList = new List<Projectiles>();

        public class Weapon
        {
            public Image BaseDisplay;
            public Image ProjectileDisplay;
            public int Damage;
            public String Effect;
            public String PathType;
            public int FadeDistance;
            public int DropOffMultiplier;
            public int cooldown;

            public void Setup(Image _BaseDisplay, Image _ProjectileDisplay, int _Damage, String _Effect, String _PathType, int _FadeDistance, int _DropOffMultiplier, int _cooldown)
            {
                BaseDisplay = _BaseDisplay;
                ProjectileDisplay = _ProjectileDisplay;
                Damage = _Damage;
                Effect = _Effect;
                PathType = _PathType;
                FadeDistance = _FadeDistance;
                DropOffMultiplier = _DropOffMultiplier;
                cooldown = _cooldown;
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
            public int cooldown;
            public Rectangle Area;

            public void Setup(Image _ProjectileDisplay, int _Damage, String _Effect, String _PathType, int _FadeDistance, int _DropOffMultiplier, int _cooldown)
            {
                ProjectileDisplay = _ProjectileDisplay;
                Damage = _Damage;
                Effect = _Effect;
                PathType = _PathType;
                FadeDistance = _FadeDistance;
                DropOffMultiplier = _DropOffMultiplier;
                cooldown = _cooldown;
            }
        }

        public Character Cultist = new Character();
        public Weapon KerisMain = new Weapon();

        public class Villain
        {
            public Image VillainDisplay;
            public int Damage;
            public int Health;
            public int Speed;
            public String Type;
            public int AnimationPoint;
            public Rectangle Area;

            public void Setup(Image _VillainDisplay, int _Damage, int _Health, int _Speed, String _Type, int _AnimationPoint, Rectangle _Area)
            {
                VillainDisplay = _VillainDisplay;
                Damage = _Damage;
                Health = _Health;
                Speed = _Speed;
                Type = _Type;
                AnimationPoint = _AnimationPoint;
                Area = _Area;
            }
        }

        List<Villain> villainList = new List<Villain>();

        bool pressed = false;
        bool wPressed = false;
        bool aPressed = false;
        bool sPressed = false;
        bool dPressed = false;
        bool qPressed = false;
        bool ePressed = false;
        bool spacePressed = false;
        bool shiftPressed = false;
        bool escPressed = false;

        bool leftClick = false;
        bool rightClick = false;
        bool mouseWheel = false;

        List<Weapon> collectedWeapons = new List<Weapon>();
        List<Item> collectedItems = new List<Item>();

        int selectedWeapon = 0;
        int selectedItem = 0;

        public Form1()
        {
            InitializeComponent();

            Cursor.Hide();

            menuMusic.Open(new Uri(Application.StartupPath + "/Resources/480932__wi-photos__menu.wav"));
            gameMusic.Open(new Uri(Application.StartupPath + "/Resources/544906__victor_natas__mysterious-and-spooky-music-version-2.wav"));
            deathMusic.Open(new Uri(Application.StartupPath + "/Resources/Funeral March  Organ Version - Standard Quality 360p [File2HD.com].wav"));
            torchAmbiance.Open(new Uri(Application.StartupPath + "/Resources/649086__jenyaynex__crackling-fire2.wav"));
            lowHealthMusic.Open(new Uri(Application.StartupPath + "/Resources/515405__matrixxx___retro_gaming.wav"));
            gameStart.Open(new Uri(Application.StartupPath + "/Resources/654521__sergequadrado__scary-laugh-3.wav"));

            menuMusic.MediaEnded += new EventHandler(menuMusic_MediaEnded);
            gameMusic.MediaEnded += new EventHandler(gameMusic_MediaEnded);
            deathMusic.MediaEnded += new EventHandler(deathMusic_MediaEnded);
            torchAmbiance.MediaEnded += new EventHandler(torchAmbiance_MediaEnded);
            lowHealthMusic.MediaEnded += new EventHandler(lowHealthMusic_MediaEnded);

            walls[0] = Properties.Resources.GroundType1;
            walls[1] = Properties.Resources.GroundType2;
            walls[2] = Properties.Resources.GroundType3;
            walls[3] = Properties.Resources.GroundType4;

            backStorer = rnd.Next(0, 4);

            wallStorer = rnd.Next(0, 4);

            while (wallStorer == backStorer)
            {
                wallStorer = rnd.Next(0, 4);
            }

            wallOutlineStorer = rnd.Next(0, 4);

            while (wallOutlineStorer == backStorer || wallOutlineStorer == wallStorer)
            {
                wallOutlineStorer = rnd.Next(0, 4);
            }

            wallBrush = new TextureBrush(walls[wallStorer]);
            wallOutline = new TextureBrush(walls[wallOutlineStorer]);
            wallOutlinePen = new Pen(wallOutline, 15);

            this.BackgroundImage = walls[backStorer];

            topWall = new Rectangle(0, 0, this.Width, 100);
            bottomWall = new Rectangle(100, this.Height - 175, this.Width, 100);
            leftWall = new Rectangle(0, 0, 100, this.Height);
            rightWall = new Rectangle(this.Width - 120, 0, 100, this.Height);

            Cultist.Setup(Properties.Resources.Cultist__01_, 9, Properties.Resources.Cultist__01_, Properties.Resources.Cultist__01_, Properties.Resources.Cultist__01_);

            KerisMain.Setup(Properties.Resources.Keris, Properties.Resources.PentagramTarget, 25, "None", "Straight", 5, 2, 5);

            healthBarOutline.Location = new Point(this.Width - maxHealth * 2 - 43, 0);
            healthBar.Location = new Point(healthBarOutline.X + 15, healthBarOutline.Y + healthBarOutline.Height / 2 + 30);

            manaBarOutline.Location = new Point(this.Width - maxMana * 2 - 43, 35);
            manaBar.Location = new Point(manaBarOutline.X + 15, manaBarOutline.Y + manaBarOutline.Height / 2 + 35);

            staminaBarOutline.Location = new Point(this.Width - maxStamina * 2 - 43, 90);
            staminaBar.Location = new Point(staminaBarOutline.X + 15, staminaBarOutline.Y + staminaBarOutline.Height / 2 + 35);

            player = new Rectangle(this.Width / 2 - 55, this.Height / 2 - 75, 45, 55);

            weaponOutline = new Rectangle(-20, this.Height - 225, 185, 125);
            weaponDisplay = new Rectangle(weaponOutline.Width / 2 - 54, this.Height - 197, 69, 69);

            itemOutline = new Rectangle(this.Width - 90, this.Height - 225, 185, 125);
            itemDisplay = new Rectangle(this.Width - 32, this.Height - 197, 69, 69);

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

            //Setup Skeleton Images
            skeletonUp[0] = Properties.Resources.Skeleton__62_;
            skeletonUp[1] = Properties.Resources.Skeleton__63_;
            skeletonUp[2] = Properties.Resources.Skeleton__64_;
            skeletonUp[3] = Properties.Resources.Skeleton__65_;
            skeletonUp[4] = Properties.Resources.Skeleton__66_;
            skeletonUp[5] = Properties.Resources.Skeleton__67_;
            skeletonUp[6] = Properties.Resources.Skeleton__68_;
            skeletonUp[7] = Properties.Resources.Skeleton__69_;
            skeletonUp[8] = Properties.Resources.Skeleton__70_;

            skeletonLeft[0] = Properties.Resources.Skeleton__71_;
            skeletonLeft[1] = Properties.Resources.Skeleton__72_;
            skeletonLeft[2] = Properties.Resources.Skeleton__73_;
            skeletonLeft[3] = Properties.Resources.Skeleton__74_;
            skeletonLeft[4] = Properties.Resources.Skeleton__75_;
            skeletonLeft[5] = Properties.Resources.Skeleton__76_;
            skeletonLeft[6] = Properties.Resources.Skeleton__77_;
            skeletonLeft[7] = Properties.Resources.Skeleton__78_;
            skeletonLeft[8] = Properties.Resources.Skeleton__79_;

            skeletonDown[0] = Properties.Resources.Skeleton__80_;
            skeletonDown[1] = Properties.Resources.Skeleton__81_;
            skeletonDown[2] = Properties.Resources.Skeleton__82_;
            skeletonDown[3] = Properties.Resources.Skeleton__83_;
            skeletonDown[4] = Properties.Resources.Skeleton__84_;
            skeletonDown[5] = Properties.Resources.Skeleton__85_;
            skeletonDown[6] = Properties.Resources.Skeleton__86_;
            skeletonDown[7] = Properties.Resources.Skeleton__87_;
            skeletonDown[8] = Properties.Resources.Skeleton__88_;

            skeletonRight[0] = Properties.Resources.Skeleton__89_;
            skeletonRight[1] = Properties.Resources.Skeleton__90_;
            skeletonRight[2] = Properties.Resources.Skeleton__91_;
            skeletonRight[3] = Properties.Resources.Skeleton__92_;
            skeletonRight[4] = Properties.Resources.Skeleton__93_;
            skeletonRight[5] = Properties.Resources.Skeleton__94_;
            skeletonRight[6] = Properties.Resources.Skeleton__95_;
            skeletonRight[7] = Properties.Resources.Skeleton__96_;
            skeletonRight[8] = Properties.Resources.Skeleton__97_;

            //Setup Resource Bars
            health = maxHealth;

            mana = maxMana;

            stamina = maxStamina;

            healthBarOutline.Size = new Size(health * 2, 75);
            manaBarOutline.Size = new Size(mana * 2 - 8, 75);
            staminaBarOutline.Size = new Size(stamina * 2, 75);

            //Setup Big Door Animations
            bigDoorAImages[0] = Properties.Resources.DoorA__2_;
            bigDoorAImages[1] = Properties.Resources.DoorA__3_;
            bigDoorAImages[2] = Properties.Resources.DoorA__4_;
            bigDoorAImages[3] = Properties.Resources.DoorA__5_;
            bigDoorAImages[4] = Properties.Resources.DoorA__6_;
            bigDoorAImages[5] = Properties.Resources.DoorA__7_;
            bigDoorAImages[6] = Properties.Resources.DoorA__8_;
            bigDoorAImages[7] = Properties.Resources.DoorA__9_;
            bigDoorAImages[8] = Properties.Resources.DoorA__10_;
            bigDoorAImages[9] = Properties.Resources.DoorA__12_;

            bigDoorBImages[0] = Properties.Resources.BossDoor__2_;
            bigDoorBImages[1] = Properties.Resources.BossDoor__3_;
            bigDoorBImages[2] = Properties.Resources.BossDoor__4_;
            bigDoorBImages[3] = Properties.Resources.BossDoor__5_;
            bigDoorBImages[4] = Properties.Resources.BossDoor__6_;
            bigDoorBImages[5] = Properties.Resources.BossDoor__1_;

            bigDoorCImages[0] = Properties.Resources.DoorB__3_;
            bigDoorCImages[1] = Properties.Resources.DoorB__4_;
            bigDoorCImages[2] = Properties.Resources.DoorB__9_;
            bigDoorCImages[3] = Properties.Resources.DoorB__5_;
            bigDoorCImages[4] = Properties.Resources.DoorB__8_;
            bigDoorCImages[5] = Properties.Resources.DoorB__7_;
            bigDoorCImages[6] = Properties.Resources.DoorB__11_;
            bigDoorCImages[7] = Properties.Resources.DoorB__6_;
            bigDoorCImages[8] = Properties.Resources.DoorB__1_;

            //Setup Big Door Locations
            bigDoorA.Location = new Point(Convert.ToInt16(topWall.X + topWall.Width / 4 - 225), topWall.Y + topWall.Height - 100);
            bigDoorB.Location = new Point(Convert.ToInt16(topWall.X + topWall.Width / 2 - 85), topWall.Y + topWall.Height - 100);
            bigDoorC.Location = new Point(Convert.ToInt16(topWall.X + topWall.Width - topWall.Width / 4 + 25), topWall.Y + topWall.Height - 100);

            //Setup Small Door Animations
            smallDoorLeftAImages[0] = Properties.Resources.SideDoorALeft__2_;
            smallDoorLeftAImages[1] = Properties.Resources.SideDoorALeft__3_;
            smallDoorLeftAImages[2] = Properties.Resources.SideDoorALeft__5_;
            smallDoorLeftAImages[3] = Properties.Resources.SideDoorALeft__4_;
            smallDoorLeftAImages[4] = Properties.Resources.SideDoorALeft__1_;

            smallDoorRightAImages[0] = Properties.Resources.Side_Door_A_Right__2_;
            smallDoorRightAImages[1] = Properties.Resources.Side_Door_A_Right__3_;
            smallDoorRightAImages[2] = Properties.Resources.Side_Door_A_Right__5_;
            smallDoorRightAImages[3] = Properties.Resources.Side_Door_A_Right__4_;
            smallDoorRightAImages[4] = Properties.Resources.Side_Door_A_Right__1_;

            smallDoorLeftBImages[0] = Properties.Resources.SideDoorBLeft__2_;
            smallDoorLeftBImages[1] = Properties.Resources.SideDoorBLeft__3_;
            smallDoorLeftBImages[2] = Properties.Resources.SideDoorBLeft__5_;
            smallDoorLeftBImages[3] = Properties.Resources.SideDoorBLeft__4_;
            smallDoorLeftBImages[4] = Properties.Resources.SideDoorBLeft__1_;

            smallDoorRightBImages[0] = Properties.Resources.SideDoorBRight__2_;
            smallDoorRightBImages[1] = Properties.Resources.SideDoorBRight__3_;
            smallDoorRightBImages[2] = Properties.Resources.SideDoorBRight__5_;
            smallDoorRightBImages[3] = Properties.Resources.SideDoorBRight__4_;
            smallDoorRightBImages[4] = Properties.Resources.SideDoorBRight__1_;

            smallDoorLeftCImages[0] = Properties.Resources.SideDoorCLeft__2_;
            smallDoorLeftCImages[1] = Properties.Resources.SideDoorCLeft__3_;
            smallDoorLeftCImages[2] = Properties.Resources.SideDoorCLeft__5_;
            smallDoorLeftCImages[3] = Properties.Resources.SideDoorCLeft__4_;
            smallDoorLeftCImages[4] = Properties.Resources.SideDoorCLeft__1_;

            smallDoorRightCImages[0] = Properties.Resources.SideDoorCRight__2_;
            smallDoorRightCImages[1] = Properties.Resources.SideDoorCRight__3_;
            smallDoorRightCImages[2] = Properties.Resources.SideDoorCRight__5_;
            smallDoorRightCImages[3] = Properties.Resources.SideDoorCRight__4_;
            smallDoorRightCImages[4] = Properties.Resources.SideDoorCRight__1_;


            //Setup Small Door Locations
            smallDoorLeftB.Location = new Point(leftWall.X + leftWall.Width - smallDoorLeftA.Width + 10, leftWall.Y + leftWall.Height / 4 - 50);
            smallDoorLeftA.Location = new Point(leftWall.X + leftWall.Width - smallDoorLeftA.Width + 10, leftWall.Y + leftWall.Height / 2 - 75);
            smallDoorLeftC.Location = new Point(leftWall.X + leftWall.Width - smallDoorLeftA.Width + 10, leftWall.Y + leftWall.Height / 4 * 3 - 75);

            smallDoorRightB.Location = new Point(rightWall.X - 10, leftWall.Y + leftWall.Height / 4 - 50);
            smallDoorRightA.Location = new Point(rightWall.X - 10, leftWall.Y + leftWall.Height / 2 - 75);
            smallDoorRightC.Location = new Point(rightWall.X - 10, leftWall.Y + leftWall.Height / 4 * 3 - 75);

            //Setup Torch Animations
            torch[0] = Properties.Resources.Torch__1_;
            torch[1] = Properties.Resources.Torch__2_;
            torch[2] = Properties.Resources.Torch__3_;
            torch[3] = Properties.Resources.Torch__4_;
            torch[4] = Properties.Resources.Torch__5_;
            torch[5] = Properties.Resources.Torch__6_;
            torch[6] = Properties.Resources.Torch__7_;
            torch[7] = Properties.Resources.Torch__8_;

            torchBlue[0] = Properties.Resources.TorchBlue__1_;
            torchBlue[1] = Properties.Resources.TorchBlue__2_;
            torchBlue[2] = Properties.Resources.TorchBlue__3_;
            torchBlue[3] = Properties.Resources.TorchBlue__4_;
            torchBlue[4] = Properties.Resources.TorchBlue__5_;
            torchBlue[5] = Properties.Resources.TorchBlue__6_;
            torchBlue[6] = Properties.Resources.TorchBlue__7_;
            torchBlue[7] = Properties.Resources.TorchBlue__8_;
            torchBlue[8] = Properties.Resources.TorchBlue__9_;
            torchBlue[9] = Properties.Resources.TorchBlue__10_;
            torchBlue[10] = Properties.Resources.TorchBlue__11_;

            //Setup Torch Locations and Animation Start Points
            torchUpLeftAnimationPoint = rnd.Next(0, 8);
            torchUpRightAnimationPoint = rnd.Next(0, 8);
            torchDownLeftAnimationPoint = rnd.Next(0, 8);
            torchDownRightAnimationPoint = rnd.Next(0, 8);

            torchTopLeftAnimationPoint = rnd.Next(0, 11);
            torchTopRightAnimationPoint = rnd.Next(0, 11);

            torchTopLeft.Location = new Point(Convert.ToInt32(topWall.Width / 8 * 3 + 20), Convert.ToInt32(topWall.Height / 8 - 10));
            torchTopRight.Location = new Point(Convert.ToInt32(topWall.Width / 8 * 5 + 20), Convert.ToInt32(topWall.Height / 8 - 10));

            torchUpLeft.Location = new Point(Convert.ToInt32(leftWall.X + leftWall.Width / 3), Convert.ToInt32(leftWall.Y + leftWall.Height / 8 * 1));
            torchDownLeft.Location = new Point(Convert.ToInt32(leftWall.X + leftWall.Width / 3), Convert.ToInt32(leftWall.Y + leftWall.Height / 8 * 4));
            torchUpRight.Location = new Point(Convert.ToInt32(rightWall.X + rightWall.Width / 3), Convert.ToInt32(rightWall.Y + rightWall.Height / 8 * 1));
            torchDownRight.Location = new Point(Convert.ToInt32(rightWall.X + rightWall.Width / 3), Convert.ToInt32(rightWall.Y + rightWall.Height / 8 * 4));

            if (StartGameFromStart == false)
            {
                ImageOverlay.Visible = true;
                startOperator.Enabled = true;
            }
            else
            {
                menuMusic.Pause();
                gameOperator.Enabled = true;
            }
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
                case Keys.Escape:
                    escPressed = false;
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
                case Keys.Escape:
                    escPressed = true;
                    break;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    leftClick = false;
                    break;
                case MouseButtons.Right:
                    rightClick = false;
                    break;
                case MouseButtons.Middle:
                    mouseWheel = false;
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    leftClick = true;
                    break;
                case MouseButtons.Right:
                    rightClick = true;
                    break;
                case MouseButtons.Middle:
                    mouseWheel = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameOperator.Enabled == true || deathOperator.Enabled == true)
            {
                //Draw Walls
                e.Graphics.FillRectangle(wallBrush, topWall);
                e.Graphics.FillRectangle(wallBrush, leftWall);
                e.Graphics.FillRectangle(wallBrush, rightWall);
                e.Graphics.FillRectangle(wallBrush, bottomWall);

                //Draw Walls Decals
                e.Graphics.DrawLine(wallOutlinePen, 0, 0, leftWall.X + leftWall.Width, topWall.Y + topWall.Height);
                e.Graphics.DrawLine(wallOutlinePen, this.Width, 0, rightWall.X, topWall.Y + topWall.Height);
                e.Graphics.DrawLine(wallOutlinePen, 0, this.Height, leftWall.X + leftWall.Width, bottomWall.Y);
                e.Graphics.DrawLine(wallOutlinePen, this.Width, this.Height, rightWall.X, bottomWall.Y);

                e.Graphics.DrawLine(wallOutlinePen, leftWall.X + leftWall.Width, topWall.Y + topWall.Height, rightWall.X, topWall.Y + topWall.Height);
                e.Graphics.DrawLine(wallOutlinePen, leftWall.X + leftWall.Width, bottomWall.Y, rightWall.X, bottomWall.Y);
                e.Graphics.DrawLine(wallOutlinePen, leftWall.X + leftWall.Width, bottomWall.Y, leftWall.X + leftWall.Width, topWall.Y + topWall.Height);
                e.Graphics.DrawLine(wallOutlinePen, rightWall.X, bottomWall.Y, rightWall.X, topWall.Y + topWall.Height);

                //Draw Doors
                e.Graphics.DrawImage(bigDoorAImages[bigDoorAAnimationPoint], bigDoorA);
                e.Graphics.DrawImage(bigDoorBImages[bigDoorBAnimationPoint], bigDoorB);
                e.Graphics.DrawImage(bigDoorCImages[bigDoorCAnimationPoint], bigDoorC);

                e.Graphics.DrawImage(smallDoorLeftAImages[smallDoorLeftAAnimationPoint], smallDoorLeftA);
                e.Graphics.DrawImage(smallDoorLeftBImages[smallDoorLeftBAnimationPoint], smallDoorLeftB);
                e.Graphics.DrawImage(smallDoorLeftCImages[smallDoorLeftCAnimationPoint], smallDoorLeftC);

                e.Graphics.DrawImage(smallDoorRightAImages[smallDoorRightAAnimationPoint], smallDoorRightA);
                e.Graphics.DrawImage(smallDoorRightBImages[smallDoorRightBAnimationPoint], smallDoorRightB);
                e.Graphics.DrawImage(smallDoorRightCImages[smallDoorRightCAnimationPoint], smallDoorRightC);

                //Draw Torches
                e.Graphics.DrawImage(torch[torchUpLeftAnimationPoint], torchUpLeft);
                e.Graphics.DrawImage(torch[torchDownLeftAnimationPoint], torchDownLeft);
                e.Graphics.DrawImage(torch[torchUpRightAnimationPoint], torchUpRight);
                e.Graphics.DrawImage(torch[torchDownRightAnimationPoint], torchDownRight);

                e.Graphics.DrawImage(torchBlue[torchTopLeftAnimationPoint], torchTopLeft);
                e.Graphics.DrawImage(torchBlue[torchTopRightAnimationPoint], torchTopRight);

                foreach (Villain enemy in villainList)
                {
                    e.Graphics.DrawImage(enemy.VillainDisplay, enemy.Area);
                }

                e.Graphics.DrawImage(chosenCharacterDisplay, player);

                e.Graphics.FillRectangle(healthBrush, healthBar);
                e.Graphics.FillRectangle(manaBrush, manaBar);
                e.Graphics.FillRectangle(staminaBrush, staminaBar);

                e.Graphics.DrawImage(HealthBarOutline, healthBarOutline);
                e.Graphics.DrawImage(ManaBarOutline, manaBarOutline);
                e.Graphics.DrawImage(StaminaBarOutline, staminaBarOutline);

                e.Graphics.DrawImage(Frame, itemOutline);
                e.Graphics.DrawImage(Frame, weaponOutline);

                e.Graphics.FillRectangle(itemsBrush, itemDisplay);
                e.Graphics.FillRectangle(itemsBrush, weaponDisplay);

                e.Graphics.DrawImage(Sigil, itemDisplay);
                e.Graphics.DrawImage(Keris, weaponDisplay);

                e.Graphics.DrawImage(Pause, pauseButton);

                if (leftClick == true)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black), player.X + player.Width / 2, player.Y + player.Height / 2, MousePosition.X, MousePosition.Y);
                }

                if (rightClick == true)
                {
                    e.Graphics.DrawLine(new Pen(Color.White), player.X + player.Width / 2, player.Y + player.Height / 2, MousePosition.X, MousePosition.Y);
                }

                if (mouseWheel == true)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray), player.X + player.Width / 2, player.Y + player.Height / 2, MousePosition.X, MousePosition.Y);
                }
            }

            e.Graphics.DrawImage(PentagramTarget, target);
        }

        public void Reset()
        {
            SurvivalWatch.Stop();
            SurvivalWatch.Reset();

            if (chosenCharacter == "Cultist")
            {
                chosenCharacterDisplay = Properties.Resources.Cultist__01_;
            }

            collectedWeapons.Clear();
            collectedItems.Clear();
            villainList.Clear();

            Cursor.Hide();

            walls[0] = Properties.Resources.GroundType1;
            walls[1] = Properties.Resources.GroundType2;
            walls[2] = Properties.Resources.GroundType3;
            walls[3] = Properties.Resources.GroundType4;

            backStorer = rnd.Next(0, 4);

            wallStorer = rnd.Next(0, 4);

            while (wallStorer == backStorer)
            {
                wallStorer = rnd.Next(0, 4);
            }

            wallOutlineStorer = rnd.Next(0, 4);

            while (wallOutlineStorer == backStorer || wallOutlineStorer == wallStorer)
            {
                wallOutlineStorer = rnd.Next(0, 4);
            }

            wallBrush = new TextureBrush(walls[wallStorer]);
            wallOutline = new TextureBrush(walls[wallOutlineStorer]);
            wallOutlinePen = new Pen(wallOutline, 15);

            this.BackgroundImage = walls[backStorer];

            player.Location = new Point(this.Width / 2 - 55, this.Height / 2 - 75);

            pAccelerationX = 0;
            pAccelerationY = 0;

            //Setup Resource Bars
            health = maxHealth;

            mana = maxMana;

            stamina = maxStamina;

            healthBarOutline.Size = new Size(health * 2, 75);
            manaBarOutline.Size = new Size(mana * 2 - 8, 75);
            staminaBarOutline.Size = new Size(stamina * 2, 75);

            //Setup Torch Animation Start Points
            torchUpLeftAnimationPoint = rnd.Next(0, 8);
            torchUpRightAnimationPoint = rnd.Next(0, 8);
            torchDownLeftAnimationPoint = rnd.Next(0, 8);
            torchDownRightAnimationPoint = rnd.Next(0, 8);

            torchTopLeftAnimationPoint = rnd.Next(0, 11);
            torchTopRightAnimationPoint = rnd.Next(0, 11);

            bigDoorAAnimationPoint = 0;
            bigDoorBAnimationPoint = 0;
            bigDoorCAnimationPoint = 0;

            smallDoorLeftAAnimationPoint = 0;
            smallDoorLeftBAnimationPoint = 0;
            smallDoorLeftCAnimationPoint = 0;
            smallDoorRightAAnimationPoint = 0;
            smallDoorRightBAnimationPoint = 0;
            smallDoorRightCAnimationPoint = 0;

            Cursor.Hide();

            gameOperator.Enabled = true;
        }

        private async void gameOperator_Tick(object sender, EventArgs e)
        {
            torchAmbiance.Play();

            if (health > 25)
            {
                lowHealthMusic.Pause();
                gameMusic.Play();
            }
            else
            {
                gameMusic.Pause();
                lowHealthMusic.Play();
            }

            this.WindowState = FormWindowState.Maximized;

            //Start the Stopwatch
            if (SurvivalWatch.IsRunning == false)
            {
                SurvivalWatch.Start();
            }

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
                    PlayShadow();
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

                if (leftClick == true)
                {
                    Projectile projectileStorer = new Projectile();
                    // projectileStorer.Setup();
                }
            }
            moveHolder.X += pAccelerationX;
            moveHolder.Y += pAccelerationY;

            if (player.Location != moveHolder.Location && rnd.Next(0, 2) == 1)
            {
                PlayFootstep();
            }

            player.Location = moveHolder.Location;

            if (player.IntersectsWith(topWall) || player.Y < 10)
            {
                player.Y = topWall.Y + topWall.Height;
            }

            if (player.IntersectsWith(bottomWall) || player.Y > this.Height - 10)
            {
                player.Y = bottomWall.Y - player.Height;
            }

            if (player.IntersectsWith(leftWall) || player.X < 10)
            {
                player.X = leftWall.X + leftWall.Width;
            }

            if (player.IntersectsWith(rightWall) || player.X > this.Width - 10d)
            {
                player.X = rightWall.X - player.Width;
            }

            //Set Torch Animations
            torchUpLeftAnimationPoint++;
            torchUpRightAnimationPoint++;
            torchDownLeftAnimationPoint++;
            torchDownRightAnimationPoint++;

            if (torchUpLeftAnimationPoint > 7)
            {
                torchUpLeftAnimationPoint = 0;
            }

            if (torchUpRightAnimationPoint > 7)
            {
                torchUpRightAnimationPoint = 0;
            }

            if (torchDownLeftAnimationPoint > 7)
            {
                torchDownLeftAnimationPoint = 0;
            }

            if (torchDownRightAnimationPoint > 7)
            {
                torchDownRightAnimationPoint = 0;
            }


            torchTopLeftAnimationPoint++;
            torchTopRightAnimationPoint++;

            if (torchTopLeftAnimationPoint > 10)
            {
                torchTopLeftAnimationPoint = 0;
            }

            if (torchTopRightAnimationPoint > 10)
            {
                torchTopRightAnimationPoint = 0;
            }

            if (rnd.Next(0, 101) == 1)
            {
                smallDoorLeftAIsOpening = true;
                PlayCreak();
            }

            if (smallDoorLeftAIsOpening == true)
            {
                smallDoorLeftAAnimationPoint++;
                if (smallDoorLeftAAnimationPoint == smallDoorLeftAImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 10, 125, rnd.Next(5, 8), "Skeleton", 0, new Rectangle(smallDoorLeftA.X + smallDoorLeftA.Width - 25, smallDoorLeftA.Y + smallDoorLeftA.Height - 75, 25, 75));
                    smallDoorLeftAIsOpening = false;
                }
            }

            if (smallDoorLeftAIsOpening == false)
            {
                if (smallDoorLeftAAnimationPoint > 0)
                {
                    smallDoorLeftAAnimationPoint--;
                }
            }

            if (rnd.Next(0, 1001) == 1)
            {
                smallDoorLeftBIsOpening = true;
                PlayCreak();
            }

            if (smallDoorLeftBIsOpening == true)
            {
                smallDoorLeftBAnimationPoint++;
                if (smallDoorLeftBAnimationPoint == smallDoorLeftBImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 5, 50, rnd.Next(10, 16), "Skeleton", 0, new Rectangle(smallDoorLeftB.X + smallDoorLeftB.Width - 15, smallDoorLeftB.Y + smallDoorLeftB.Height - 50, 15, 50));
                    smallDoorLeftBIsOpening = false;
                }
            }

            if (smallDoorLeftBIsOpening == false)
            {
                if (smallDoorLeftBAnimationPoint > 0)
                {
                    smallDoorLeftBAnimationPoint--;
                }
            }

            if (rnd.Next(0, 101) == 1)
            {
                smallDoorLeftCIsOpening = true;
                PlayCreak();
            }

            if (smallDoorLeftCIsOpening == true)
            {
                smallDoorLeftCAnimationPoint++;
                if (smallDoorLeftCAnimationPoint == smallDoorLeftCImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 10, 125, rnd.Next(5, 8), "Skeleton", 0, new Rectangle(smallDoorLeftC.X + smallDoorLeftC.Width - 25, smallDoorLeftC.Y + smallDoorLeftC.Height - 75, 25, 75));
                    smallDoorLeftCIsOpening = false;
                }
            }

            if (smallDoorLeftCIsOpening == false)
            {
                if (smallDoorLeftCAnimationPoint > 0)
                {
                    smallDoorLeftCAnimationPoint--;
                }
            }

            if (rnd.Next(0, 101) == 1)
            {
                smallDoorRightAIsOpening = true;
                PlayCreak();
            }

            if (smallDoorRightAIsOpening == true)
            {
                smallDoorRightAAnimationPoint++;
                if (smallDoorRightAAnimationPoint == smallDoorRightAImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 10, 125, rnd.Next(5, 8), "Skeleton", 0, new Rectangle(smallDoorRightA.X + smallDoorRightA.Width - 25, smallDoorRightA.Y + smallDoorRightA.Height - 75, 25, 75));
                    smallDoorRightAIsOpening = false;
                }
            }

            if (smallDoorRightAIsOpening == false)
            {
                if (smallDoorRightAAnimationPoint > 0)
                {
                    smallDoorRightAAnimationPoint--;
                }
            }

            if (rnd.Next(0, 1001) == 1)
            {
                smallDoorRightBIsOpening = true;
                PlayCreak();
            }

            if (smallDoorRightBIsOpening == true)
            {
                smallDoorRightBAnimationPoint++;
                if (smallDoorRightBAnimationPoint == smallDoorRightBImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 5, 50, rnd.Next(10, 16), "Skeleton", 0, new Rectangle(smallDoorRightB.X + smallDoorRightB.Width - 15, smallDoorRightB.Y + smallDoorRightB.Height - 50, 15, 50));
                    smallDoorRightBIsOpening = false;
                }
            }

            if (smallDoorRightBIsOpening == false)
            {
                if (smallDoorRightBAnimationPoint > 0)
                {
                    smallDoorRightBAnimationPoint--;
                }
            }

            if (rnd.Next(0, 101) == 1)
            {
                smallDoorRightCIsOpening = true;
                PlayCreak();
            }

            if (smallDoorRightCIsOpening == true)
            {
                smallDoorRightCAnimationPoint++;
                if (smallDoorRightCAnimationPoint == smallDoorRightCImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 10, 125, rnd.Next(3, 8), "Skeleton", 0, new Rectangle(smallDoorRightC.X + smallDoorRightC.Width - 25, smallDoorRightC.Y + smallDoorRightC.Height - 75, 25, 75));
                    smallDoorRightCIsOpening = false;
                }
            }

            if (smallDoorRightCIsOpening == false)
            {
                if (smallDoorRightCAnimationPoint > 0)
                {
                    smallDoorRightCAnimationPoint--;
                }
            }

            if (rnd.Next(0, 501) == 1)
            {
                bigDoorAIsOpening = true;
                PlayCreak();
            }

            if (bigDoorAIsOpening == true)
            {
                bigDoorAAnimationPoint++;
                if (bigDoorAAnimationPoint == bigDoorAImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 25, 500, rnd.Next(3, 6), "Skeleton", 0, new Rectangle(bigDoorA.X + bigDoorA.Width - 50, bigDoorA.Y + bigDoorA.Height - 100, 50, 100));
                    bigDoorAIsOpening = false;
                }
            }

            if (bigDoorAIsOpening == false)
            {
                if (bigDoorAAnimationPoint > 0)
                {
                    bigDoorAAnimationPoint--;
                }
            }

            if (rnd.Next(0, 5001) == 1)
            {
                bigDoorBIsOpening = true;
                PlayCreak();
            }

            if (bigDoorBIsOpening == true)
            {
                bigDoorBAnimationPoint++;
                if (bigDoorBAnimationPoint == bigDoorBImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 25, 500, 1, "Skeleton", 0, new Rectangle(bigDoorB.X + bigDoorB.Width - 100, bigDoorB.Y + bigDoorB.Height - 150, 100, 150));
                    bigDoorBIsOpening = false;
                }
            }

            if (bigDoorBIsOpening == false)
            {
                if (bigDoorBAnimationPoint > 0)
                {
                    bigDoorBAnimationPoint--;
                }
            }

            if (rnd.Next(0, 501) == 1)
            {
                bigDoorCIsOpening = true;
                PlayCreak();
            }

            if (bigDoorCIsOpening == true)
            {
                bigDoorCAnimationPoint++;
                if (bigDoorCAnimationPoint == bigDoorCImages.Length)
                {
                    villainList.Add(new Villain());
                    villainList[villainList.Count - 1].Setup(skeletonDown[0], 25, 500, rnd.Next(3, 6), "Skeleton", 0, new Rectangle(bigDoorC.X + bigDoorC.Width - 50, bigDoorC.Y + bigDoorC.Height - 100, 50, 100));
                    bigDoorCIsOpening = false;
                }
            }

            if (bigDoorCIsOpening == false)
            {
                if (bigDoorCAnimationPoint > 0)
                {
                    bigDoorCAnimationPoint--;
                }
            }

            foreach (Villain enemy in villainList)
            {
                if (enemy.Type == "Skeleton")
                {
                    if (enemy.Area.IntersectsWith(player) && shadowDash <= 0)
                    {
                        health -= enemy.Damage;

                        if (enemy.Area.X > player.X)
                        {
                            pAccelerationX = -10;
                        }

                        else if (enemy.Area.X < player.X)
                        {
                            pAccelerationX = 10;
                        }

                        if (enemy.Area.Y > player.Y)
                        {
                            pAccelerationY = -10;
                        }

                        else if (enemy.Area.Y < player.Y)
                        {
                            pAccelerationY = 10;
                        }
                    }

                    else
                    {
                        if (enemy.Area.Y < player.Y)
                        {
                            enemy.Area.Y += enemy.Speed;
                            enemy.VillainDisplay = skeletonDown[enemy.AnimationPoint];
                        }

                        else if (enemy.Area.Y > player.Y)
                        {
                            enemy.Area.Y -= enemy.Speed;
                            enemy.VillainDisplay = skeletonUp[enemy.AnimationPoint];
                        }

                        if (enemy.Area.X < player.X)
                        {
                            enemy.Area.X += enemy.Speed;
                            enemy.VillainDisplay = skeletonRight[enemy.AnimationPoint];
                        }

                        else if (enemy.Area.X > player.X)
                        {
                            enemy.Area.X -= enemy.Speed;
                            enemy.VillainDisplay = skeletonLeft[enemy.AnimationPoint];
                        }

                        if (rnd.Next(0, 101) <= 5)
                        {
                            PlaySkeleton();
                        }
                    }

                    enemy.AnimationPoint++;

                    if (enemy.AnimationPoint >= 9)
                    {
                        enemy.AnimationPoint = 0;
                    }
                }
            }

            //Set the bars to the resources remaining
            healthBar.Size = new Size(Convert.ToInt16(Math.Round(health * 1.8)), 15);
            manaBar.Size = new Size(Convert.ToInt16(Math.Round(mana * 1.8) - 9), 15);
            staminaBar.Size = new Size(Convert.ToInt16(Math.Round(stamina * 1.8)), 15);

            //Set Custom Cursor
            target.Location = new Point(Convert.ToInt16(MousePosition.X - target.Width / 2), Convert.ToInt16(MousePosition.Y - target.Height / 2));

            if (escPressed == true || target.IntersectsWith(pauseButton) && leftClick == true)
            {
                gameMusic.Pause();
                lowHealthMusic.Pause();
                torchAmbiance.Pause();
                menuMusic.Play();
                SurvivalWatch.Stop();
                PauseOp();
            }

            if (health <= 0)
            {
                gameMusic.Stop();
                torchAmbiance.Stop();
                lowHealthMusic.Stop();
                gameOperator.Stop();
                deathOperator.Enabled = true;
            }

            Refresh();
        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {
            //Set Custom Cursor (Does not work, is drawing on form)
            //target.Location = new Point(Convert.ToInt16(MousePosition.X - target.Width / 2), Convert.ToInt16(MousePosition.Y - target.Height / 2));

            Cursor.Show();

            Refresh();
        }

        public void PauseOp()
        {
            escPressed = false;

            PlaySelect();

            if (pauseOverlay.Visible == false)
            {
                gameOperator.Stop();

                pauseOverlay.Visible = true;
                pauseLabel.Visible = true;
                resumeButton.Visible = true;
                restartButton.Visible = true;
                optionsButtonP.Visible = true;
                exitToMainMenuButton.Visible = true;
                exitGameButton.Visible = true;

                pauseOverlay.Location = new Point(0, 0);
                pauseOverlay.Size = this.Size;

                pauseLabel.Location = new Point(this.Width / 2 - pauseLabel.Width / 2, 25);
                resumeButton.Location = new Point(this.Width / 2 - resumeButton.Width / 2, 200);
                restartButton.Location = new Point(this.Width / 2 - restartButton.Width / 2, 350);
                optionsButtonP.Location = new Point(this.Width / 2 - optionsButtonP.Width / 2, 500);
                exitToMainMenuButton.Location = new Point(Convert.ToInt32(this.Width / 2 - exitToMainMenuButton.Width * 1.5), 600);
                exitGameButton.Location = new Point(Convert.ToInt32(this.Width / 2 + exitGameButton.Width / 2), 600);

                Cursor.Show();

                pauseTimer.Enabled = true;
            }

            else
            {
                pauseTimer.Enabled = false;

                pauseOverlay.Visible = false;
                pauseLabel.Visible = false;
                resumeButton.Visible = false;
                restartButton.Visible = false;
                optionsButtonP.Visible = false;
                exitToMainMenuButton.Visible = false;
                exitGameButton.Visible = false;

                menuMusic.Pause();

                gameOperator.Enabled = true;

                Cursor.Hide();
            }
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            PlaySelect();
            Application.Exit();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            PlaySelect();
            menuMusic.Pause();
            Reset();
            PauseOp();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            PauseOp();
            menuMusic.Pause();
        }

        private void exitToMainMenuButton_Click(object sender, EventArgs e)
        {
            PauseOp();
            gameOperator.Enabled = false;
            menuOperator.Enabled = true;
        }

        private void optionsButtonP_Click(object sender, EventArgs e)
        {
            PauseOp();
            ImageOverlay.BackgroundImage = Properties.Resources.OccultTowerOptionMenu;
            optionsOperator.Enabled = true;
        }

        private void startOperator_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            //Reset GameStart Sound
            gameStart.Stop();

            ImageOverlay.Visible = true;
            ImageOverlay.Location = new Point(0, 0);
            ImageOverlay.Size = this.Size;
            ImageOverlay.BackgroundImageLayout = ImageLayout.Zoom;
            ImageOverlay.BackgroundImage = Properties.Resources.OccultTowerStartScreen;

            startButton.Location = new Point(this.Width / 2 - startButton.Width / 2, 250);
            optionButtonS.Location = new Point(this.Width / 2 - optionButtonS.Width / 2, 400);
            exitGameButton.Location = new Point(this.Width / 2 - exitGameButton.Width / 2, 550);

            startButton.Visible = true;
            optionButtonS.Visible = true;
            exitGameButton.Visible = true;

            Cursor.Show();
        }

        private void optionsOperatorS_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            startButton.Visible = false;
            optionButtonS.Visible = false;
            exitGameButton.Visible = false;

            ImageOverlay.BackgroundImage = Properties.Resources.OccultTowerOptionMenu;

            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(125, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();
                startOperator.Enabled = true;
                optionsOperatorS.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width / 2 - 125, this.Height - 50, 250, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();
                controlOperator.Enabled = true;
                optionsOperatorS.Stop();
            }
        }

        private void controlOperator_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            ImageOverlay.BackgroundImage = Properties.Resources.OccultTowerControlsOverlay;

            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(125, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();
                optionsOperatorS.Enabled = true;
                controlOperator.Stop();
            }
        }

        private void optionsOperator_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(125, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();
                startOperator.Enabled = true;
                optionsOperator.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width / 2 - 125, this.Height - 50, 250, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();
                controlOperator.Enabled = true;
                optionsOperator.Stop();
            }
        }

        private void menuOperator_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            //Reset GameStart Sound
            gameStart.Stop();

            ImageOverlay.BackgroundImage = Properties.Resources.OccultTower_Main_Menu;

            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width / 2 - 50, this.Height / 2 - 25, 100, 50)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Start the game
                menuMusic.Pause();
                gameStart.Play();
                Reset();
                gameOperator.Enabled = true;

                //Close the menu
                ImageOverlay.Visible = false;
                menuOperator.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(125, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Go back to the start screen
                startOperator.Enabled = true;

                //Close the menu
                menuOperator.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width - 250, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Start the game
                optionsOperatorM.Enabled = true;

                //Close the menu
                menuOperator.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(125, this.Height - 65, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Close the program
                Application.Exit();
            }
        }

        private void optionButtonS_Click(object sender, EventArgs e)
        {
            PlaySelect();
            startOperator.Stop();
            optionsOperatorS.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            PlaySelect();

            menuOperator.Enabled = true;

            startButton.Visible = false;
            optionButtonS.Visible = false;
            exitGameButton.Visible = false;

            startOperator.Stop();
        }

        private void deathOperator_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            SurvivalWatch.Stop();

            ImageOverlay.Visible = true;
            ImageOverlay.Location = new Point(0, 00);
            ImageOverlay.Size = new Size(this.Width, this.Height - 200);
            ImageOverlay.BackgroundImageLayout = ImageLayout.Zoom;
            ImageOverlay.BackgroundImage = Properties.Resources.Tombstone;
            Cursor.Show();

            deathTimeLabel.Text = SurvivalWatch.Elapsed.ToString("mm\\:ss\\.ff");
            deathTimeLabel.Visible = true;
            deathTimeLabel.Location = new Point(this.Width / 2 - deathTimeLabel.Width / 2, 285);

            deathMusic.Play();

            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width / 2 - 75, ImageOverlay.Height - 20, 150, 50)) && leftClick == true)
            {
                deathMusic.Stop();
                PlaySelect();

                //Activate the next timer
                menuOperator.Enabled = true;

                //Change Visible Elements
                ImageOverlay.Size = this.Size;
                deathTimeLabel.Visible = false;

                //Stop the current timer
                deathOperator.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width / 2 - 75 - 150 - 50, ImageOverlay.Height - 20, 150, 50)) && leftClick == true)
            {
                deathMusic.Stop();
                PlaySelect();

                //Activate the next timer
                Reset();
                ImageOverlay.Visible = false;
                SurvivalWatch.Reset();
                gameOperator.Enabled = true;

                //Change Visible Elements
                ImageOverlay.Size = this.Size;
                deathTimeLabel.Visible = false;

                //Stop the current timer
                deathOperator.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width / 2 - 75 + 150 + 50, ImageOverlay.Height - 20, 150, 50)) && leftClick == true)
            {
                deathMusic.Stop();
                PlaySelect();

                //Exit the Application
                Application.Exit();
            }
        }

        private void controlOperatorP_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            //Set the background to the controls overlay
            ImageOverlay.BackgroundImage = Properties.Resources.OccultTowerControlsOverlay;

            //Track the mouse
            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(125, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Go back to the options menu
                optionsOperator.Enabled = true;

                //Hide the controls
                controlOperatorP.Stop();
            }
        }

        private void optionsOperatorM_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            //Track the mouse
            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(125, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Go back to the menu
                menuOperator.Enabled = true;

                //Close the options
                optionsOperator.Stop();
            }

            if (MouseTracker.IntersectsWith(new Rectangle(this.Width / 2 - 125, this.Height - 50, 250, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Show the controlls
                controlOperatorM.Enabled = true;

                //Hide the options
                optionsOperator.Stop();
            }
        }

        private void controlOperatorM_Tick(object sender, EventArgs e)
        {
            menuMusic.Play();

            //Set the background to the controls overlay
            ImageOverlay.BackgroundImage = Properties.Resources.OccultTowerControlsOverlay;


            //Track the mouse
            Rectangle MouseTracker = new Rectangle(MousePosition.X, MousePosition.Y, 25, 25);

            if (MouseTracker.IntersectsWith(new Rectangle(125, 0, 125, 125)) && leftClick == true || escPressed == true)
            {
                PlaySelect();

                //Go back to the options menu
                optionsOperatorM.Enabled = true;

                //Hide the controlls
                controlOperatorM.Stop();
            }
        }

        //I got concurrent Audio Working! Very cool! :D
        private void PlaySkeleton()
        {
            var skeleton = new System.Windows.Media.MediaPlayer();

            skeleton.Open(new Uri(Application.StartupPath + "/Resources/420252__redroxpeterpepper__step-skeleton.wav"));

            skeleton.Play();
        }

        private void PlaySelect()
        {
            var select = new System.Windows.Media.MediaPlayer();

            select.Open(new Uri(Application.StartupPath + "/Resources/220203__gameaudio__casual-death-loose.wav"));

            select.Play();
        }

        private void PlayFootstep()
        {
            var footstep = new System.Windows.Media.MediaPlayer();

            footstep.Open(new Uri(Application.StartupPath + "/Resources/659370__matrixxx___retro-footsteps.wav"));

            footstep.Play();
        }

        private void PlayShadow()
        {
            var shadow = new System.Windows.Media.MediaPlayer();

            shadow.Open(new Uri(Application.StartupPath + "/Resources/483694__camouflaged_noob__shadows1.wav"));

            shadow.Play();
        }

        private void PlayCreak()
        {
            var creak = new System.Windows.Media.MediaPlayer();

            switch (rnd.Next(0, 4))
            {
                case 0:
                    creak.Open(new Uri(Application.StartupPath + "/Resources/219492__jarredgibb__door-creak-02.wav"));
                    break;
                case 1:
                    creak.Open(new Uri(Application.StartupPath + "/Resources/219499__jarredgibb__door-creak.wav"));
                    break;
                case 2:
                    creak.Open(new Uri(Application.StartupPath + "/Resources/346211__inspectorj__door-squeak-normal-e.wav"));
                    break;
                case 3:
                    creak.Open(new Uri(Application.StartupPath + "/Resources/460542__coosemek__door-creak.wav"));
                    break;
            }

            creak.Play();
        }

        private void menuMusic_MediaEnded(object sender, EventArgs e)
        {
            //Repeat Media
            menuMusic.Stop();
            menuMusic.Play();
        }
        private void gameMusic_MediaEnded(object sender, EventArgs e)
        {
            //Repeat Media
            gameMusic.Stop();
            gameMusic.Play();
        }
        private void deathMusic_MediaEnded(object sender, EventArgs e)
        {
            //Repeat Media
            deathMusic.Stop();
            deathMusic.Play();
        }
        private void lowHealthMusic_MediaEnded(object sender, EventArgs e)
        {
            //Repeat Media
            lowHealthMusic.Stop();
            lowHealthMusic.Play();
        }
        private void torchAmbiance_MediaEnded(object sender, EventArgs e)
        {
            //Repeat Media
            torchAmbiance.Stop();
            torchAmbiance.Play();
        }
    }
}
