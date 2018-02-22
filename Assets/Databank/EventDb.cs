using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank{
	public class EventDb : SqliteHelper {
		private const String CodistanTag = "Codistan: EventDb:\t";
        
        private const String TABLE_NAME = "Events";
        private const string KEY_ID = "id";
        private const string KEY_COUNTRY = "country";
        private const string KEY_ENDDATE = "enddate";
        private const string KEY_IMAGE = "image";
		private const string KEY_HUNT = "hunt";
		private const string KEY_OTP = "otp";
		private const string KEY_PROMO = "promo";
		private const string KEY_TEAM = "team";
		private const string KEY_LONG_DESC = "longdescription";
		private const string KEY_NAME = "name";
		private const string KEY_PROMOCODE = "promocode";
		private const string KEY_SHORT_DESC = "shortdescription";
		private const string KEY_SINGLE_LOGIN = "singlelogin";
		private const string KEY_STARTDATE = "startdate";
		private const string KEY_COUNT_SOLVED = "countsolved";
		private const string KEY_COUNT_VOUCHERS = "countvouchers";
		private const string KEY_COUNT_UNSOLVED = "countunsolved";
		private const string KEY_LAT = "lat";
		private const string KEY_LNG = "lng";
		private const string KEY_RAD = "rad";
		private const string KEY_SOLVED = "solved";
		private const string KEY_UNSOLVED = "unsolved";
        private const string KEY_DATE = "date_created";

        private String[] COLUMNS = new String[] {	KEY_ID,
													KEY_COUNTRY,
													KEY_ENDDATE,
													KEY_IMAGE,
													KEY_HUNT,
													KEY_OTP,
													KEY_PROMO,
													KEY_TEAM,
													KEY_LONG_DESC,
													KEY_NAME,
													KEY_PROMOCODE,
													KEY_SHORT_DESC,
													KEY_SINGLE_LOGIN,
													KEY_STARTDATE,
													KEY_COUNT_SOLVED,
													KEY_COUNT_VOUCHERS,
													KEY_COUNT_UNSOLVED,
													KEY_LAT,
													KEY_LNG,
													KEY_RAD,
													KEY_SOLVED,
													KEY_UNSOLVED,
													KEY_DATE};

        public EventDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_COUNTRY + " TEXT, " +
				KEY_ENDDATE + " TEXT, " +
				KEY_IMAGE + " TEXT, " +
				KEY_HUNT + " BOOLEAN, " +
				KEY_OTP + " BOOLEAN, " +
				KEY_PROMO + " BOOLEAN, " +
				KEY_TEAM + " BOOLEAN, " +
				KEY_LONG_DESC + " TEXT, " +
				KEY_NAME + " TEXT, " +
				KEY_PROMOCODE + " TEXT, " +
				KEY_SHORT_DESC + " TEXT, " +
				KEY_SINGLE_LOGIN + " BOOLEAN, " +
				KEY_STARTDATE + " TEXT, " +
				KEY_COUNT_SOLVED + " TEXT, " +
				KEY_COUNT_VOUCHERS + " TEXT, " +
				KEY_COUNT_UNSOLVED + " TEXT, " +
				KEY_LAT + " TEXT, " +
				KEY_LNG + " TEXT, " +
				KEY_RAD + " TEXT, " +
				KEY_SOLVED + " TEXT, " +
				KEY_UNSOLVED + " TEXT, " +
                KEY_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(EventEntity eventEntity)
        {
            IDbCommand dbcmd = getDbCommand();

			string command = "INSERT INTO " + TABLE_NAME + " ( ";
			for (int i=0; i< COLUMNS.Length-1; i++){
				command += COLUMNS[i] + ",";
			}
			command = command.Remove(command.Length-1);
            command += " ) VALUES ";
			command += eventEntity.ToDbString();
			
			dbcmd.CommandText = command;
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(CodistanTag + "Getting Event: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public void setRowByString(string id, EventEntity updateEntity){
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "UPDATE " + TABLE_NAME
                + " SET "

                + KEY_COUNTRY + " = '" + updateEntity._country + "',"
                + KEY_ENDDATE + " = '" + updateEntity._endDate + "',"
                + KEY_IMAGE + " = '" + updateEntity._image + "',"
                + KEY_HUNT + " = " + Convert.ToInt32(updateEntity._isHunt) + ","
                + KEY_OTP + " = " + Convert.ToInt32(updateEntity._isOTP) + ","
                + KEY_PROMO + " = " + Convert.ToInt32(updateEntity._isPromo) + ","
                + KEY_TEAM + " = " + Convert.ToInt32(updateEntity._isTeam) + ","
                + KEY_LONG_DESC + " = '" + updateEntity._LongDescription + "',"
                + KEY_NAME + " = '" + updateEntity._name + "',"
                + KEY_PROMOCODE + " = '" + updateEntity._promocode + "',"
                + KEY_SHORT_DESC + " = '" + updateEntity._shortDescription + "',"
                + KEY_SINGLE_LOGIN + " = " + Convert.ToInt32(updateEntity._singleLogin) + ","
                + KEY_STARTDATE + " = '" + updateEntity._startDate + "',"
                + KEY_COUNT_SOLVED + " = '" + updateEntity._counter_solved + "',"
                + KEY_COUNT_VOUCHERS + " = '" + updateEntity._counter_totalvoucher + "',"
                + KEY_COUNT_UNSOLVED + " = '" + updateEntity._counter_unsolved + "',"
                + KEY_LAT + " = '" + updateEntity._geoTag_lat + "',"
                + KEY_LNG + " = '" + updateEntity._geoTag_lng + "',"
                + KEY_RAD + " = '" + updateEntity._geotag_radius + "',"
                + KEY_SOLVED + " = '" + updateEntity._solved_markers + "',"
                + KEY_UNSOLVED + " = '" + updateEntity._unsolved_markers + "'"
                
                + "WHERE " + KEY_ID + " = " + id;

            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(CodistanTag + "Deleting Event: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

		public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log(CodistanTag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

        public IDataReader getNearestLocation(LocationInfo loc)
        {
            Debug.Log(CodistanTag + "Getting nearest event from: "
                + loc.latitude + ", " + loc.longitude);
            IDbCommand dbcmd = getDbCommand();

            string query =
                "SELECT * FROM "
                + TABLE_NAME
                + " ORDER BY ABS(" + KEY_LAT + " - " + loc.latitude 
                + ") + ABS(" + KEY_LNG + " - " + loc.longitude + ") ASC LIMIT 1";

            dbcmd.CommandText = query;
            return dbcmd.ExecuteReader();
        }

        public IDataReader getLatestTimeStamp()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
	}
}
