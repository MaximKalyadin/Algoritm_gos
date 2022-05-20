using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tree<T> where T : IComparable<T>
    {
        private Tree<T> parent, left, right;
        private T value;
        private List<T> result = new List<T>();

        public Tree(T value, Tree<T> parent) 
        {
            this.parent = parent;
            this.value = value;
        }

        public void Add(T value)
        {
            if (value.CompareTo(this.value) < 0)
            {
                if (this.left == null)
                {
                    this.left = new Tree<T>(value, this);
                }
                else
                {
                    this.left.Add(value);
                }
            } 
            else
            {
                if (this.right == null)
                {
                    this.right = new Tree<T>(value, this);
                } 
                else
                {
                    this.right.Add(value);
                }
            }
        }

        private Tree<T> _search(Tree<T> tree, T value)
        {
            if (tree == null) return null;
            switch(value.CompareTo(this.value))
            {
                case 1: return _search(tree.right, value);
                case -1: return _search(tree.left, value);
                case 0: return tree;
                default: return null;
            }
        }

        public Tree<T> serch(T value)
        {
            return _search(this, value);
        }

        public bool remove(T value)
        {
            Tree<T> tree = serch(value);
            if (tree == null)
            {
                return false;
            }


            Tree<T> currentTree;
            
            if (tree == this)
            {
                if (tree.right != null)
                {
                    currentTree = tree.right;
                } 
                else
                {
                    currentTree = tree.left;
                }

                while (currentTree.left != null)
                {
                    currentTree = currentTree.left;
                }
                this.remove(currentTree.value);
                tree.value = currentTree.value;
                return true;
            }

            if (tree.left == null && tree.right == null && tree.parent != null)
            {
                if (tree == tree.parent.left)
                {
                    tree.parent.left = null;
                }
                else
                {
                    tree.parent.right = null;
                }
            }


            if (tree.left != null && tree.right == null)
            {
                tree.parent.left = tree.parent;
                if (tree.parent.left == tree)
                {
                    tree.parent.left = tree.left;
                }
                else
                {
                    tree.parent.right = tree.left;
                }
                return true;
            }

            if (tree.left == null && tree.left != null)
            {
                tree.parent.right = tree.parent;
                if (tree.parent.left == tree)
                {
                    tree.parent.left = tree.right;
                }
                else
                {
                    tree.parent.left = tree.right;
                }
                return true;
            }

            if (tree.left != null && tree.right != null)
            {
                currentTree = tree.right;
                while (currentTree.left != null)
                {
                    currentTree = currentTree.left;
                }

                if (currentTree.parent == tree)
                {
                    currentTree.left = tree.left;
                    tree.left.parent = currentTree;
                    currentTree.parent = tree.parent;
                    if (tree == tree.parent.right)
                    {
                        tree.parent.left = currentTree;
                    }
                    else
                    {
                        tree.parent.right = currentTree;
                    }
                    return true;
                } 
                else
                {
                    if (currentTree.right != null)
                    {
                        currentTree.right.parent = currentTree.parent;
                    }

                    currentTree.parent.left = currentTree.left;
                    currentTree.right = tree.right;
                    currentTree.left = tree.left;
                    tree.left.parent = currentTree;
                    tree.right.parent = currentTree;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = currentTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = currentTree;
                    }
                    return true;
                }
            }

            return false;
        }

        public void print()
        {
            result.Clear();
            _print(this);
            Console.WriteLine();
        }

        private void _print(Tree<T> tree)
        {
            if (tree == null) return;
            _print(tree.left);
            result.Add(tree.value);
            Console.WriteLine(tree.value + " ");

            if (tree.right != null)
            {
                _print(tree.right);
            }
        }
    }
}
