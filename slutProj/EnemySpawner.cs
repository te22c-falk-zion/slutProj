public class EnemySpawner 
{

    private static readonly List<Enemy> SpawnableEnemies = new()
    {
        new Enemy("Goboblin",25000,25000,95,90,0,0),
        new Enemy("Goblito",25000,25000,95,90,0,0),
        new Enemy("ArmorMan",28000,28000,150,85,0,0),
        new Enemy("WolfDude",24000,24000,130,110,0,0),
        new Enemy("Eonz",30000,30000,200,60,0,0)
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
                (
                    SpawnableEnemies[selectEnemy].GetFighterName(),
                    SpawnableEnemies[selectEnemy].GetFighterFloat("MaxHealth"),
                    SpawnableEnemies[selectEnemy].GetFighterFloat("Health"),
                    SpawnableEnemies[selectEnemy].GetFighterFloat("Attack"),
                    SpawnableEnemies[selectEnemy].GetFighterFloat("Speed"),
                    0,
                    0
                );
                enemy.LevelUp(stage);
                enemies.Add(enemy);
             }
        }

        return enemies;
    }
}