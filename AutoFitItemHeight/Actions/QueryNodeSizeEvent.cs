﻿using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace AutoFitContentDemo
{
    public class QueryNodeSizeEvent : Behavior<SfTreeView>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.QueryNodeSize += AssociatedObject_QueryNodeSize;
            base.OnAttached();
        }

        private void AssociatedObject_QueryNodeSize(object sender, QueryNodeSizeEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                //Returns specified item height for items.
                e.Height = 30;
                e.Handled = true;
            }
            else
            {
                // Returns item height based on the content loaded.
                e.Height = e.GetAutoFitNodeHeight();
                e.Handled = true;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.QueryNodeSize -= AssociatedObject_QueryNodeSize;
            base.OnDetaching();
        }
    }
}
