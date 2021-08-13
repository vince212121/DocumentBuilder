/*
 * Namespace:       DocumentBuilderLibrary
 * File:            XMLBuilder.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the XML Builder for the XML doc
 */

using System.Collections.Generic;

namespace DocumentBuilderLibrary
{
    /**
     * Class Name:		XMLBuilder
     * Purpose:			Inherits from IBuilder and is called from the director when a XML doc is being made
     * Coder:			Vincent Li
     * Date:			July 17, 2021
    */
    public class XMLBuilder : IBuilder
    {
        // data members
        private Stack<IComposite> _composites;
        private XMLBranch root;

        // constructor
        public XMLBuilder()
        {
            _composites = new Stack<IComposite>();
            root = new XMLBranch("root");
            _composites.Push(root);
        }

        /*
         * Method Name: BuildBranch
         * Purpose:     Builds the branch for the doc
         * Accepts:     string
         * Returns:     void
        */
        public void BuildBranch(string name)
        {
            XMLBranch branch = new XMLBranch(name);
            // adding child branch/adding the branch to the most recent set to maintain a reference
            _composites.Peek().AddChild(branch);
            // make the new branch the new set to add to 
            _composites.Push(branch);
        }

        /*
         * Method Name: BuildLeaf
         * Purpose:     Builds the leaf for the doc
         * Accepts:     string, string
         * Returns:     void
        */
        public void BuildLeaf(string name, string content)
        {
            // build a new leaf then add it to the most recent set
            XMLLeaf leaf = new XMLLeaf(name, content);
            _composites.Peek().AddChild(leaf); // add leaf 
        }

        /*
         * Method Name: CloseBranch
         * Purpose:     Closes the branch
         * Accepts:     nothing
         * Returns:     void
        */
        public void CloseBranch()
        {
            // go back a step if it isn't the root
            // if it is the root, you can't go back to a previous set
            if (_composites.Peek() != root)
            {
                _composites.Pop();
            }
        }

        /*
         * Method Name: GetDocument
         * Purpose:     returns root node
         * Accepts:     nothing
         * Returns:     IComposite
        */
        public IComposite GetDocument()
        {
            return root;
        }
    }
}
