/*
 * Namespace:       DocumentBuilderLibrary
 * File:            Director.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the director class that calls the builder
 */

using System;

namespace DocumentBuilderLibrary
{
    /**
     * Class Name:		Director
     * Purpose:			Inherits from the director interface and acts as the director to use the builder
     * Coder:			Vincent Li
     * Date:			July 17, 2021
    */
    public class Director : IDirector
    {
        // builder reference
        private IBuilder _builder;

        // data members with getters and setters
        public string key { get; set; }
        public string value { get; set; }

        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public void BuildBranch()
        {
            _builder.BuildBranch(key);
        }

        public void BuildLeaf()
        {
            _builder.BuildLeaf(key, value);
        }

        public void CloseBranch()
        {
            _builder.CloseBranch();
        }

        public void PrintDocument()
        {
            Console.WriteLine(_builder.GetDocument().Print(0));
        }
    }
}
