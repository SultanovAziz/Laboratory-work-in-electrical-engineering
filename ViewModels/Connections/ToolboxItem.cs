using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Laboratory_work_in_electrical_engineering.ViewModels.Connections
{
   public  class ToolboxItem : ContentControl
    {

        private Point? dragStartPoint = null;

        static ToolboxItem()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
                 typeof(ToolboxItem), new FrameworkPropertyMetadata(typeof(ToolboxItem)));
        }
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);
            this.dragStartPoint = new Point?(e.GetPosition(this));
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton != MouseButtonState.Pressed)
                this.dragStartPoint = null;
            if (this.dragStartPoint.HasValue)
            {
                string xamlString = XamlWriter.Save(this.Content);
                DragObject dataObject = new DragObject();
                dataObject.Xaml = xamlString;
                WrapPanel panel = VisualTreeHelper.GetParent(this) as WrapPanel;
                if(panel != null)
                {
                    double scale = 1.3;
                    dataObject.DesiredSize = new Size(panel.ItemWidth * scale, panel.ItemHeight * scale);
                }
                DragDrop.DoDragDrop(this, dataObject, DragDropEffects.Copy);

                e.Handled = true;
            }
        }
    }

    public class DragObject
    {
        // Xaml string that represents the serialized content
        public string Xaml { get; set; }

        // Defines width and height of the DesignerItem
        // when this DragObject is dropped on the DesignerCanvas
        public Size? DesiredSize { get; set; }
    }
}
