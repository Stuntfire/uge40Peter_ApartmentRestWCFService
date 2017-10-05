using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace uge40Peter_ApartmentRestWCFService
{

    /// <summary>
    /// Link til Peter's opgaven: https://drive.google.com/open?id=0B5TZmSs3KA0xQzJuMXRJTFF0TTQ
    /// </summary>

    public class Apartment
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private int _postalcode;

        public int Postalcode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }

        private int _size;

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private int _noRoom;

        public int NoRoom
        {
            get { return _noRoom; }
            set { _noRoom = value; }
        }

        private bool _washingMachine;

        public bool WashingMachine
        {
            get { return _washingMachine; }
            set { _washingMachine = value; }
        }

        private bool _dishwasher;

        public bool Dishwasher
        {
            get { return _dishwasher; }
            set { _dishwasher = value; }
        }

        public Apartment(int id, int price, string location, int postalcode, int size, int noRoom, bool washingMachine, bool dishwasher)
        {
            Id = id;
            Price = price;
            Location = location;
            Postalcode = postalcode;
            Size = size;
            NoRoom = noRoom;
            WashingMachine = washingMachine;
            Dishwasher = dishwasher;
        }

        public Apartment()
        {
            
        }
    }
}