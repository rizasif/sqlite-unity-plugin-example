using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank{ 
	public class ChatDb : SqliteHelper {
		private const String CodistanTag = "Codistan: ChatDb:\t";
        
        private const String TABLE_NAME = "Chats";
        private const String KEY_ID = "id";
		private const String KEY_CHAT_ID = "ChatId";
		private const string KEY_NUMBER = "number";
        private const String KEY_TYPE = "type";
        private const String KEY_LAT = "Lat";
        private const String KEY_LNG = "Lng";
        private const String KEY_MESSAGE = "Message";
        private const String KEY_REC_ID = "ReceiverId";
        private const String KEY_SEN_ID = "SenderId";
		private const String KEY_SEN_NAME= "SenderName";
		private const String KEY_STATUS = "Status";
		private const string KEY_TIME = "Time";
		private const string KEY_TIME_STAMP = "Timestamp";
		private const String KEY_DATE = "date";
        private String[] COLUMNS = new String[] {	KEY_ID,
													KEY_CHAT_ID,
													KEY_NUMBER, 
													KEY_TYPE, 
													KEY_LAT, 
													KEY_LNG, 
													KEY_MESSAGE, 
													KEY_REC_ID,
													KEY_SEN_ID,
													KEY_SEN_NAME,
													KEY_STATUS,
													KEY_TIME,
													KEY_TIME_STAMP,
													KEY_DATE	};

        public ChatDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
				KEY_CHAT_ID + " TEXT, " +
				KEY_NUMBER + " TEXT, " +
                KEY_TYPE + " TEXT, " +
                KEY_LAT + " TEXT, " +
                KEY_LNG + " TEXT, " +
                KEY_MESSAGE + " TEXT, " +
                KEY_REC_ID + " TEXT, " +
                KEY_SEN_ID + " TEXT, " +
				KEY_SEN_NAME + " TEXT, " +
				KEY_STATUS + " TEXT, " +
				KEY_TIME + " TEXT, " +
				KEY_TIME_STAMP + " TEXT, " +
                KEY_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(ChatEntity chat)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
				+ KEY_CHAT_ID + ", "
				+ KEY_NUMBER + ", "
                + KEY_TYPE + ", "
                + KEY_LAT + ", "
                + KEY_LNG + ", "
                + KEY_MESSAGE + ", "
                + KEY_REC_ID + ", "
				+ KEY_SEN_ID + ", "
				+ KEY_SEN_NAME + ", "
				+ KEY_STATUS + ", "
				+ KEY_TIME + ", "
                + KEY_TIME_STAMP + " ) "

                + "VALUES ( '"
                + chat._id + "', '"
				+ chat._chatId + "', '"
				+ chat._number + "', '"
                + chat._type + "', '"
                + chat._Lat + "', '"
                + chat._Lng + "', '"
                + chat._Message + "', '"
                + chat._ReceiverId + "', '"
				+ chat._SenderId + "', '"
				+ chat._SenderName + "', '"
				+ chat._Status + "', '"
				+ chat._Time + "', '"
                + chat._TimeStamp + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }


        public void setRowByString(string id, ChatEntity updateEntity){
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "UPDATE " + TABLE_NAME
                + " SET "
				+ KEY_CHAT_ID + " = '" + updateEntity._chatId + "', "
				+ KEY_NUMBER + " = '" + updateEntity._number + "', "
                + KEY_TYPE + " = '" + updateEntity._type + "', "
                + KEY_LAT + " = '" + updateEntity._Lat + "', "
                + KEY_LNG + " = '" + updateEntity._Lng + "', "
                + KEY_MESSAGE + " = '" + updateEntity._Message + "', "
                + KEY_REC_ID + " = '" + updateEntity._ReceiverId + "', "
				+ KEY_SEN_ID + " = '" + updateEntity._SenderId + "', "
				+ KEY_SEN_NAME + " = '" + updateEntity._SenderName + "', "
				+ KEY_STATUS + " = '" + updateEntity._Status + "', "
				+ KEY_TIME + " = '" + updateEntity._Time + "', "
                + KEY_TIME_STAMP + " = '" + updateEntity._TimeStamp + "' "
                
                + "WHERE " + KEY_ID + " = " + id;

            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(CodistanTag + "Getting chat: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(CodistanTag + "Deleting chat: " + id);

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

		public override IDataReader getNumOfRows(){
			return base.getNumOfRows(TABLE_NAME);
		}

        public IDataReader getNearestLocation(LocationInfo loc)
        {
            Debug.Log(CodistanTag + "Getting nearest centoid from: "
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
