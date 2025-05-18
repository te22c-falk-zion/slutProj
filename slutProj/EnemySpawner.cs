using System.Security.Cryptography.X509Certificates;

public class EnemySpawner 
{

    //Initialiserar listor för basic enemies och bossarna.
    private static readonly List<Enemy> SpawnableEnemies = new()
    {
        new Enemy("Goboblin",25000,25000,95,90,0,0),
        new Enemy("Goblito",25000,25000,95,90,0,0),
        new Enemy("ArmorMan",28000,28000,150,85,0,0),
        new Enemy("WolfDude",24000,24000,130,110,0,0),
        new Enemy("Eonz",30000,30000,200,60,0,0)
    };
    private static readonly List<Enemy> SpawnableBosses = new()
    {
        new Boss("Tanker",50000,50000,95,90,0,0),
        new Boss("Fighter",25000,25000,200,90,0,0),
        new Boss("Speedster",18000,18000,120,200,0,0),
    };
    private static Queue<Enemy> nextWave = new();


    //skapar enemies.
    public static List<Enemy> CreateEnemies(float stage, int enemyAmount = 4)
    {
        List<Enemy> spawnedEnemies = new();

        //Om din stage är 10,20,30 etc så tömer man enemy qeuen och spawnar en boss.
        if (stage % 10 == 0)
        {
            enemyAmount = 1;
            nextWave.Clear();
            CreateBoss(stage);
        }
        //annars om enemy queuen inte har nog med enemies för att fylla banan
        //skapa enemies inom enemy queuen.
        else if (nextWave.Count < enemyAmount)
        {
            // två gånger så att den är överfylld.
            CreateEnemyQueue(stage, enemyAmount);
            CreateEnemyQueue(stage, enemyAmount);
        }

        // Lägg till enemies från queuen i spawned enemies för varje enemy amount som finns.
        for (int i = 0; i < enemyAmount && nextWave.Count > 0; i++)
        {
            spawnedEnemies.Add(nextWave.Dequeue());
        }

        return spawnedEnemies;
    }


    //Creates enemies and then puts them into a queue that will be dequed whenever the active enemies are empty.
    public static void CreateEnemyQueue(float stage, int amount)
    {
        
        Random rnd = new Random();
        HashSet<int> selectedEnemies = new HashSet<int>(); 


        while(selectedEnemies.Count < amount)
        {
            int selectEnemy = rnd.Next(SpawnableEnemies.Count);
            // selectedEnemies.Add(selectEnemy);
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
                nextWave.Enqueue(enemy);
             }
        }
    }

    //Like the one previously but this one just makes a singlurar boss.
    public static void CreateBoss(float stage)
    {

        Random rnd = new Random();

        int selectEnemy = rnd.Next(SpawnableBosses.Count);
        Boss enemy = new Boss
        (
            SpawnableBosses[selectEnemy].GetFighterName(),
            SpawnableBosses[selectEnemy].GetFighterFloat("MaxHealth"),
            SpawnableBosses[selectEnemy].GetFighterFloat("Health"),
            SpawnableBosses[selectEnemy].GetFighterFloat("Attack"),
            SpawnableBosses[selectEnemy].GetFighterFloat("Speed"),
            0,
            0
        );
        //dividing stage by 2 since otherwise it'd be too strong.
        enemy.LevelUp(stage/2);
        nextWave.Enqueue(enemy);


    }
}