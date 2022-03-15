using Laboratory_work_in_electrical_engineering.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Laboratory_work_in_electrical_engineering.ViewModels.Connections
{

    //These attributes identify the types of the named parts that are used for templating
    [TemplatePart(Name = "PART_DragThumb", Type = typeof(DragThumb))]
    [TemplatePart(Name = "PART_ResizeDecorator", Type = typeof(Control))]
    [TemplatePart(Name = "PART_ConnectorDecorator", Type = typeof(Control))]
    [TemplatePart(Name = "PART_ContentPresenter", Type = typeof(ContentPresenter))]
    public class DesignerItem:ContentControl,ISelectable,IGroupable
    {
        #region ID
        private Guid id;
        public Guid ID
        {
            get { return id; }
        }
        #endregion

        #region ParentID

        public Guid ParentID
        {
            get { return (Guid)GetValue(ParentIDProperty); }
            set { SetValue(ParentIDProperty, value); }
        }
        public static readonly DependencyProperty ParentIDProperty = DependencyProperty.Register("ParentID", typeof(Guid), typeof(DesignerItem));
        #endregion

        #region IsGroup
        public bool IsGroup
        {
            get { return (bool)GetValue(IsGroupProperty);}
            set { SetValue(IsGroupProperty, value); }
        }
        public static readonly DependencyProperty IsGroupProperty =
            DependencyProperty.Register("IsGroup", typeof(bool), typeof(DesignerItem));
        #endregion

        #region IsSelected Property
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectableProperty); }
            set { SetValue(IsSelectableProperty, value); }
        }
        public static readonly DependencyProperty IsSelectableProperty =
            DependencyProperty.Register("IsSelected",
                                        typeof(bool),
                                        typeof(DesignerItem),
                                        new FrameworkPropertyMetadata(false));
        #endregion

        #region DragThumbTemplate Property

        // can be used to replace the default template for the DragThumb
        public static readonly DependencyProperty DragThumbTepmlateProperty =
            DependencyProperty.Register("DragThumbTemplate", typeof(ControlTemplate), typeof(DesignerItem));

        public static ControlTemplate GetDragThumbTemplate(UIElement element)
        {
            return (ControlTemplate)element.GetValue(DragThumbTepmlateProperty);
        }

        public static void SetDragThumbTemplate(UIElement element,ControlTemplate value)
        {
            element.SetValue(DragThumbTepmlateProperty, value);
        }

        #endregion

        #region ConnectorDecoratorTemplate Propery
        public static readonly DependencyProperty ConnectorDecoratorTemplateProperty =
            DependencyProperty.Register("ConnectorDecoratorTemplate", typeof(ControlTemplate), typeof(DesignerItem));

        public static ControlTemplate GetConnectorDecoratorTemplate(UIElement element)
        {
            return (ControlTemplate)element.GetValue(ConnectorDecoratorTemplateProperty);
        }

        public static void SetConnectorDecoratorTemplate(UIElement element,ControlTemplate value)
        {
            element.SetValue(ConnectorDecoratorTemplateProperty, value);
        }
        #endregion

        #region IsDragConnectionOver
        public bool IsDragConnectionOver
        {
            get { return (bool)GetValue(IsDragConnectionOverProperty); }
            set { SetValue(IsDragConnectionOverProperty, value); }
        }
        public static readonly DependencyProperty IsDragConnectionOverProperty =
            DependencyProperty.Register("IsDragConnetionOver",
                                        typeof(bool),
                                        typeof(DesignerItem),
                                        new FrameworkPropertyMetadata(false));

        #endregion

        public DesignerItem()
        {
            // set the key to reference the style for this control
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DesignerItem), new FrameworkPropertyMetadata(typeof(DesignerItem)));
        }
        public DesignerItem(Guid id)
        {
            this.id = id;
            this.Loaded += new RoutedEventHandler(DesignerItem_Loaded);
        }
       

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);
            DesignerCanvas designerCanvas = VisualTreeHelper.GetParent(this) as DesignerCanvas;

            //update selection element in canvas
            if (designerCanvas != null)
            {
                if ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) != ModifierKeys.None)
                {
                    if (this.IsSelected)
                    {
                        designerCanvas.SelectionService.RemoveFromSelection(this);
                    }
                    else
                    {
                        designerCanvas.SelectionService.AddToSelection(this);
                    }
                }
                else  if (!this.IsSelected)
                {
                    designerCanvas.SelectionService.SelectItem(this);
                }
                Focus();
            }
            e.Handled = false;

        }

        void DesignerItem_Loaded(object sender,RoutedEventArgs e)
        {
            if(base.Template != null)
            {
                ContentPresenter contentPresenter =
                    this.Template.FindName("PART_ContentPresenter", this) as ContentPresenter;
                if(contentPresenter != null)
                {
                    UIElement contentVisual = VisualTreeHelper.GetChild(contentPresenter, 0) as UIElement;
                    if(contentVisual != null)
                    {
                        DragThumb thumb = this.Template.FindName("PART_DragThumb", this) as DragThumb;
                        if (thumb != null)
                        {
                            ControlTemplate template =
                                DesignerItem.GetDragThumbTemplate(contentVisual) as ControlTemplate;
                            if (template != null)
                                thumb.Template = template;
                        }
                    }
                }
            }
        }
    }
}
