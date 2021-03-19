using System;
using System.Collections.Generic;
using System.Text;

namespace skippybippy
{
    class skippilist<T> where T : IComparable//, ICollection<T>
    {
        public int count;

        
        Node<T> doot = new Node<T>(default, 1, new List<Node<T>>());
        
        public void init()
        {
            doot.childrens.Add(null);
        }

        public int maxh()
        {
            /*int max = 0;
            Node<T> placebnode = doot;
            for(int i = 0; i <= count; i++)
            {
                if(placebnode.child.height > max)
                {
                    max = placebnode.child.height;
                }
                placebnode = placebnode.child;
            }
            doot.height = max;*/
            return doot.height;
        }

        public int ranHeight()
        {
            Random rnd = new Random();
            bool breaker = false;

            int h = 1;
            while (!breaker)
            {
                int count = 0;
                while (count <= h)
                {
                    if (rnd.Next(0, 1) == 0 || h == maxh() + 1)
                    {
                        breaker = true;
                    }
                }
                h++;
            }
            //when creating new node that is maxh+1, set root children to +1 and link
            return h;
        }

        public bool insert (T key)
        {
            Node<T> placebnode = doot;
            int youllneverknowhatthisisusedfor = maxh();
            if(doot.childrens[0] == null)
            {
                Node<T> nullnode = null;
                doot.childrens[0] = new Node<T>(key, ranHeight(), nullnode);
                if(doot.childrens[0].height > doot.height)
                {
                    doot.height++;
                }
            }
            for(int i = 0; i < doot.height; i++)
            {
                while(placebnode.childrens[maxh()-1] != null)
                {
                    if (placebnode.childrens[youllneverknowhatthisisusedfor].Key.CompareTo(key) >= 0)
                    {
                        
                        Node<T> node = new Node<T>(key, ranHeight(), placebnode.child);
                        if (node.height > doot.height)
                        {
                            doot.height++;
                            doot.childrens.Add(node);
                            count++;
                            return true;
                        }
                        else
                        {
                            placebnode.child = node;
                            count++;
                            return true;
                        }
                    }
                    else
                    {
                        placebnode = placebnode.child;
                        youllneverknowhatthisisusedfor--;
                    }
                    if(placebnode.child == null && i == doot.height-1)
                    {
                        Node<T> nullnode = null;
                        Node<T> node = new Node<T>(key, ranHeight(), nullnode);
                        placebnode.child = node;
                    }
                }
            }
            return false;
        }

        public bool delete (T key)
        {
            Node<T> placebnode = doot;
            int youllneverknowhatthisisusedfor = maxh();
            for (int i = 0; i < doot.height; i++)
            {
                while (placebnode.childrens[youllneverknowhatthisisusedfor] != null || placebnode.child != null)
                {
                    if (placebnode.childrens[youllneverknowhatthisisusedfor].Key.CompareTo(key) >= 0)
                    {
                        placebnode.child = placebnode.child.child;
                    }
                    else
                    {
                        placebnode = placebnode.child;
                        placebnode = placebnode.childrens[youllneverknowhatthisisusedfor];
                    }
                }
            }
            return false;
        }

        public Node<T> searchingforlosttreasurebutitsafunctionandcoded (T key)
        {
            Node<T> placebnode = doot;
            int youllneverknowhatthisisusedfor = maxh();
            for (int i = 0; i < doot.height; i++)
            {
                while (placebnode.childrens[youllneverknowhatthisisusedfor] != null || placebnode.child != null)
                {
                    if (placebnode.childrens[youllneverknowhatthisisusedfor].Key.CompareTo(key) == 0)
                    {
                        return placebnode.child;
                    }
                    else
                    {
                        placebnode = placebnode.child;
                        placebnode = placebnode.childrens[youllneverknowhatthisisusedfor];
                    }
                }
            }
            Node<T> nullnode = null;
            return nullnode;
        }
    }
}
