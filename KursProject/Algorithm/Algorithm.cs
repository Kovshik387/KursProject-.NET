using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.Algorithm
{
    public class Algorithm
    {
        public void StartSearchKontur(List<EdgeN> edge_n, List<Vertex> vertex_l, ref List<string> cycle_matrix)
        {
            int[] color = new int[vertex_l.Count];
            for (int i = 0; i < vertex_l.Count; i++)
            {
                for (int j = 0; j < vertex_l.Count; j++) color[j] = 1;
                List<int> cycle = new() { i + 1 };
                DFSKontur(i, i, edge_n, color, -1, cycle, cycle_matrix);
            }
        }

        private void DFSKontur(int postition, int endVert, List<EdgeN> E, int[] color, int unavailableEdge, List<int> cycle, List<string> cycle_matrix)
        {
            if (postition != endVert)       // если значения равны, то мы не должны присваивать ей цвет, иначе мы не вернёмся в неё
                color[postition] = 2;       // любое значение отличное от "белого" и "чёрного"
            else
            {
                if (cycle.Count >= 2)
                {
                    string s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    cycle_matrix.Add(s);
                    return;
                }
            }

            for (int i = 0; i < E.Count; i++)
            {
                if (i == unavailableEdge) continue;

                if (color[E[i].IdEnd] == 1 && E[i].IdStart == postition)
                {
                    List<int> cycleNEW = new(cycle)
                    {
                        E[i].IdEnd + 1
                    };
                    DFSKontur(E[i].IdEnd, endVert, E, color, i, cycleNEW, cycle_matrix);
                    color[E[i].IdEnd] = 1;
                }
            }

        }
    }
}
