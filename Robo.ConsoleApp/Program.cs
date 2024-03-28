namespace Robo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region  Informa a area
            Console.WriteLine("Digite a área do X: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a área do Y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            #endregion

            #region Variaveis auxiliares
            int xfinal = 0;
            int yfinal = 0;
            string atualdirection = "";

            int contador = 0;
            int XAuxiliar = 0;
            int YAuxiliar = 0;
            string direcaoAuxiliar = "";
            #endregion

            while (contador != 2)
            {
                XAuxiliar = xfinal;
                YAuxiliar = yfinal;
                direcaoAuxiliar = atualdirection;

                #region posicao inicial
                Console.WriteLine("Digite a posição X inicial do robo: ");
                int robox = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite a posição Y inicial do robo: ");
                int roboy = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite direção inicial do robo: \nN - norte \nL - leste \nS - sul \nO - oeste");
                string direction = Convert.ToString(Console.ReadLine());

                #endregion

                #region informacoes de movimento
                xfinal = robox;
                yfinal = roboy;

                string right = "D";
                string left = "E";

                atualdirection = direction;

                Console.WriteLine("Digite a sequência de comando para o robo: ");
                string[] comands = Console.ReadLine().Split(" ");
                #endregion

                CalculaCaminho(ref xfinal, ref yfinal, ref atualdirection, right, left, comands);
                contador++;

            }

            ExibeResultado(xfinal, yfinal, atualdirection, XAuxiliar, YAuxiliar, direcaoAuxiliar);
        }

        private static void CalculaCaminho(ref int xfinal, ref int yfinal, ref string atualdirection, string right, string left, string[] comands)
        {
            foreach (string i in comands)
            {
                if (i == right)
                {
                    switch (atualdirection)
                    {
                        case "N":
                            atualdirection = "L";
                            break;

                        case "L":
                            atualdirection = "S";
                            break;

                        case "S":
                            atualdirection = "O";
                            break;

                        case "O":
                            atualdirection = "N";
                            break;
                    }
                }
                else if (i == left)
                {
                    switch (atualdirection)
                    {
                        case "N":
                            atualdirection = "O";
                            break;

                        case "L":
                            atualdirection = "N";
                            break;

                        case "S":
                            atualdirection = "L";
                            break;

                        case "O":
                            atualdirection = "S";
                            break;

                    }
                }
                else
                {
                    switch (atualdirection)
                    {
                        case "N":
                            yfinal++;
                            break;

                        case "S":
                            yfinal--;
                            break;

                        case "L":
                            xfinal++;
                            break;

                        case "O":
                            xfinal--;
                            break;

                    }
                }
            }
        }

        private static void ExibeResultado(int xfinal, int yfinal, string atualdirection, int XAuxiliar, int YAuxiliar, string direcaoAuxiliar)
        {
            Console.WriteLine("\n");

            Console.WriteLine($"({XAuxiliar},{YAuxiliar}) {direcaoAuxiliar}");

            Console.WriteLine($"({xfinal},{yfinal}) {atualdirection}");

            Console.WriteLine("Pressione enter para sair");

            Console.ReadLine();
        }
    }
}
