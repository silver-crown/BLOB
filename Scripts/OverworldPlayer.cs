using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLOB.Scripts
{
    public class OverworldPlayer : GameObject
    {
        private PlayerOverworldController controller = new PlayerOverworldController();
        private AnimatedSprite sprite;
        private bool playerSpawned;
        public enum Direction
        {
            UP, DOWN, LEFT, RIGHT
        };
        public Direction direction;

        private int _HP, _MaxHP, _MP, _MaxMP, _LVL, _MaxLVL, _EXP, _MaxEXP;
        float walkspeed = 1.0f;


        private static readonly OverworldPlayer player  = new();

        public OverworldPlayer(SpriteSheet s, Vector2 pos)
        {
            player.sprite = new AnimatedSprite(s);
            player.SetPosition(pos);
        }
        static OverworldPlayer() { }
        private OverworldPlayer() { }
        public static OverworldPlayer PLAYER { get { return player; } }

        private void Update()
        {
            controller.GridMovement();
        }

        public void Walk(Direction d)
        {
            switch (d)
            {
                case Direction.UP:
                    SetPosition(new Vector2(GetPosition().X, GetPosition().Y - walkspeed));
                    //animate going up
                    AnimationHandler("walkUp");
                    break;
                case Direction.DOWN:
                    SetPosition(new Vector2(GetPosition().X, GetPosition().Y + walkspeed));
                    //Animate going down
                    AnimationHandler("walkDown");
                    break;
                case Direction.LEFT:
                    SetPosition(new Vector2(GetPosition().X - walkspeed, GetPosition().Y));
                    //Animate going to the left
                    AnimationHandler("walkLeft");
                    break;
                case Direction.RIGHT:
                    SetPosition(new Vector2(GetPosition().X + walkspeed, GetPosition().Y));
                    //Animate going to the right
                    AnimationHandler("walkRight");
                    break;
            }
        }
        public void SetSprite(SpriteSheet s) => player.sprite = new AnimatedSprite(s);
        public AnimatedSprite GetSprite() => player.sprite;
        void AnimationHandler(string animation) => sprite.Play(animation);

        public int GetHP() => _HP;
        public int GetMaxHP() => _MaxHP;
        public int GetMP() => _MP;
        public int GetMaxMP() => _MaxMP;
        public int GetLVL() => _LVL;
        public int GetMaxLVL() => _MaxLVL;
        public int GetEXP() => _EXP;
        public int GetMaxEXP() => _MaxEXP;

        public void SetHP(int hp) => _HP = hp;
        public void SetMaxHP(int hp) => _MaxHP = hp;
        public void SetMP(int mp) => _MP = mp;
        public void SetMaxMP(int mp) => _MaxMP = mp;
        public void SetLVL(int lvl) => _LVL = lvl;
        private void SetMaxLVL(int lvl) => _LVL = lvl;
        public void SetEXP(int exp) => _EXP = exp;
        public void SetMaxEXP(int exp) => _MaxEXP = exp;

        public void PlayerHasSpawned() => playerSpawned = true;
        public bool HasPlayerSpawned() => playerSpawned; 
    }
}
