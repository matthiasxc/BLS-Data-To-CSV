using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParsingBLSData.Model
{
    public class MetroDataPoint
    {
        public MetroDataPoint() { }

        public MetroDataPoint( string lCode, string sfCode, 
                                string afCode, string area,
                                string year, string month,
                                string laborForce, string employment,
                                string unemployment, string unemployRate) 
        {
            LAUSCode = lCode.Trim();
            StateFipsCode = sfCode.Trim();
            AreaFipsCode = afCode.Trim();
            Area = area.Replace(" MSA", "").Trim().Replace(',', ' ');
            Year = Convert.ToInt32(year.Trim());
            Month = Convert.ToInt32(month.Trim());
            DateOfData = new DateTime(Year, Month, 1);
            CivilianLaborForce = Convert.ToDouble(laborForce.Trim());
            Employment = Convert.ToDouble(employment.Trim());
            Unemployment = Convert.ToDouble(unemployment.Trim());
            UnempoymentRate = Convert.ToDouble(unemployRate.Trim());        
        }

        public string LAUSCode { get; set; }
        public string StateFipsCode { get; set; }
        public string AreaFipsCode { get; set; }
        public string Area { get; set; }
        public int Year {get; set;}
        public int Month { get; set; }
        public DateTime DateOfData { get; set; }
        public double CivilianLaborForce { get; set; }
        public double Employment { get; set; }
        public double Unemployment { get; set; }
        public double UnempoymentRate { get; set; }
    }
}
