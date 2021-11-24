using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Fight
    {
        // установить начало сражения
        public void SetStartFight()
        {
            ManagingCommands.isFight = true;
        }

        // установить конец сражения
        public void SetFinishFight()
        {
            ManagingCommands.isFight = false;
        }

        // атака игрока
        public void AttackPlayer(int damage)
        {
            NPC npc = new NPC();
            npc.SetHealthPoints(NPC.healthPoints - damage);
        }

        // атака NPC
        public void AttackNPC(int damage)
        {
            Player player = new Player();
            player.SetHealthPoints(Player.healthPoints - damage);
        }
    }
}
