using Laboratory_work_in_electrical_engineering.ViewModels.Connection;
using Laboratory_work_in_electrical_engineering.ViewModels.Connections;
using Laboratory_work_in_electrical_engineering.ViewModels.Indicators.Wire_connection.Data_connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_in_electrical_engineering.ViewModels.Indicators.Wire_connection.Connection_mode
{
  public interface IConnection
    {
        List<int> Connect(DesignerCanvas designerCanvas);

        void ReturnSinkSource(DesignerItem sourceItems, DesignerItem sinkItems);

        List<List<string>> ReturnConnectionWare(List<List<string>> Mode, DataConnection dataConnection);

    }
}
