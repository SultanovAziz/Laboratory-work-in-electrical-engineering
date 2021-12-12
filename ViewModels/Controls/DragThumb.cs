using Laboratory_work_in_electrical_engineering.ViewModels.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Laboratory_work_in_electrical_engineering.ViewModels.Controls
{
    class DragThumb : Thumb
    {
        public DragThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(DragThumb_DragDelta);
        }

        void DragThumb_DragDelta(object sender,DragDeltaEventArgs e)
        {
            DesignerItem designerItem = this.DataContext as DesignerItem;
            DesignerCanvas designerCanvas = VisualTreeHelper.GetParent(designerItem) as DesignerCanvas;
            if (designerItem != null && designerCanvas != null && designerItem.IsSelected)
            {
                double minLeft = double.MaxValue;
                double minTop = double.MaxValue;

                //we only move DesignerItems
                var designerItems = designerCanvas.SelectionService.CurrentSelection.OfType<DesignerItem>();

                foreach (DesignerItem item in designerItems)
                {
                    double left = Canvas.GetLeft(item);
                    double top = Canvas.GetTop(item);
                    

                    minLeft = double.IsNaN(left) ? 0 : Math.Min(left, minLeft);
                    minTop = double.IsNaN(left) ? 0 : Math.Min(top, minTop);
                }

                double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
                double deltaVertical = Math.Max(-minTop, e.VerticalChange);

                foreach(DesignerItem item in designerItems)
                {
                    double left = Canvas.GetLeft(item);
                    double top = Canvas.GetTop(item);

                    if (double.IsNaN(left)) left = 0;
                    if (double.IsNaN(top)) top = 0;

                    Canvas.SetLeft(item, left + deltaHorizontal);
                    Canvas.SetTop(item, top + deltaVertical);

                }
                designerCanvas.InvalidateMeasure();
                e.Handled = true;
            }

        }
    }
}
