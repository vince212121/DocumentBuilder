/*
 * Namespace:       DocumentBuilderLibrary
 * File:            XMLBranch.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the branch used for building the XML doc
 */

using System.Collections.Generic;
using System.Linq;

namespace DocumentBuilderLibrary
{
    /**
     * Class Name:		XMLBranch
     * Purpose:			Inherits from IComposite and is called from the builder when a new branch needs to be made
     * Coder:			Vincent Li
     * Date:			July 17, 2021
    */
    public class XMLBranch : IComposite
    {
        // data members
        private List<IComposite> _childList;
        private string _key;

        // constructor
        public XMLBranch (string key)
        {
            _key = key;
            _childList = new List<IComposite>();
        }

        /*
         * Method Name: AddChild
         * Purpose:     Adds a child node to the list of data
         * Accepts:     IComposite
         * Returns:     void
        */
        public void AddChild(IComposite child)
        {
            _childList.Add(child);
        }

        /*
         * Method Name: Print
         * Purpose:     Prints the branch and leaves
         * Accepts:     int
         * Returns:     void
        */
        public string Print(int depth)
        {
            string spacing = string.Concat(Enumerable.Repeat(' ', depth * 4));
            string data = $"{spacing}<{_key}>\n";

            foreach (IComposite child in _childList)
            {
                data += $"{child.Print(depth + 1)}\n";
            }

            data += $"{spacing}</{_key}>";

            return data;
        }
    }
}
