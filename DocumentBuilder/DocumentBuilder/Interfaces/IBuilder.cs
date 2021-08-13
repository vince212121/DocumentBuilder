/*
 * Namespace:       DocumentBuilderLibrary
 * File:            IBuilder.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the interface for builder
 */

namespace DocumentBuilderLibrary
{
    public interface IBuilder
    {
        /*
         * Method Name: BuildBranch
         * Purpose:     Builds the branch for the doc
         * Accepts:     string
         * Returns:     void
        */
        void BuildBranch(string name);

        /*
         * Method Name: BuildLeaf
         * Purpose:     Builds the leaf for the doc
         * Accepts:     string, string
         * Returns:     void
        */
        void BuildLeaf(string name, string content);

        /*
         * Method Name: CloseBranch
         * Purpose:     Closes the branch
         * Accepts:     nothing
         * Returns:     void
        */
        void CloseBranch();

        /*
         * Method Name: GetDocument
         * Purpose:     returns root node
         * Accepts:     nothing
         * Returns:     IComposite
        */
        IComposite GetDocument();
    }
}
