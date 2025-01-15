using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using OneButtonFight.Source.Engine;
using OneButtonFight.Source.GameObjects;
using OneButtonFight.Source.GameObjects.Units;
using System.Collections;

namespace OneButtonFight.Source.GamePlay
{
    public class GameManager : IUpdate, IDraw
    {
        public Ship player;
        public Enemy enemy;
        public List<Attack> attacks = new();

        public GameManager()
        {
            enemy = new BACircle(new Vector2(Globals.SCREEN_WIDTH/2, Globals.SCREEN_HEIGHT/2), new Vector2(100, 100));
            player = new Ship(enemy, "Sprites\\ship", new Vector2(50, 50), new Vector2(32, 32));

            enemy.SetTarget(player);
            GameGlobals.passAttack = AddAttack;
            GameGlobals.SetDirections(enemy.position, enemy.dimension);
        }

        public void Update()
        {
            for (int i = 0; i < attacks.Count; i++)
            {
                attacks[i].Update();
                attacks[i].warning?.Update();

                if (attacks[i].isDone)
                    attacks.RemoveAt(i);
            }
            enemy.Update();
            player.Update();
        }

        public void Draw()
        {
            for (int i = 0; i < attacks.Count; i++)
            {
                if (attacks[i].warning != null)
                {
                    if (attacks[i].isCasting)
                        attacks[i].warning.Draw();
                    else
                        attacks[i].Draw();
                }
                else
                    attacks[i].Draw();

            }
            enemy.Draw();
            player.Draw();
        }
        public virtual void AddAttack(object attack)
        {
            attacks.Add((Attack)attack);
        }
    }
}
