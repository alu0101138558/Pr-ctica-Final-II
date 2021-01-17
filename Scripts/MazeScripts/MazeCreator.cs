using UnityEngine;




/*public class DirectionsVector
{
    public static readonly Vector3 NORTH = Vector3.forward;
    public static readonly Vector3 EAST = Vector3.right;
    public static readonly Vector3 SOUTH = Vector3.back;
    public static readonly Vector3 WEST = Vector3.left;
}*/

public enum Direction : int
{
    UNKOWN = -1,
    NORTH = 0, //(0,+1)
    EAST = 1, //(+1,0)
    SOUTH = 2, //(0,-1)
    WEST = 3 //(-1,0)
}
public class MazeCellHandler
{
    private GameObject cell = null;
    private string[] wallNames = new string[]{  "Wall-North", "Wall-East", "Wall-South", "Wall-West" };
    private GameObject[] cardinalWalls = null;
    private bool[] cardinalWallsExists = null;

    private bool visited = false;
    public bool Visited { get => visited; set => visited = value; }
    public MazeCellHandler(GameObject cell)
    {
        cardinalWalls = new GameObject[wallNames.Length];
        cardinalWallsExists = new bool[wallNames.Length];
        this.cell = cell;
        for(int i = 0; i < wallNames.Length; i++)
        {
            var transformWall = cell.transform.Find(wallNames[i]);
            if (transformWall == null)
                throw new MissingComponentException("Se esperaba un muro con nombre "+wallNames[i]+" pero no se encontro.Asegurese de setear razonadamente el muro que desea con ese nombre en prefab");
            cardinalWalls[i] = transformWall.gameObject;
            cardinalWallsExists[i] = true;
        }     
    }

    public void makePath(Direction dir)
    {
        if (this.cardinalWallsExists[(int)dir])
        {
            GameObject.Destroy(this.cardinalWalls[(int)dir]);
            this.cardinalWallsExists[(int)dir] = false;
        }
       
    }

}
public class MazeCreator : MonoBehaviour
{
    public Camera mainCamera = null;


    private Vector3 startLocation = Vector3.zero;
    public GameObject cellPrefab = null;
    [Range(1,20)]
    public int length = 10;
    [Range(1, 20)]
    public int width = 10;

    public Direction startDirection = Direction.SOUTH;

    //Para mantenerlo parametrizado por si en un futuro se desea ampliar el número de direcciones posibles.
    private readonly int numOfDirs = 4;

    //El tamaño en m del suelo (para evitar colocar cada celda una encima de la otra)
    public int floorWidth = 3;
    public int floorLength = 3;

    //El tamaño en m del techo (de momento para nada)
    private int roofWidth = 3;
    private int roofHeight = 3;

    

    private MazeCellHandler[,] mazeCells = null;
    private int currentRow = 0;
    private int currentColumn = 0;
    private bool courseComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        mazeCells = new MazeCellHandler[length, width];
        startLocation = this.transform.position;
        for (int r = 0; r < length; r++)
            for(int c = 0; c < width; c++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(startLocation.x + (r * floorLength), startLocation.y + 0, startLocation.z + (c * floorWidth)), Quaternion.identity);
                cell.transform.parent = this.transform;
                cell.name = "Celda[" + r + "," + c + "]";
                mazeCells[r, c] = new MazeCellHandler(cell);
            }

        //Una entrada
        this.mazeCells[currentRow, currentColumn].Visited = true;
        this.mazeCells[currentRow, currentColumn].makePath(startDirection);

        //Una salida
        this.mazeCells[length-1, width-1].makePath(Direction.NORTH);
        //huntAndKillAlgorithm
        while (!courseComplete)
        {
            Kill(); // Will run until it hits a dead end.
            Hunt(); // Finds the next unvisited cell with an adjacent visited cell. If it can't find any, it sets courseComplete to true.
        }

        bool success = false;
        //UnityEditor.PrefabUtility.SaveAsPrefabAsset(this.gameObject, "./Assets/Prefabs/Mazes/Maze_"+ length +"x"+ width + "_"+ System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".prefab", out success);
        if (success) Debug.Log("Se ha guardado correctamente");
        //this.gameObject.SetActive(false);
    }

    private int[] updateCoordsMovinginDir(Direction dir, int[] actualCoords)
    {
        switch (dir)
        {
            case Direction.NORTH:
                return new int[] { actualCoords[0], actualCoords[1] + 1};
            case Direction.EAST:
                return new int[] { actualCoords[0] + 1, actualCoords[1]};
            case Direction.SOUTH:
                return new int[] { actualCoords[0], actualCoords[1] - 1 };
            case Direction.WEST:
                return new int[] { actualCoords[0] - 1, actualCoords[1] };
            default:
                return actualCoords;
        }
    }

    private Direction getOppositeDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.NORTH:
                return Direction.SOUTH;
            case Direction.EAST:
                return Direction.WEST;
            case Direction.SOUTH:
                return Direction.NORTH;
            case Direction.WEST:
                return Direction.EAST;
            default:
                return Direction.UNKOWN;
        }
    }
    private bool cellStillHasAvailablesAround(int row, int column)
    {
        int availableRoutes = 0;

        if (column < mazeCells.GetLength(1)-1 && !mazeCells[row, column + 1].Visited) //Comprobamos al Norte
            availableRoutes++;

        if(row < mazeCells.GetLength(0)-1 && !mazeCells[row+1, column].Visited) //Comprobamos al Este
            availableRoutes++;

        if (column > 0 && !mazeCells[row, column - 1].Visited) //Comprobamos al Sur
            availableRoutes++;

        if (row > 0 && !mazeCells[row - 1, column].Visited) //Comprobamos al Oeste
            availableRoutes++;

        return availableRoutes > 0;
    }

    private bool isCellAvailable(int row, int column)
    {
        //Miro si no sobrepaso los limites y por último compruebo que no he visitado ya esa celda
        return (row >= 0 && row < mazeCells.GetLength(0) && column >= 0 && column < mazeCells.GetLength(1) && !mazeCells[row, column].Visited);
    }


    private void Kill()
    {
        while (cellStillHasAvailablesAround(currentRow, currentColumn))
        {
            Direction dir = (Direction)Random.Range(0, numOfDirs + 1); //Seleccionamos una dirección aleatoria.

            var updatedCoords = this.updateCoordsMovinginDir(dir, new int[] { currentRow, currentColumn });
            var oppositeDir = this.getOppositeDirection(dir);
            if(isCellAvailable(updatedCoords[0], updatedCoords[1]))
            {
                mazeCells[currentRow, currentColumn].makePath(dir); //Nos movemos en dirección 'dir', tumbamos el muro en ese muro
                if(oppositeDir != Direction.UNKOWN) //Nunca se sabe... Pero viene bien considerar esta condición desde ya para futuras ampliaciones.
                    mazeCells[updatedCoords[0], updatedCoords[1]].makePath(oppositeDir); //Y en la siguiente celda, por lo tanto, el muro contiguo, sino estariamos haciendo la mitad del trabajo
                //Actualizamos los indices
                currentRow = updatedCoords[0];
                currentColumn = updatedCoords[1];
            }

            mazeCells[currentRow, currentColumn].Visited = true;
        }
    }

    private void Hunt()
    {
        this.courseComplete = true; // Set it to this, and see if we can prove otherwise below!

        for (int r = 0; r < this.mazeCells.GetLength(0); r++)
        {
            for (int c = 0; c < this.mazeCells.GetLength(1); c++)
            {
                if (!mazeCells[r, c].Visited && cellHasAdjacentsVisitedCells(r, c))
                {
                    this.courseComplete = false; // Yep, we found something so definitely do another Kill cycle.
                    currentRow = r;
                    currentColumn = c;
                    destroyAdjacentVisitedWall(currentRow, currentColumn);
                    mazeCells[currentRow, currentColumn].Visited = true;
                    return; // Exit the function
                }
            }
        }
    }

    private bool cellHasAdjacentsVisitedCells(int row, int column)
    {
        int availableRoutes = 0;

        if (column < mazeCells.GetLength(1)-1 && mazeCells[row, column + 1].Visited) //Comprobamos al Norte
            availableRoutes++;

        if (row < mazeCells.GetLength(0)-1 && mazeCells[row + 1, column].Visited) //Comprobamos al Este
            availableRoutes++;

        if (column > 0 && mazeCells[row, column - 1].Visited) //Comprobamos al Sur
            availableRoutes++;

        if (row > 0 && mazeCells[row - 1, column].Visited) //Comprobamos al Oeste
            availableRoutes++;

        return availableRoutes > 0;
    }

    private void destroyAdjacentVisitedWall(int currentRow, int currentColumn)
    {
        bool wallDestroyed = false;
        while (!wallDestroyed)
        {
            Direction dir = (Direction)Random.Range(0, numOfDirs + 1); //Seleccionamos una dirección aleatoria.

            var updatedCoords = this.updateCoordsMovinginDir(dir, new int[] { currentRow, currentColumn });
            var oppositeDir = this.getOppositeDirection(dir);
            bool available = false;
            switch(dir){
                case Direction.NORTH:
                    //No queremos eliminar muros de las celdas en los limites en esta fase, ellos nos llevaría a poder caer al vacio o fuera del mapa
                    if (updatedCoords[1] < mazeCells.GetLength(1) && mazeCells[updatedCoords[0], updatedCoords[1]].Visited)
                        available = true;
                    break;
                case Direction.EAST:
                    if (updatedCoords[0] < mazeCells.GetLength(1) && mazeCells[updatedCoords[0], updatedCoords[1]].Visited)
                        available = true;
                    break;
                case Direction.SOUTH:
                    if (updatedCoords[1] >= 0 && mazeCells[updatedCoords[0], updatedCoords[1]].Visited)
                        available = true;
                    break;
                case Direction.WEST:
                    if (updatedCoords[0] >= 0 && mazeCells[updatedCoords[0], updatedCoords[1]].Visited)
                        available = true;
                    break;
                default:
                    available = false;
                    break;
            }
            if (available)
            {
                mazeCells[currentRow, currentColumn].makePath(dir); //Nos movemos en dirección 'dir', tumbamos el muro en ese muro
                if (oppositeDir != Direction.UNKOWN) //Nunca se sabe... Pero viene bien considerar esta condición desde ya para futuras ampliaciones.
                    mazeCells[updatedCoords[0], updatedCoords[1]].makePath(oppositeDir); //Y en la siguiente celda, por lo tanto, el muro contiguo, sino estariamos haciendo la mitad del trabajo 
                wallDestroyed = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
