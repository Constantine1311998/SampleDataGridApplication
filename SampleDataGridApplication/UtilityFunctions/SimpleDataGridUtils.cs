using System.Windows;
using System.Windows.Media;

namespace SampleDataGridApplication.UtilityFunctions
{
    public static class SimpleDataGridUtils
    {
        /// <summary>
        /// Finds the parent object of child object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="child"></param>
        /// <returns>Returns the specified generic dependency object if found otherwise null is returned</returns>
        public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            if (parentObject is T parent)
                return parent;

            return FindVisualParent<T>(parentObject);
        }

        /// <summary>
        /// Finds the mentioned child of the  parent object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns>Returns the child object else null is returned</returns>
        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            var depobj = VisualTreeHelper.GetParent(parent);
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T result)
                {
                    return result;
                }
                else
                {
                    T descendant = FindVisualChild<T>(child);
                    if (descendant != null)
                    {
                        return descendant;
                    }
                }
            }
            return null;
        }
    }
}