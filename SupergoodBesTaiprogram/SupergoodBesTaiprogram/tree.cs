using System;
using System.Collections.Generic;
using System.Text;

namespace SupergoodBesTaiprogram
{
    class tree<T> where T : IComparable<T>
    {
        public Node<T> root;

        public int height(Node<T> node)
        {
            if (node.lchild.height < node.rchild.height)
            {
                return node.rchild.height + 1;
            }
            else
            {
                return node.lchild.height + 1;
            }
        }

        public int balances(Node<T> node)
        {
            int lh = 0;
            int rh = 0;

            if(node.lchild != null)
            {
                lh = node.lchild.height;
            }
            if(node.rchild != null)
            {
                rh = node.rchild.height;
            }

            return lh - rh;
        }

        public bool insert(T value)
        {
            Node<T> node = new Node<T>(value, null, null, null);

            if (root == null)
            {
                root = node;
                return true;
            }
            else
            {
                while (true)
                {
                    Node<T> placebnode = root;

                    if (node.value.CompareTo(placebnode.value) > 0)
                    {
                        if (placebnode.rchild == null)
                        {
                            placebnode.rchild = node;
                            node.parent = placebnode;
                            if (balances(node) > 1 || balances(node) < -1)
                            {
                                balance(node);
                            }
                            return true;
                        }
                        else
                        {
                            placebnode = placebnode.rchild;
                        }
                    }
                    else if (node.value.CompareTo(placebnode.value) < 0)
                    {
                        if (placebnode.lchild == null)
                        {
                            placebnode.lchild = node;
                            node.parent = placebnode;
                            if (balances(node) > 1 || balances(node) < -1)
                            {
                                balance(node);
                            }
                            return true;
                        }
                        else
                        {
                            placebnode = placebnode.lchild;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool delete(T Value)
        {
            while (true)
            {
                Node<T> placebnode = root;
                if (Value.CompareTo(placebnode.value) == 0)
                {
                    if (placebnode.childs(placebnode) == 0)
                    {
                        if (placebnode.value.CompareTo(placebnode.parent.value) < 0)
                        {
                            placebnode.parent.lchild = null;
                            return true;
                        }
                        else
                        {
                            placebnode.parent.rchild = null;
                            return true;
                        }
                    }
                    else if (placebnode.childs(placebnode) == 1)
                    {
                        if (placebnode.value.CompareTo(placebnode.parent.value) < 0)
                        {
                            if (placebnode.lchild.value.CompareTo(placebnode.value) < 0)
                            {
                                placebnode.parent.lchild = placebnode.lchild;                                
                            }
                            else
                            {
                                placebnode.parent.lchild = placebnode.rchild;                                
                            }
                        }
                        else
                        {
                            if (placebnode.lchild.value.CompareTo(placebnode.value) < 0)
                            {
                                placebnode.parent.rchild = placebnode.lchild;                                
                            }
                            else
                            {
                                placebnode.parent.rchild = placebnode.rchild;                                
                            }
                        }
                        if(balances(placebnode.parent) > 1 || balances(placebnode.parent) < -1)
                        {
                            balance(placebnode.parent);
                        }
                        return true;
                    }
                    else
                    {
                        Node<T> node = root;
                        if (placebnode.value.CompareTo(Value) < 0)
                        {
                            node = placebnode.rchild;
                            while (node.lchild != null)
                            {
                                node = node.lchild;
                            }
                            placebnode = node;
                            return true;
                        }
                        else
                        {
                            node = placebnode.lchild;
                            while (node.rchild != null)
                            {
                                node = node.rchild;
                            }
                            placebnode = node;
                            return true;
                        }
                    }
                }
                else
                {
                    if (Value.CompareTo(placebnode.value) < 0)
                    {
                        placebnode = placebnode.lchild;
                    }
                    else if (Value.CompareTo(placebnode.value) > 0)
                    {
                        placebnode = placebnode.rchild;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public void balance(Node<T> node)
        {
            if(balances(node) > 1)
            {
                if(node.value.CompareTo(node.parent.value) < 0)
                {
                    node.parent.lchild = node.lchild;
                }
                else
                {
                    node.parent.rchild = node.lchild;
                }
                node.parent = node.lchild;
                node = node.lchild.rchild;
            }
            else if(balances(node) < -1)
            {
                if(node.value.CompareTo(node.parent.value) < 0)
                {
                    node.parent.lchild = node.rchild;
                }
                else
                {
                    node.parent.rchild = node.rchild;
                }
                node.parent = node.rchild;
                node = node.rchild.lchild;
            }
        }

        public string PreOrder()
        {
            string output = "";

            PreOrder(root);

            return output;

            void  PreOrder(Node<T> node)
            {
                output += $"{node.value}, ";

                PreOrder(node.lchild);

                PreOrder(node.rchild);
            }
        }

        public string inOrder()
        {
            string output = "";

            inOrder(root);

            return output;

            void inOrder(Node<T> node)
            {
                inOrder(node.lchild);

                output += $"{node.value}";

                inOrder(node.rchild);
            }
        }

        public string bFirst()
        {
            Queue<Node<T>> nodes = new Queue<Node<T>>();

            nodes.Enqueue(root);

            string output = "";

            while(nodes.Count > 0)
            {
                Node<T> curr = nodes.Dequeue();
                output += curr.value;

                if (curr.lchild != null)
                {
                    nodes.Enqueue(curr.lchild);
                }
                if (curr.rchild != null)
                {
                    nodes.Enqueue(curr.rchild);
                }                
            }

            return output;
        }
    }
}
