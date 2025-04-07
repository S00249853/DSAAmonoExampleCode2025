using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    public class Tree
    {
        public TreeNode root;

        public TreeNode Insert(TreeNode toPlace, int val)
        {
            if (toPlace == null)
            {
                // create new treenode with passed value
                toPlace = new TreeNode();
                toPlace.Val = val;

                // if there are no nodes in the tree yet
                if (root == null) root = toPlace;
                return toPlace;
            }

            else if (val <= toPlace.Val)
                toPlace.left = Insert(toPlace.left, val);
            else
                toPlace.right = Insert(toPlace.right, val);
            return toPlace;
        }
        // pass in the node to start searching from, likely the root
        // check that node and its children
        // if its none of those do a recursive search down the rest of the tree
        // use similiar logic to the insert method to search more efficiently
        // so before calling Find again check if the value is less than the right node
        public TreeNode Find(TreeNode current, int val)
        {
            if (current.Val == val)
                return current;
            else
            {
                if (current.left != null && val < current.Val) // search left side
                {
                    return Find(current.left, val);
                }
                else if(current.right != null && val > current.Val)// search right side
                {
                    return Find(current.right, val);
                }
            }
            return null;
        }
        // NOTE Parent of root is null to begin
        public TreeNode FindParentOf(TreeNode parent, TreeNode current, int val)
        {
            if (current != null && current.Val == val) 
                return parent;

            else if(current != null && current.Val!= val)
            {
                if (val < current.Val) // search left
                    return FindParentOf(current, current.left, val);

                else if (val > current.Val) // search right
                    return FindParentOf(current, current.right, val);
            }
            return null; // not found
        }
        public void Delete(TreeNode parent, TreeNode current)
        {
            // Case 1: if current has no right child,
            // then current's left child becomes the node pointed to by the parent
            if(current.right == null)
            {
                if (parent == null)
                    root = current.left;
                else
                {
                    if (parent.Val > current.Val)
                        parent.left = current.left;

                    else if (parent.Val < current.Val)
                        parent.right = current.left;
                }
            }

            // Case 2: if current's right child has no left child,
            // then current's right child replaces current in the tree
            else if(current.right.left == null)
            {
                current.right.left = current.left;
                if (parent == null)
                    root = current.right;
                else
                {
                    if (parent.Val > current.Val)
                        parent.left = current.right;

                    else if (parent.Val < current.Val)
                        parent.right = current.right;
                }
            }

            // Case 3: if current's right child has a left child,
            // replace current with current's right child's left-most descendent
            else
            {
                TreeNode pivot = current.right.left, lmParent = current.right;
                // move down the left side until reaching a leaf node
                while (pivot.left != null)
                {
                    lmParent = pivot;
                    pivot = pivot.left;
                }

                lmParent.left = pivot.right;
                pivot.left = current.left;
                pivot.right = current.right;

                if (parent == null)
                    root = pivot;
                else
                {
                    if (parent.Val > current.Val)
                        parent.left = pivot;

                    else if (parent.Val < current.Val)
                        parent.right = pivot;
                }
            }
        }
        public void TreePrint(TreeNode node)
        {
            if (node != null)   
                TreePrint(node.left);

            if (node != null)
                System.Console.WriteLine("{0}", node.Val);

            if (node != null)
                TreePrint(node.right);
        }
    }
}
