using Laboratory_work_in_electrical_engineering.ViewModels.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratory_work_in_electrical_engineering.Views.User_Control.Amber
{
    /// <summary>
    /// Логика взаимодействия для Amber.xaml
    /// </summary>
    public partial class Amber : UserControl
    {
        public Amber()
        {
            InitializeComponent();
            if (DesignerCanvas.RemoveApmermetrDelete.Count == 0)
            {
                this.txt2.Text = DesignerCanvas.listsApmermetr[DesignerCanvas.countApmermetr].ToString();
                this.Name = "АмперметР" + txt2.Text;

            }
            else
            {

                DesignerCanvas.listsApmermetr.Add(DesignerCanvas.RemoveApmermetrDelete[0]);
                DesignerCanvas.listsApmermetr.Sort();
                this.txt2.Text = DesignerCanvas.RemoveApmermetrDelete[0].ToString();
                this.Name = "АмперметР" + txt2.Text;
                DesignerCanvas.RemoveApmermetrDelete.RemoveAt(0);

            }
        }

        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _mouseLocationWithinMe = e.GetPosition(this);

            CaptureMouse();
        }

        private void Control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            this.ReleaseMouseCapture();
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var mouseWithinParent = e.GetPosition(Parent as UIElement);

                Canvas.SetLeft(this, mouseWithinParent.X - _mouseLocationWithinMe.X);
                Canvas.SetTop(this, mouseWithinParent.Y - _mouseLocationWithinMe.Y);
            }
        }

        protected bool _isDragging;
        Point _mouseLocationWithinMe;

    }
}
