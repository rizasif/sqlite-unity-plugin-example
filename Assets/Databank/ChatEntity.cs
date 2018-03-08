using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
	public class ChatEntity {

		public string _id;
		public string _chatId;
		public string _number;
        public String _type;
        public string _Lat;
        public string _Lng;
        public string _Message;
        public string _ReceiverId;
		public string _SenderId;
        public string _SenderName;
		public string _Status;
		public string _Time;
		public string _TimeStamp;
        public String _dateCreated; // Auto generated timestamp

        public ChatEntity(string id, string chatId, string number, String type, string Lat, string Lng, string Message,
                                 string ReceiverId, string SenderId, string SenderName, string Status, string Time, string TimeStamp)
        {
            _id = id;
			_chatId = chatId;
            _type = type;
            _Lat = Lat;
            _Lng = Lng;
            _Message = Message;
			_ReceiverId = ReceiverId;
			_SenderId = SenderId;
			_SenderName = SenderName;
			_Status = Status;
			_Time = Time;
			_TimeStamp = TimeStamp;
			_dateCreated = "";
        }

        public ChatEntity(string id, string chatId, string number, String type, string Lat, string Lng, string Message,
                                string ReceiverId, string SenderId, string SenderName, string Status, string Time,
								string TimeStamp, string dateCreated)
        {
            _id = id;
			_chatId = chatId;
            _type = type;
            _Lat = Lat;
            _Lng = Lng;
            _Message = Message;
			_ReceiverId = ReceiverId;
			_SenderId = SenderId;
			_SenderName = SenderName;
			_Status = Status;
			_Time = Time;
			_TimeStamp = TimeStamp;
			_dateCreated = dateCreated;
        }

        public static ChatEntity getFakeChat()
        {
            return new ChatEntity("0", "x", "Test_Type", "0.0", "0.0", "-", "-", "-", "-", "-", "-","-", "-");
        }

		public static ChatEntity getFakeChat(int id)
        {
            return new ChatEntity(id.ToString(), "x", "Test_Type", "0.0", "0.0", "-", "-", "-", "-", "-", "-","-", "-");
        }
	}
}
