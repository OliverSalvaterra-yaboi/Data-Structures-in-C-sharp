using System;
using System.Collections.Generic;
using System.IO;

namespace theUNIONwon
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("../../../friends.txt");

            string[] ppl = new string[int.Parse(file[0])];

            for(int i = 0; i < ppl.Length; i++)
            {
                /*int h = 0;
                for(int j = 0; j < file[i].Length; i++)
                {
                    if(file[i][j] == 226)
                    {
                        i++;
                    }
                    ppl[h] = file[i];
                    h++;
                }*/
                ppl[i] = file[i+1];
            }

            Unionfind<string> friendsandoffices = new Unionfind<string>();

            friendsandoffices.init(ppl);

            for(int i = ppl.Length+1; i < file.Length; i++)
            {
                string[] wordses = file[i].Split(',');
                friendsandoffices.union(wordses[0], wordses[1]);
            }

            for(int i = 0; i < ppl.Length; i++)
            {
                Console.WriteLine(ppl[i] + ", " + friendsandoffices.problem[i].location + ", " + friendsandoffices.problem[i].key);
            }
            List<List<string>> groups = friendsandoffices.friendslist();
            for(int i = 0; i < groups.Count; i++)
            {
                for(int j = 0; j < groups[i].Count; j++)
                {
                    Console.Write(groups[i][j] + ", ");
                }
                Console.WriteLine();
            }
            
            /*friendsandoffices.union("Joey" , "Chandler");
            friendsandoffices.union("Chandler", "Ross");
            friendsandoffices.union("Ross" , "Rachel");
            friendsandoffices.union("Joey" , "Phoebe");
            friendsandoffices.union("Chandler" , "Monica");
            friendsandoffices.union("Rachel" , "Monica");
            friendsandoffices.union("Michael" , "Jim");
            friendsandoffices.union("Jim" , "Pam");
            friendsandoffices.union("Pam" , "Dwight");
            friendsandoffices.union("Ryan" , "Kelly");
            friendsandoffices.union("Michael" ,"Ryan");*/
        }
    }
}
