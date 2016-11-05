namespace Collection.Trees
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public Tree()
        {
            root = null;
            Count = 0;
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            this.Add(node);
        }


        private void Add(Node<T> node)
        {
            if (this.root == null)
            {
                this.root = node;
                Count++;
            }
            else
            {
                if (node.Parent == null)
                    node.Parent = root;

                bool insertLeftSide = node.Value.CompareTo(node.Parent.Value) <= 0;

                if (insertLeftSide)
                {
                    if (node.Parent.LeftChild == null)
                    {
                        node.Parent.LeftChild = node;
                        Count++;
                    }
                    else
                    {
                        node.Parent = node.Parent.LeftChild;
                        this.Add(node);
                    }
                }
                else
                {
                    if (node.Parent.RightChild == null)
                    {
                        node.Parent.RightChild = node;
                        Count++;
                    }
                    else
                    {
                        node.Parent = node.Parent.RightChild;
                        this.Add(node);
                    }
                }
            }
        }


        public bool Contains(T value)
        {
            return (this.Find(value) != null);
        }

        public bool Remove(T value)
        {
            Node<T> removeNode = Find(value);

            return this.Remove(removeNode);
        }

        private bool Remove(Node<T> removeNode)
        {
            if (removeNode == null)
                return false;

            bool wasHead = (removeNode == root);

            if (this.Count == 1)
            {
                this.root = null;

                Count--;
            }
            else if (removeNode.IsLeaf)
            {
                if (removeNode.Parent.LeftChild == removeNode)
                    removeNode.Parent.LeftChild = null;
                else
                    removeNode.Parent.RightChild = null;

                removeNode.Parent = null;

                Count--;
            }
            else if ((removeNode.LeftChild != null && removeNode.RightChild == null) || (removeNode.RightChild != null && removeNode.LeftChild == null))
            {
                if (removeNode.LeftChild != null)
                {
                    removeNode.LeftChild.Parent = removeNode.Parent;

                    if (wasHead)
                    {
                        this.root = removeNode.LeftChild;
                    }

                    if (removeNode.IsLeftChild)
                    {
                        removeNode.Parent.LeftChild = removeNode.LeftChild;
                    }
                    else
                    {
                        removeNode.Parent.RightChild = removeNode.LeftChild;
                    }
                }
                else
                {
                    removeNode.RightChild.Parent = removeNode.Parent;

                    if (wasHead)
                    {
                        this.root = removeNode.RightChild;
                    }

                    if (removeNode.IsLeftChild)
                    {
                        removeNode.Parent.LeftChild = removeNode.RightChild;
                    }
                    else
                    {
                        removeNode.Parent.RightChild = removeNode.RightChild;
                    }
                }

                removeNode.Parent = null;
                removeNode.LeftChild = null;
                removeNode.RightChild = null;

                Count--;
            }
            else
            {
                Node<T> successorNode = removeNode.LeftChild;
                while (successorNode.RightChild != null)
                {
                    successorNode = successorNode.RightChild;
                }

                removeNode.Value = successorNode.Value;

                this.Remove(successorNode);
            }


            return true;
        }

        public virtual void Clear()
        {
            this.Count = 0;
            this.root = null;
        }

        public int GetHeight()
        {
            return this.GetHeight(this.root);
        }

        private int GetHeight(Node<T> startNode)
        {
            if (startNode == null)
                return 0;
            else
                return 1 + Math.Max(GetHeight(startNode.LeftChild), GetHeight(startNode.RightChild));
        }

        public IEnumerator<T> GetInOrderEnumerator()
        {
            return new BinaryTreeInOrderEnumerator(this);
        }

        public IEnumerator<T> GetPostOrderEnumerator()
        {
            return new BinaryTreePostOrderEnumerator(this);
        }

        public IEnumerator<T> GetPreOrderEnumerator()
        {
            return new BinaryTreePreOrderEnumerator(this);
        }


        private Node<T> Find(T value)
        {
            Node<T> node = this.root;
            while (node != null)
            {
                if (node.Value.Equals(value))
                    return node;
                else
                {

                    bool searchLeft = value.CompareTo(node.Value) < 0;

                    if (searchLeft)
                        node = node.LeftChild;
                    else
                        node = node.RightChild;
                }
            }

            return null;
        }

        private class BinaryTreeInOrderEnumerator : IEnumerator<T>
        {
            private Node<T> current;
            private Tree<T> tree;
            private Queue<Node<T>> traverseQueue;

            public BinaryTreeInOrderEnumerator(Tree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<Node<T>>();
                visitNode(this.tree.root);
            }

            private void visitNode(Node<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    visitNode(node.LeftChild);
                    traverseQueue.Enqueue(node);
                    visitNode(node.RightChild);
                }
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                    current = traverseQueue.Dequeue();
                else
                    current = null;

                return (current != null);
            }
        }

        private class BinaryTreePostOrderEnumerator : IEnumerator<T>
        {
            private Node<T> current;
            private Tree<T> tree;
            private Queue<Node<T>> traverseQueue;

            public BinaryTreePostOrderEnumerator(Tree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<Node<T>>();
                visitNode(this.tree.root);
            }

            private void visitNode(Node<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    visitNode(node.LeftChild);
                    visitNode(node.RightChild);
                    traverseQueue.Enqueue(node);
                }
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                    current = traverseQueue.Dequeue();
                else
                    current = null;

                return (current != null);
            }
        }

        private class BinaryTreePreOrderEnumerator : IEnumerator<T>
        {
            private Node<T> current;
            private Tree<T> tree;
            private Queue<Node<T>> traverseQueue;

            public BinaryTreePreOrderEnumerator(Tree<T> tree)
            {
                this.tree = tree;

                traverseQueue = new Queue<Node<T>>();
                visitNode(this.tree.root);
            }

            private void visitNode(Node<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    traverseQueue.Enqueue(node);
                    visitNode(node.LeftChild);
                    visitNode(node.RightChild);
                }
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                    current = traverseQueue.Dequeue();
                else
                    current = null;

                return (current != null);
            }
        }

        private class Node<T> : IEnumerable<T>
        where T : IComparable<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node<T> LeftChild { get; set; }


            public Node<T> RightChild { get; set; }

            public Node<T> Parent { get; set; }

            public bool IsLeaf
            {
                get { return this.LeftChild == null && this.RightChild == null; }
            }

            public bool IsLeftChild
            {
                get { return this.Parent != null && this.Parent.LeftChild == this; }
            }

            public bool IsRightChild
            {
                get { return this.Parent != null && this.Parent.RightChild == this; }
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
