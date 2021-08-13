/*
 * Namespace:       DocumentBuilderLibrary
 * File:            JSONLeaf.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the leaf class for the JSON doc
 */

using System.Linq;


namespace DocumentBuilderLibrary
{
    /**
     * Class Name:		JSONLeaf
     * Purpose:			Inherits from IComposite and is called from the builder when a new leaf needs to be made
     * Coder:			Vincent Li
     * Date:			July 17, 2021
    */
    public class JSONLeaf : IComposite
    {
        // data members
        private string _key;
        private string _value;

        // constructor
        public JSONLeaf(string key, string value)
        {
            _key = key;
            _value = value;
        }

        /*
         * Method Name: AddChild
         * Purpose:     Not used because leaves do not have children
         * Accepts:     IComposite
         * Returns:     void
        */
        public void AddChild(IComposite child)
        {
            // Leaves do not have children
        }

        /*
         * Method Name: Print
         * Purpose:     Prints the leaf
         * Accepts:     int
         * Returns:     void
        */
        public string Print(int depth)
        {
            string spacing = string.Concat(Enumerable.Repeat(' ', depth*4));
            return $"{spacing}'{_key}' : '{_value}'";
        }
    }
}
