using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank{
	public class EventEntity : MonoBehaviour {
		public string _id;
        public string _country;
        public string _endDate;
        public string _image;
		public bool _isHunt;
		public bool _isOTP;
		public bool _isPromo;
		public bool _isTeam;
		public string _LongDescription;
		public string _name;
		public string _promocode;
		public string _shortDescription;
		public bool _singleLogin;
		public string _startDate;
		public string _counter_solved;
		public string _counter_totalvoucher;
		public string _counter_unsolved;
		public string _geoTag_lat;
		public string _geoTag_lng;
		public string _geotag_radius;
		public string _solved_markers;
		public string _unsolved_markers;
        public string _dateCreated; // Auto generated timestamp

        public EventEntity(	string id,
							string country,
							string endDate,
							string image,
							bool isHunt,
							bool isOTP,
							bool isPromo,
							bool isTeam,
							string LongDescription,
							string name,
							string promocode,
							string shortDescription,
							bool singleLogin,
							string startDate,
							string counter_solved,
							string counter_totalvoucher,
							string counter_unsolved,
							string geoTag_lat,
							string geoTag_lng,
							string geotag_radius,
							string solved_markers,
							string unsolved_markers,
							string dateCreated)
        {
            _id = id;
			_country = country;
			_endDate = endDate;
			_image = image;
			_isHunt = isHunt;
			_isOTP = isOTP;
			_isPromo = isPromo;
			_isTeam = isTeam;
			_LongDescription = LongDescription;
			_name = name;
			_promocode = promocode;
			_shortDescription = shortDescription;
			_singleLogin = singleLogin;
			_startDate = startDate;
			_counter_solved = counter_solved;
			_counter_totalvoucher = counter_totalvoucher;
			_counter_unsolved = counter_unsolved;
			_geoTag_lat = geoTag_lat;
			_geoTag_lng = geoTag_lng;
			_geotag_radius = geotag_radius;
			_solved_markers = solved_markers;
			_unsolved_markers = unsolved_markers;
			_dateCreated = dateCreated;
        }

        public EventEntity(	string id,
							string country,
							string endDate,
							string image,
							bool isHunt,
							bool isOTP,
							bool isPromo,
							bool isTeam,
							string LongDescription,
							string name,
							string promocode,
							string shortDescription,
							bool singleLogin,
							string startDate,
							string counter_solved,
							string counter_totalvoucher,
							string counter_unsolved,
							string geoTag_lat,
							string geoTag_lng,
							string geotag_radius,
							string solved_markers,
							string unsolved_markers)
        {
            _id = id;
			_country = country;
			_endDate = endDate;
			_image = image;
			_isHunt = isHunt;
			_isOTP = isOTP;
			_isPromo = isPromo;
			_isTeam = isTeam;
			_LongDescription = LongDescription;
			_name = name;
			_promocode = promocode;
			_shortDescription = shortDescription;
			_singleLogin = singleLogin;
			_startDate = startDate;
			_counter_solved = counter_solved;
			_counter_totalvoucher = counter_totalvoucher;
			_counter_unsolved = counter_unsolved;
			_geoTag_lat = geoTag_lat;
			_geoTag_lng = geoTag_lng;
			_geotag_radius = geotag_radius;
			_solved_markers = solved_markers;
			_unsolved_markers = unsolved_markers;
			_dateCreated = "";
        }

		public string ToDbString(){
			string result = "'";
			result += _id + "','";
			result += _country + "','";
			result += _endDate + "','";
			result += _image + "',";
			result += Convert.ToInt32(_isHunt) + ",";
			result += Convert.ToInt32(_isOTP) + ",";
			result += Convert.ToInt32(_isPromo) + ",";
			result += Convert.ToInt32(_isTeam) + ",'";
			result += _LongDescription + "','";
			result += _name + "','";
			result += _promocode + "','";
			result += _shortDescription + "',";
			result += Convert.ToInt32(_singleLogin) + ",'";
			result += _startDate + "','";
			result += _counter_solved + "','";
			result += _counter_totalvoucher + "','";
			result += _counter_unsolved + "','";
			result += _geoTag_lat + "','";
			result += _geoTag_lng + "','";
			result += _geotag_radius + "','";
			result += _solved_markers + "','";
			result += _unsolved_markers + "'";
			return "( " + result + " )";
		}
	}
}
