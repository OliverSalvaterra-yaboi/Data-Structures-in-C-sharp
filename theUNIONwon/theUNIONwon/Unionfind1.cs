using System;
using System.Collections.Generic;
using System.Text;

namespace theUNIONwon
{
    class Unionfind<T>
    {
        Dictionary<int, string> names = new Dictionary<int, string>();
        public pear[] problem;
        string[] ppl;
        public void init(string[] ppls)
        {
            problem = new pear[ppls.Length];

            ppl = ppls;

            for (int i = 0; i < problem.Length; i++)
            {
                problem[i] = new pear(0, 0);
                problem[i].location = i;
                problem[i].key = problem[i].location;
                names.Add(i, ppl[i]);
            }
        }

        public bool ismarried(string a, string b)
        {
            int bint = 0;
            int aint = 0;

            for(int i = 0; i < names.Count; i++)
            {
                if(ppl[i] == a)
                {
                    aint = i;
                }
                if(ppl[i] == b)
                {
                    bint = i;
                }
            }

            if(problem[aint].key == problem[bint].key)
            {
                return true;
            }
            return false;
        }

        
        public bool union(string a, string b)
        {
            int aint = 0;
            int bint = 0;

            for (int i = 0; i < names.Count; i++)
            {
                if (ppl[i] == a)
                {
                    aint = i;
                }
                if (ppl[i] == b)
                {
                    bint = i;
                }
            }

            if (ismarried(a, b))
            {
                return false;
            }
            else
            {
                problem[bint].key = problem[aint].key;
                
            }
            return true;
        }

        public List<List<string>> friendslist()
        {
            List<List<string>> groups = new List<List<string>>(0);
            List<string> groupa = new List<string>();
                        groups.Add(groupa);
                        groupa.Add(ppl[0]);
            for(int i = 0; i < ppl.Length; i++)
            {
                for(int j = 1; j < groups.Count; j++)
                {
                    if(ismarried(ppl[i], groups[j][0]))
                    {
                        groups[j].Add(ppl[i]);
                        i++;
                    }
                }
                List<string> group = new List<string>();
                groups.Add(group);
            }
            return groups;
        }
    }
}
