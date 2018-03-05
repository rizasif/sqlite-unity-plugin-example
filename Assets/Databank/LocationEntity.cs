using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
	public class LocationEntity {

		public string _id;
        public String _type;
        public string _Lat;
        public string _Lng;
        public string _Target;
        public string _InfoActivity;
        public string _Points;
        public String _dateCreated; // Auto generated timestamp

        public LocationEntity(string id, String type, string Lat, string Lng, string Target,
                                 string InfoActivity, string Points)
        {
            _id = id;
            _type = type;
            _Lat = Lat;
            _Lng = Lng;
            _Target = Target;
            _InfoActivity = InfoActivity;
            _Points = Points;
			_dateCreated = "";
        }

        public LocationEntity(string id, String type, string Lat, string Lng, string Target,
                                 string InfoActivity, string Points, string dateCreated)
        {
            _id = id;
            _type = type;
            _Lat = Lat;
            _Lng = Lng;
            _Target = Target;
            _InfoActivity = InfoActivity;
            _Points = Points;
			_dateCreated = dateCreated;
        }

        public static LocationEntity getFakeLocation()
        {
            return new LocationEntity("0", "Test_Type", "0.0", "0.0", "-", "-", "-");
        }
	}
}
