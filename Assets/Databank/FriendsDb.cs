using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank{ 
	public class FriendsDb : SqliteHelper {
		private const String CodistanTag = "Codistan: FriendsDb:\t";
        
        private const String TABLE_NAME = "Friends";
        private const String KEY_ID = "id";
		private const String KEY_CHAT_ID = "chatId";
		private const String KEY_FREIND_NAME = "FirendName";
		private const String KEY_UNREAD_COUNT = "UnreadMessageCount";
		private const String KEY_IMAGE = "Image";
		private const String KEY_DATE = "date";
        private String[] COLUMNS = new String[] {	KEY_ID,
													KEY_CHAT_ID,
													KEY_FREIND_NAME,
													KEY_UNREAD_COUNT,
													KEY_IMAGE,
													KEY_DATE};

        public FriendsDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_CHAT_ID + " TEXT, " +
                KEY_FREIND_NAME + " TEXT, " +
                KEY_UNREAD_COUNT + " TEXT, " +
                KEY_IMAGE + " TEXT, " +
                KEY_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(FriendsEntity friend)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_CHAT_ID + ", "
                + KEY_FREIND_NAME + ", "
                + KEY_UNREAD_COUNT + ", "
                + KEY_IMAGE + " ) "

                + "VALUES ( '"
                + friend._id + "', '"
                + friend._ChatId + "', '"
                + friend._FriendName + "', '"
                + friend._UnreadMesaageCount + "', '"
                + friend._Image + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public void setRowByString(string id, FriendsEntity updateEntity){
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "UPDATE " + TABLE_NAME
                + " SET "
                + KEY_CHAT_ID + " = '" + updateEntity._ChatId + "', "
                + KEY_FREIND_NAME + " = '" + updateEntity._FriendName + "', "
                + KEY_UNREAD_COUNT + " = '" + updateEntity._UnreadMesaageCount + "', "
                + KEY_IMAGE + " = '" + updateEntity._Image + "' "
                
                + "WHERE " + KEY_ID + " = " + id;

            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(CodistanTag + "Getting Location: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(CodistanTag + "Deleting Location: " + id);

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

        public IDataReader getLatestTimeStamp()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
	}
}
