/*
 * Namespace:       DocumentBuilderLibrary
 * File:            IComposite.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the interface for the composites
 */

namespace DocumentBuilderLibrary
{
    public interface IComposite
    {
        /*
         * Method Name: AddChild
         * Purpose:     Adds a child node to the list of data
         * Accepts:     IComposite
         * Returns:     void
        */
        void AddChild(IComposite child);

        /*
         * Method Name: Print
         * Purpose:     Prints the data 
         * Accepts:     int
         * Returns:     void
        */
        string Print(int depth);
    }
}
