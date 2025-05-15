public class EnemySpawner 
{

    private static readonly List<Enemy> SpawnableEnemies = new()
    {
        new Enemy { Name = "Goboblin", HP = 25000, ATK = 95, SPD = 90 },
        new Enemy { Name = "Goblito", HP = 25000, ATK = 95, SPD = 90 },
        new Enemy { Name = "Gobleta", HP = 25500, ATK = 90, SPD = 90 },
        new Enemy { Name = "Jonathan", HP = 24500, ATK = 105, SPD = 90 },
        new Enemy { Name = "ArmorMan", HP = 28000, ATK = 150, SPD = 85 },
        new Enemy { Name = "WolfDude", HP = 24000, ATK = 130, SPD = 110 },
        new Enemy { Name = "Eonz", HP = 30000, ATK = 200, SPD = 60 }
    };
    public static List<Enemy> CreateEnemies(float stage, int enemyAmount = 4)
    {
        Random rnd = new Random();
        HashSet<int> selectedEnemies = new HashSet<int>(); 
        List<Enemy> enemies = new();

        while(selectedEnemies.Count < enemyAmount)
        {
            int selectEnemy = rnd.Next(SpawnableEnemies.Count);
             if (selectedEnemies.Add(selectEnemy))
             {
                Enemy enemy = new Enemy
                {
                    Name = SpawnableEnemies[selectEnemy].Name,
                    HP = SpawnableEnemies[selectEnemy].HP,
                    ATK = SpawnableEnemies[selectEnemy].ATK,
                    SPD = SpawnableEnemies[selectEnemy].SPD
                };
                enemy.LevelUp(stage);
                enemies.Add(enemy);
             }
        }

        return enemies;
    }
}