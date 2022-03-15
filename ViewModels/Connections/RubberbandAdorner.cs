using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Laboratory_work_in_electrical_engineering.ViewModels.Connections
{
   public class RubberbandAdorner : Adorner
    {
        private Point? startPoint;
        private Point? endPoint;
        private Pen rubberbandPen;

        private DesignerCanvas designerCanvas;

        public RubberbandAdorner(DesignerCanvas designerCanvas, Point? dragStartPoint)
         : base(designerCanvas)
        {
            this.designerCanvas = designerCanvas;
            this.startPoint = dragStartPoint;
            rubberbandPen = new Pen(Brushes.Red, 1);
            rubberbandPen.DashStyle = new DashStyle(new double[] { 2 }, 1);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!this.IsMouseCaptured)
                    this.CaptureMouse();

                endPoint = e.GetPosition(this);
                UpdateSelection();
                this.InvalidateVisual();
                
            }
            else
            {
                if (this.IsMouseCaptured) this.ReleaseMouseCapture();
            }
            e.Handled = true;
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            //удаление текушего adorner
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.designerCanvas);
            if (adornerLayer != null)
                adornerLayer.Remove(this);

            e.Handled = true;

        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            //когда не нам не известны координат т.е не нажата кнопка 
            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));

            if (this.startPoint.HasValue && this.endPoint.HasValue)
                drawingContext.DrawRectangle(Brushes.Transparent, rubberbandPen, new Rect(this.startPoint.Value, this.endPoint.Value));

        }

        private void UpdateSelection()
        {
            this.designerCanvas.SelectionService.ClearSelection();

            Rect rubberBand = new Rect(this.startPoint.Value, this.endPoint.Value);
            foreach(Control item in designerCanvas.Children)
            {
                Rect itemRect = VisualTreeHelper.GetDescendantBounds(item);
                Rect itemBounds = item.TransformToAncestor(designerCanvas).TransformBounds(itemRect);

                if (rubberBand.Contains(itemBounds))
                {
                    if (item is Connection)
                        this.designerCanvas.SelectionService.AddToSelection(item as ISelectable);
                    else
                    {

                        DesignerItem di = item as DesignerItem;
                        if (di.ParentID == Guid.Empty)
                            designerCanvas.SelectionService.AddToSelection(di);
                    }
                }
            }

        }

    }
}
