/*
 * Namespace:       DocumentBuilderLibrary
 * File:            JSONBranch.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the branch to build the JSON doc
 */

using System.Collections.Generic;
using System.Linq;

namespace DocumentBuilderLibrary
{
    /**
     * Class Name:		JSONBranch
     * Purpose:			Inherits from IComposite and is called from the builder when a new branch needs to be made
     * Coder:			Vincent Li
     * Date:			July 17, 2021
    */
    public class JSONBranch : IComposite
    {
        // data members
        private List<IComposite> _childList;
        private string _key;

        // constructor
        public JSONBranch(string key)
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
            string data = "";

            // check if it is the root
            if (_key == "root")
            {
                data += "{\n";

                // print the children
                foreach (IComposite child in _childList)
                {
                    data += $"{child.Print(depth + 1)}" + (child == _childList[_childList.Count() - 1] ? "\n" : ",\n");
                }
                // add closing bracket
                data += $"{spacing}}}";
            }
            else
            {
                // print the branch
                data += $"{spacing}'{_key}' : \n {spacing}{{\n";

                // print the children
                foreach (IComposite child in _childList)
                {
                    data += $"{child.Print(depth + 1)}" + (child == _childList[_childList.Count() - 1] ? "\n" : ",\n");
                }

                data += $" {spacing}}}";
            }
            return data;
        }
    }
}
