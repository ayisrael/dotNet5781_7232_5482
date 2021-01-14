﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class AdjacentStations//זוג תחנות עוקבות
    {
        public int StationCode1 { get; set; }// קוד תחנה ראשונה
        public int StationCode2 { get; set; }//קוד תחנה שנייה
        public double Distance { get; set; }// מרחק בין שתי התחנות
        public TimeSpan Time { get; set; }//זמן הנסיעה בין שתי התחנות
        public bool IsDeleted { get; set; }// האם מחוק
    }
}
