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
    public class BreackOfNeutralMode : IConnection
    {
        private List<DesignerItem> items = new List<DesignerItem>();
        private List<string> names = new List<string>();

        public List<int> Connect(DesignerCanvas designerCanvas)
        {
            int index = 0;
            int index2 = 0;
            List<List<string>> Neytral = ReturnConnectionWare(new List<List<string>>(), new DataConnection());
            IEnumerable<Connection> connections = designerCanvas.Children.OfType<Connection>();

            foreach (var connection in connections)
            {
                if (connection.Source == null && connection.Sink == null)
                {
                    MessageBox.Show("Возникла ошибка в программном процессе!\nСобирете схему снова", "Системная ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    foreach (Connection deleteConection in connections)
                        designerCanvas.Children.Remove(deleteConection);
                    return new List<int> { 0 };
                }
                else
                {
                    Connector source = connection.Source;
                    Connector sink = connection.Sink;
                    DesignerItem sourceItems = source.DataContext as DesignerItem;
                    DesignerItem sinkItems = sink.DataContext as DesignerItem;
                    ReturnSinkSource(sourceItems, sinkItems);
                    for (int i = 0; i < Neytral.Count; i++)
                    {
                        List<string> neytralRezhim = Neytral[i];
                        if (connection == DesignerCanvas.NeytralConnectionOf)
                            continue;
                        else
                        {
                            if (source.Name == neytralRezhim[0] && names[0] == neytralRezhim[1] && sink.Name == neytralRezhim[2] && names[1] == neytralRezhim[3])
                            {
                                if (i == 6)
                                {
                                    index2++;
                                    i++;
                                }
                                else if (i == 7)
                                    index2++;
                                else
                                {
                                    index++;
                                }

                            }
                            else if (source.Name == neytralRezhim[2] && names[0] == neytralRezhim[3] && sink.Name == neytralRezhim[0] && names[1] == neytralRezhim[1])
                            {
                                if (i == 6)
                                {
                                    index2++;
                                    i++;
                                }
                                else if (i == 7)
                                    index2++;
                                else
                                {
                                    index++;
                                }

                            }
                        }

                    }
                }
            }

            if ((index == 12 && index2 == 0) || (index == 12 && index2 == 1))
                return new List<int> { 1 };
            else
                return new List<int> { 0 };
        }

        public List<List<string>> ReturnConnectionWare(List<List<string>> BreackOfNeutral, DataConnection dataConnection)
        {
            BreackOfNeutral.Clear();
            BreackOfNeutral.Add(dataConnection.AAOLA);
            BreackOfNeutral.Add(dataConnection.AAWA);
            BreackOfNeutral.Add(dataConnection.ABOLB);
            BreackOfNeutral.Add(dataConnection.ABWB);
            BreackOfNeutral.Add(dataConnection.ACOLC);
            BreackOfNeutral.Add(dataConnection.ACWC);
            BreackOfNeutral.Add(dataConnection.ANOLY);
            BreackOfNeutral.Add(dataConnection.ANVkl0);
            BreackOfNeutral.Add(dataConnection.WAVkl0);
            BreackOfNeutral.Add(dataConnection.WAVklA);
            BreackOfNeutral.Add(dataConnection.WBVkl0);
            BreackOfNeutral.Add(dataConnection.WBVklB);
            BreackOfNeutral.Add(dataConnection.WCVkl0);
            BreackOfNeutral.Add(dataConnection.WCVklC);
            return BreackOfNeutral;
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
