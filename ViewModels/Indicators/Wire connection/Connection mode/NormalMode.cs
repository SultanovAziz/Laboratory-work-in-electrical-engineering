using Laboratory_work_in_electrical_engineering.ViewModels.Connections;
using Laboratory_work_in_electrical_engineering.ViewModels.Indicators.Wire_connection.Data_connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratory_work_in_electrical_engineering.ViewModels.Indicators.Wire_connection.Connection_mode
{
    public class NormalMode : IConnection
    {
        private List<DesignerItem> items = new List<DesignerItem>();
        private List<string> names = new List<string>();
         

        public List<int> Connect(DesignerCanvas designerCanvas)
        {
            List<List<string>> Normal = ReturnConnectionWare(new List<List<string>>(), new DataConnection());
            List<int> True = new List<int> { 1 };
            List<int> False = new List<int> { 0 };
            int index = 0;
            IEnumerable<Connection> connections = designerCanvas.Children.OfType<Connection>();
            for (int j = 0; j < Normal.Count(); j++)
            {
                List<string> normalRezhim = Normal[j];
                foreach (Connection connection in connections)
                {
                    if (connection.Source == null || connection.Sink == null)
                    {
                        MessageBox.Show("Возникла ошибка в программном процессе!\nСобирете схему снова", "Системная ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        foreach (Connection deleteConection in connections)
                            designerCanvas.Children.Remove(deleteConection);
                        return False;
                    }
                    else
                    {
                        Connector source = connection.Source;
                        Connector sink = connection.Sink;
                        DesignerItem sourceItems = source.DataContext as DesignerItem;
                        DesignerItem sinkItems = sink.DataContext as DesignerItem;
                        ReturnSinkSource(sourceItems, sinkItems);

                        if (source.Name == normalRezhim[0] && names[0] == normalRezhim[1] && sink.Name == normalRezhim[2] && names[1] == normalRezhim[3])
                        {
                            index++;


                        }
                        else if (source.Name == normalRezhim[2] && names[0] == normalRezhim[3] && sink.Name == normalRezhim[0] && names[1] == normalRezhim[1])
                        {
                            index++;

                        }

                    }
                }
            }
            if (index == connections.Count())
            {
                return True;
            }
            else
            {
                return False;
            }
        }

        public List<List<string>> ReturnConnectionWare(List<List<string>> Normal, DataConnection dataConnection)
        {
            Normal.Clear();
            Normal.Add(dataConnection.AAOLA);
            Normal.Add(dataConnection.AAWA);
            Normal.Add(dataConnection.ABOLB);
            Normal.Add(dataConnection.ABWB);
            Normal.Add(dataConnection.ACOLC);
            Normal.Add(dataConnection.ACWC);
            Normal.Add(dataConnection.ANOLY);
            Normal.Add(dataConnection.ANVkl0);
            Normal.Add(dataConnection.WAVkl0);
            Normal.Add(dataConnection.WAVklA);
            Normal.Add(dataConnection.WBVkl0);
            Normal.Add(dataConnection.WBVklB);
            Normal.Add(dataConnection.WCVkl0);
            Normal.Add(dataConnection.WCVklC);
            return Normal;
        }

        public void ReturnSinkSource(DesignerItem sourceItems, DesignerItem sinkItems)
        {
            names.Clear();
            items.Clear();
            items.Add(sourceItems);
            items.Add(sinkItems);
            //for (int i = 0; i < items.Count; i++)
            //{
            //    if (items[i].Content is Amber)
            //    {
            //        Amber oneItem = items[i].Content as Amber;
            //        names.Add(oneItem.Name);
            //    }
            //    else if (items[i].Content is Volt)
            //    {
            //        Volt oneItem = items[i].Content as Volt;
            //        names.Add(oneItem.Name);
            //    }
            //    else if (items[i].Content is Vkluchatel)
            //    {
            //        Vkluchatel oneItem = items[i].Content as Vkluchatel;
            //        names.Add(oneItem.Name);
            //    }
            //    else if (items[i].Content is Oknolampochek)
            //    {
            //        Oknolampochek oneItem = items[i].Content as Oknolampochek;
            //        names.Add(oneItem.Name);
            //    }
            //}
        }

        
    }
}
