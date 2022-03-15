using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_in_electrical_engineering.ViewModels.Indicators.Wire_connection.Data_connection
{
   public class DataConnection
    {
        #region Амперметр A
        public List<string> AAOLA = new List<string>{
                "Разъём2",
                "АмперметРA",
                "РазъёмA",
                "Окнолампочек"
            };
        public List<string> AAWA = new List<string>{
                "Разъём1",
                "АмперметРA",
                "Разъём4",
                "ВатметРA"
            };
        #endregion
        #region Амперметр B
        public List<string> ABOLB = new List<string>{
                "Разъём2",
                "АмперметРB",
                "РазъёмB",
                "Окнолампочек"
            };
        public List<string> ABWB = new List<string>{
                "Разъём1",
                "АмперметРB",
                "Разъём4",
                "ВатметРB"
            };
        #endregion
        #region Амперметр C
        public List<string> ACOLC = new List<string>{
                "Разъём2",
                "АмперметРC",
                "РазъёмC",
                "Окнолампочек"
            };
        public List<string> ACWC = new List<string>{
                "Разъём1",
                "АмперметРC",
                "Разъём4",
                "ВатметРC"
            };

        #endregion
        #region Амперметр N
        public List<string> ANOLY = new List<string>{
                "Разъём2",
                "АмперметРN",
                "РазъёмN",
                "Окнолампочек"
            };
        public List<string> ANVkl0 = new List<string>{
                "Разъём1",
                "АмперметРN",
                "Разъём0",
                "Включатель"
            };
        #endregion
        #region Волтметр A
        public List<string> WAVklA = new List<string>{
                "Разъём1",
                "ВатметРA",
                "РазъёмA",
                "Включатель"
            };
        public List<string> WAVkl0 = new List<string>{
                "Разъём2",
                "ВатметРA",
                "Разъём0",
                "Включатель"
            };
        #endregion
        #region Волтметр B
        public List<string> WBVklB = new List<string>{
                "Разъём1",
                "ВатметРB",
                "РазъёмB",
                "Включатель"
            };
        public List<string> WBVkl0 = new List<string>{
                "Разъём2",
                "ВатметРB",
                "Разъём0",
                "Включатель"
            };
        #endregion
        #region Волтметр C
        public List<string> WCVklC = new List<string>{
                "Разъём1",
                "ВатметРC",
                "РазъёмC",
                "Включатель"
            };
        public List<string> WCVkl0 = new List<string>{
                "Разъём2",
                "ВатметРC",
                "Разъём0",
                "Включатель"
            };
        #endregion

    }
}
