﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7232_5482
{
    class BusLine : IComparable<BusLine>
    {
        public int BusNumber { get; set; }
        private List<BusLineStation> stations;
        public List<BusLineStation> Stations
        {
            get { return stations; }
            set { stations = value; }
        }
        public Area Area { get; set; }
        public BusLineStation FirstStation { get => Stations[0]; set => Stations[0] = value; }
        public BusLineStation LastStation { get => Stations[stations.Count - 1]; set => Stations[stations.Count - 1] = value; }
        public BusLineStation this[int index] => stations[index];
        public BusLine(List<BusLineStation> L, int BusNumber, /*BusLineStation first, BusLineStation last,*/ Area a = Area.JERUSALEM)
        {
            this.Stations = L;
            this.BusNumber = BusNumber;
            this.FirstStation = Stations[0];
            this.LastStation = Stations[Stations.Count - 1];
            this.Area = a;
        }
        public int FindIndex(string PrevStation)
        {
            int index = 0;
            foreach (BusLineStation b in Stations)
            {

                if (b.BusStationKey == PrevStation)
                {
                    return index;
                }
                index++;
            }
            throw new BusException("the previous station entered doesn't exist");
        }
        public bool CheckStationExist(string numstat)
        {
            bool flag = false;
            foreach (BusLineStation b in Stations)
            {

                if (b.BusStationKey == numstat)
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;

        }
        public void AddStations(BusStation b)
        {
            //int choose;

                Insert Choice;
                Console.WriteLine("Choose where you want to add a station from the following options:");
                Console.WriteLine(@"Enter 1 to choose FIRST, 2 to choose MIDDLE and 3 to choose LAST");
                bool success = Enum.TryParse(Console.ReadLine(), out Choice);

                while (success == false)
                {
                    Console.WriteLine("enter your choice again");
                    Console.WriteLine(@"Enter 1 to choose FIRST, 2 to choose MIDDLE and 3 to choose LAST");
                    success = Enum.TryParse(Console.ReadLine(), out Choice);
                }
                
               /* CheckStationExist(b)*/;//צריך לעשות חריגה ביציאה מהפונקציה הזאת
            if (Choice == Insert.FIRST)
            {
                BusLineStation newstat = new BusLineStation(b.BusStationKey, " ", 0);
                newstat.Address();
                newstat.Latitude = b.Latitude;
                newstat.Longitude = b.Longitude;
                Stations.Insert(0,newstat);
                FirstStation = newstat;
                Console.WriteLine("Enter the distance of the new station from the next station (km)");
                double distanceFromPrev = GetDoubleNum();
                stations[1].My_Distance = distanceFromPrev;
                stations[1].My_Time = newstat.TravelTime(distanceFromPrev);
                //Console.WriteLine("The station was successfully added");
            }
            else if (Choice == Insert.MIDDLE)
            {
                Console.WriteLine("Enter the code of the station before the station you want to add");
                int PrevStation = GetIntNum();
                int index = FindIndex(PrevStation.ToString());
                Console.WriteLine("Type the distance of the new station from the previous station (km)");
                double distanceFromPrev = GetDoubleNum();
                BusLineStation newstat = new BusLineStation(b.BusStationKey, " ", distanceFromPrev);
                newstat.Address();
                newstat.Latitude = b.Latitude;
                newstat.Latitude = b.Longitude;
                stations.Insert(++index, newstat);
                stations[index + 1].My_Distance = stations[index + 1].My_Distance - newstat.My_Distance;
                stations[index + 1].My_Time = TimeSpan.FromMinutes(stations[index + 1].My_Distance);
                // Console.WriteLine("The station was successfully added");

            }
            else
            {
                Console.WriteLine("Type the distance of the new station from the previous station (km)");
                double distanceFromPrev = GetDoubleNum();
                BusLineStation newstat = new BusLineStation(b.BusStationKey, " ", distanceFromPrev);
                newstat.Address();
                newstat.Latitude = b.Latitude;
                newstat.Latitude = b.Longitude;
                stations.Add(newstat);
                //Console.WriteLine(LastStation +"stat1");
                LastStation = newstat;
                //Console.WriteLine(LastStation + "stat2");
                //Console.WriteLine("The station was successfully added");


            }

                //Console.WriteLine("Enter 1 if you want to add another station, if you want to exit enter 0");
                //choose = int.Parse(Console.ReadLine());
                //while (choose != 0 && choose != 1)
                //{
                //    choose = int.Parse(Console.ReadLine());
                //    if (choose != 0 && choose != 1)
                //        Console.WriteLine("ERROR, try enter number again");
                //}
            
           
            return;
        }
        public double timeBetween(BusLineStation one, BusLineStation two)
        {
            return one.Time.Subtract(two.Time).TotalMinutes;
        }
        public void DeleteStation(string StatNum)
        {
            int index = 0;
            foreach (BusLineStation b in Stations)
            {
                if (b.BusStationKey == StatNum)
                {
                    Stations.RemoveAt(index);
                    return;
                }
                index++;
            }
            throw new BusException("Sorry, this station doesn't exist in this bus line");
        }
        public bool CheckStationInBusLIne(string StationKey)
        {
            bool flag = false;
            for (int i = 0; i < this.stations.Count; i++)
            {
                if (this.stations[i].BusStationKey == StationKey)
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }
        public double DistanceBetweenStations(BusLineStation stat1, BusLineStation stat2)
        {
            int index1 = FindIndex(stat1.BusStationKey);
            int index2 = FindIndex(stat2.BusStationKey);
            if (index1 == -1 || index2 == -1)
            {
                throw new BusException("the previous station entered doesn't exist on the route of this line bus");
            }
            double distance = 0;
            for (int i = index1 + 1; i < index2 + 1; i++)
            {
                distance = distance + Stations[i].My_Distance;
            }
            return distance;

        }    
        public BusLine SubRoute(string firstStat, string lastStat)
        {
            int indexFirst = FindIndex(firstStat);
            int indexLast = FindIndex(lastStat);
            //if (location1 == -1 || location2 == -1)
            //{
            //    Console.WriteLine("ERROR!the station doesn't exist on the route of this bus line ");
            //    return null;
            //}
            //else
            //{
                List<BusLineStation> allStations = new List<BusLineStation>();
                for (int i = indexFirst; i < indexLast + 1; i++)
                {
                    allStations.Add(Stations[i]);
                }
                BusLine bus = new BusLine(Stations = allStations, BusNumber = this.BusNumber, Area = this.Area);
                return bus;
            //}

        }
        public TimeSpan TimeBetweenStations(BusLineStation bus1, BusLineStation bus2)//the function gets 2 stations, and returns the travel time between them.
        {
            if (!(CheckStationExist(bus1.BusStationKey) && CheckStationExist(bus2.BusStationKey)))
            {
                throw new BusException("ERROR, one or more of the stations entered don't exist in the bus line");
            }
            TimeSpan time = TimeSpan.Zero;
            int index1 = FindIndex(bus1.BusStationKey);
            int index2 = FindIndex(bus2.BusStationKey);
            for (int i = ++index1; i <= index2; i++)
            {
                time += stations[i].My_Time;
            }
            return time;
        }
        public int CompareTo(BusLine other)//the function compares between two bus lines
        {
            TimeSpan t1 = TimeBetweenStations(this.FirstStation, this.LastStation);
            TimeSpan t2 = other.TimeBetweenStations(other.FirstStation, other.LastStation);
            return t1.CompareTo(t2);
        }
        public BusLine(int busnum, string firststat, string laststat)
        {
            this.BusNumber = busnum;
            this.FirstStation.BusStationKey = firststat;
            this.LastStation.BusStationKey = laststat;
        }
        public double GetDoubleNum()
        {
            bool success = true;
            double num;
            do
            {
                if (!success)
                    Console.WriteLine("ERROR! try enter number again");
                success = double.TryParse(Console.ReadLine(), out num);
            }
            while (!success);
            return num;
        }
        public int GetIntNum()
        {
            bool success = true;
            int num;
            do
            {
                if (!success)
                    Console.WriteLine("ERROR! try enter number again");
                success = int.TryParse(Console.ReadLine(), out num);
            }
            while (!success);
            return num;
        }
        public override string ToString()
        {


            return String.Format(" Bus Number: {0}, Area: {1}, ListOfStation:{2}", BusNumber, Area, PrintStations());

        }
        public string PrintStations()
        {
            string station = " ";
            foreach (BusLineStation b in Stations)
            {
                station += b.BusStationKey + " ";
            }
            return station;
        }
    }
}



