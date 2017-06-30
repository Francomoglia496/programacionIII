using IAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AgenteDLL
{
    class Agente : ISolverAgent
    {

        private Stack<Point> Recorrido { get; set; }

        private List<Point> CeldasVisitadas { get; set; }

        private Point end;

        public Agente()
        {
        }

        //Algortmo de resolucion del laberinto
        public Point moveAgent(params Point[] directions)
        {
            if (Recorrido.Count == 0)
            {
                Recorrido.Push(directions[0]);
                CeldasVisitadas.Add(directions[0]);
                return directions[0];

            }
            else
            {
                foreach (Point punto in directions)
                {
                    if (!CeldasVisitadas.Contains(punto))
                    {
                        CeldasVisitadas.Add(punto);
                        Recorrido.Push(punto);
                        return punto;
                    }
                }
                Recorrido.Pop();
                foreach (Point punto in directions)
                {
                    if (punto.Equals(Recorrido.Peek()))
                    {
                        return punto;
                    }
                }

                return end;
            }
        }


    }
}