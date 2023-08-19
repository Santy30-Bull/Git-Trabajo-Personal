using System;

namespace CompiFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ImprimirBienvenida();
            MainLoop();
        }

        public static void ImprimirBienvenida()
        {
            string[] bienvenida = {
                "  *     *   *   *   *   *     * ",
                " *   *   *   *  *   *  *   *    *   *",
                " *       **  *      **    *",
                " *       *   *  *      *   *     *",
                " *   *   *   *  *   *  *   *    *   *",
                "  *    *   *   *   *   *     * "
            };

            foreach (string linea in bienvenida)
            {
                Console.WriteLine(linea.PadLeft(40).PadRight(80));
            }
        }

        public static void MainLoop()
        {
            ImprimirBienvenida();
            RunRepl();
        }
    }
}
