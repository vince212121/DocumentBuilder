/*
 * Namespace:       DocumentBuilderLibrary
 * File:            IDirector.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the interface for the director
 */

namespace DocumentBuilderLibrary
{
    public interface IDirector
    {
        void BuildBranch();
        void BuildLeaf();
        void CloseBranch();
    }
}
