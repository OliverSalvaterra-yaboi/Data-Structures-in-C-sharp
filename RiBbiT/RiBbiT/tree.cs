using System;
using System.Collections.Generic;
using System.Text;

namespace RiBbiT
{
    class tree<T> where T: IComparable<T>
    {
        public Node<T> root = new Node<T>(default);

        public void colorflip (Node<T> node)
        {
            if (node.color)
            {
                node.color = false;
                if (node.lchild != null)
                {
                    node.lchild.color = true;
                }
                else if (node.rchild != null)
                {
                    node.rchild.color = true;
                }
            }
            else
            {
                node.color = true;
                if (node.lchild != null)
                {
                    node.lchild.color = false;
                }
                else if (node.rchild != null)
                {
                    node.rchild.color = false;
                }
            }
        }

        public void insert(T val)
        {
            Node<T> placebnode = root;

            while(true)
            {
                if(placebnode.lchild.color && placebnode.rchild.color)
                {
                    colorflip(placebnode);
                }

                if(val.CompareTo(placebnode.val) == -1)
                {
                    if(placebnode.lchild == null)
                    {
                        Node<T> node = new Node<T>(val);
                        node.parent = placebnode;
                        node.color = !placebnode.color;
                        break;
                    }
                    placebnode = placebnode.lchild;
                }
                else
                {
                    if(placebnode.rchild == null)
                    {
                        Node<T> node = new Node<T>(val);
                        node.parent = placebnode;
                        node.color = !placebnode.color;
                        break;
                    }
                    placebnode = placebnode.rchild;
                }
            }

            while(true)
            {
                if(placebnode.rchild.color)
                {
                    placebnode.color = !placebnode.color;
                    placebnode.rchild.color = !placebnode.rchild.color;

                    placebnode.rchild.parent = placebnode.parent;
                    placebnode.rchild.lchild = placebnode;
                    placebnode.parent = placebnode;
                }

                placebnode = placebnode.parent;

                if(placebnode.parent == null)
                {
                    break;
                }
            }
            fixup();
        }

        public void rotate(Node<T> node)
        {
            if(node.lchild == null || node.rchild == null)
            {
                if (node.val.CompareTo(node.parent.val) < 0)
                {
                    node.color = node.parent.color;
                    node.parent.color = !node.color;
                    node.parent = node.rchild;
                    node.parent.parent = node;
                }
                else if(node.val.CompareTo(node.parent.val) > 0)
                {
                    node.color = node.parent.color;
                    node.parent.color = !node.color;
                    node.parent = node.lchild;
                    node.parent.parent = node;
                }
            }
            else
            {
                if(node.val.CompareTo(node.parent.val) < 0)
                {
                    node.color = node.parent.color;
                    node.parent.color = !node.color;
                    node.parent.lchild = node.rchild;
                    node.parent = node;
                    node.rchild = node.parent;
                }
                else
                {
                    node.color = node.parent.color;
                    node.parent.color = !node.color;
                    node.parent.rchild = node.lchild;
                    node.parent = node;
                    node.lchild = node.parent;
                }
            }
            fixup();
        }

        public void delete(T val)
        {
            Node<T> placebnode = root;
            while(true)
            {
                if(placebnode.val.CompareTo(val) == 0)
                {
                    while(placebnode.rchild != null && placebnode.lchild != null)
                    {
                        rotate(placebnode);
                    }
                    if(placebnode.val.CompareTo(placebnode.parent.val) > 0)
                    {
                        placebnode.parent.rchild = null;
                        break;
                    }
                    else 
                    {
                        placebnode.parent.lchild = null;
                        break;
                    }
                }

                if(placebnode.val.CompareTo(val) > 0)
                {
                    placebnode = placebnode.rchild;
                }
                else
                {
                    placebnode = placebnode.lchild;
                }
            }
            fixup();
        }

        public bool moveredleft(Node<T> node)
        {
            if(node.lchild != null || node.rchild != null)
            {
                return false;
            }
            else
            {
                colorflip(node);

                fixup();

                return true;
            }
        }

        public bool moveredright(Node<T> node)
        {
            if(node.lchild != null || node.rchild != null)
            {
                return false;
            }
            else
            {
                colorflip(node);

                rotate(node);

                fixup();

                return true;
            }
        }

        public void fixup()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            Node<T> placebnode;

            while(queue.Count != 0)
            {
                for(int i = 0; i < queue.Count; i++)
                {
                    placebnode = queue.Peek();

                    //fixup stuff
                    if(placebnode.val.CompareTo(placebnode.parent.val) > 0 && placebnode.color == true)
                    {
                        rotate(placebnode);
                    }

                    if(placebnode.color == false && placebnode.lchild != null && placebnode.rchild != null)
                    {
                        colorflip(placebnode);
                    }

                    if(placebnode.color == placebnode.lchild.color || placebnode.rchild.color == placebnode.color)
                    {
                        colorflip(placebnode);
                    }

                    if(placebnode.lchild != null)
                    {
                        queue.Enqueue(placebnode.lchild);
                    }
                    if(placebnode.rchild != null)
                    {
                        queue.Enqueue(placebnode.rchild);
                    }
                }
            }
        }
    }
}
