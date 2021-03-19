using System;
using System.Collections.Generic;
using System.Text;

namespace AVLT_REE
{
    class AVL<T> where T : IComparable<T>
    {
        Node<T> root = new Node<T>(default);

        public bool lorr(Node<T> node)
        {
            if(node.key.CompareTo(node.parent.key) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int height(Node<T> node)
        {
            if(node.rchild == null || node.lchild == null)
            {
                return 0;
            }
            else if(height(node.lchild) > height(node.rchild))
            {
                return height(node.lchild) - 1;    
            }
            else
            {
                return height(node.rchild) - 1;
            }
        }

        public int balance(Node<T> node)
        {
            if (node.rchild == null || node.lchild == null)
            {
                return 0;
            }
            else
            {
                return height(node.rchild) - height(node.lchild);
            }
        }

        public bool insert(T value)
        {
            Node<T> placebnode;
            placebnode = root;
           
            while(true)
            {
                if (placebnode.key.CompareTo(value) == 0)
                {
                    return false;
                }
                else
                {
                    if(value.CompareTo(placebnode.key) < 0)
                    {
                        if(placebnode.lchild == null)
                        {
                            placebnode.lchild = new Node<T>(value);
                            placebnode.lchild.parent = placebnode;
                            return true;
                        }
                        else
                        {
                            placebnode = placebnode.lchild;
                        }
                    }
                    else
                    {
                        if(placebnode.rchild == null)
                        {
                            placebnode.rchild = new Node<T>(value);
                            placebnode.rchild.parent = placebnode;
                            return true;
                        }
                    }
                }
            }
        }

        public bool delete(T value)
        {
            Node<T> placebnode;
            placebnode = root;
            while(true)
            {
                if(placebnode.key.CompareTo(value) == 0)
                {
                    if(lorr(placebnode) == false)
                    {
                        if(placebnode.rchild.lchild != null && placebnode.rchild.rchild != null)
                        {
                            Node<T> node = placebnode.rchild;
                            while (true)
                            {
                                if(node.lchild != null)
                                {
                                    node = node.lchild;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            placebnode = node;
                            node.parent.lchild = node.lchild;
                            node.lchild.parent = node.parent;
                            return true;
                        }
                    }
                    else
                    {
                        if (placebnode.lchild.rchild != null && placebnode.lchild.lchild != null)
                        {
                            Node<T> node = placebnode.lchild;
                            while (true)
                            {
                                if (node.rchild != null)
                                {
                                    node = node.rchild;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            placebnode = node;
                            node.parent.rchild = node.rchild;
                            node.rchild.parent = node.parent;
                        }
                    }
                }
                else
                {
                    if(value.CompareTo(placebnode.key) > 0 )
                    {
                        if(placebnode.rchild == null)
                        {
                            return false;
                        }
                        else
                        {
                            placebnode = placebnode.rchild;
                        }
                    }
                    else
                    {
                        if(placebnode.lchild == null)
                        {
                            return false;
                        }
                        else
                        {
                            placebnode = placebnode.lchild;
                        }
                    }
                }
            }
        }
    }
}
