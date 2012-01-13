using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParsingBLSData.Model
{
    public class BLSValue
    {
        public BLSValue() { }
        public BLSValue(string seriesName, string seriesID, string year, string month, string value)
        {
            SeriesName = seriesName;
            SeriesID = seriesID;
            try
            {
                int yearVal = Convert.ToInt32(year);
                int monthVal = Convert.ToInt32(month.Remove(0, 1));
                if (monthVal == 13){
                    IsAnualData = true;
                }
                else
                {
                    ValueDate = new DateTime(yearVal, monthVal, 1);
                    Value = Convert.ToDouble(value.Replace("(P)", "").Replace("(1)", ""));
                    IsAnualData = false;
                }

            } catch {}
        }

        public string SeriesName { get; set; }
        public string SeriesID { get; set; }
        public DateTime ValueDate { get; set; }
        public double Value { get; set; }
        public bool IsAnualData { get; set; }
    }
}
