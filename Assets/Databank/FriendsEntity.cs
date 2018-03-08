using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
	public class FriendsEntity {

		public string _id;
        public String _ChatId;
        public string _FriendName;
        public string _UnreadMesaageCount;
        public string _Image;
        public String _dateCreated; // Auto generated timestamp

        public FriendsEntity(string id, String ChatId, string FriendName, string UnreadMesaageCount,
                                 string Image)
        {
            _id = id;
            _ChatId = ChatId;
			_FriendName = FriendName;
			_UnreadMesaageCount = UnreadMesaageCount;
			_Image = Image;
			_dateCreated = "";
        }

        public FriendsEntity(string id, String ChatId, string FriendName, string UnreadMesaageCount,
                                 string Image, string dateCreated)
        {
            _id = id;
            _ChatId = ChatId;
			_FriendName = FriendName;
			_UnreadMesaageCount = UnreadMesaageCount;
			_Image = Image;
			_dateCreated = dateCreated;
        }

        public static FriendsEntity getFakeFriend()
        {
            return new FriendsEntity("0", "Test_Type", "0.0", "0.0", "-", "-");
        }

        public static FriendsEntity getFakeFriend(int id)
        {
            return new FriendsEntity(id.ToString(), "Test_Type", "0.0", "0.0", "-", "-");
        }
	}
}
