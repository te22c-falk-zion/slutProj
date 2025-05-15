public class EnemySpawner 
{
    public static List<Enemy> CreateEnemies(float stage)
    {
        var enemies = new List<Enemy>
        {
            new Enemy { Name = "Goboblin", HP = 25000, ATK = 100, SPD = 90},
            new Enemy { Name = "Goblito", HP = 25000, ATK = 100, SPD = 90},
            new Enemy { Name = "Gobleta", HP = 25000, ATK = 100, SPD = 90},
            new Enemy { Name = "Jonathan", HP = 25000, ATK = 100, SPD = 90}
        };
        enemies.ForEach(e => e.LevelUp(stage));
        return enemies;
    }
}