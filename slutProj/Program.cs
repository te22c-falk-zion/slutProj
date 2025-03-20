using System;
using System.Media;







PlayMusic("Reflection.wav");
Hero player = new Hero { Name = "Player", HP = 100, ATK = 20, SPD = 100, CR = 20, CD = 150, NorMult = 100, SkiMult = 200, UltMult = 400 };
Hero player2 = new Hero { Name = "Player2", HP = 100, ATK = 20, SPD = 89, CR = 20, CD = 150, NorMult = 100, SkiMult = 200, UltMult = 400 };
List<Hero> heroes = new();
heroes.Add(player);
heroes.Add(player2);
List<Enemy> enemies = new List<Enemy> { new Enemy { Name = "Goblin", HP = 5000000, ATK = 10, SPD = 90 }, new Enemy { Name = "Goblin2", HP = 5000000, ATK = 10, SPD = 90 } };
BattleSystem combat = new BattleSystem(heroes, enemies);
combat.InBattle();




static void PlayMusic(string filename)
{
    SoundPlayer musicPlayer = new SoundPlayer();
    musicPlayer.SoundLocation = filename;
    musicPlayer.PlayLooping();
}

