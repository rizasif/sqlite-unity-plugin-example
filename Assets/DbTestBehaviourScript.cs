using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;

public class DbTestBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LocationDb mLocationDb = new LocationDb();

		try{
			mLocationDb.deleteAllData();
			mLocationDb = new LocationDb();
		} catch(UnityException e){
			Debug.Log(e.Message);
		}

		//Add Data
		mLocationDb.addData(new LocationEntity("0", "AR", "0.001", "0.007", "-", "-", "-"));
		mLocationDb.addData(new LocationEntity("1", "AR", "0.002", "0.006", "-", "-", "-"));
		mLocationDb.addData(new LocationEntity("2", "AR", "0.003", "0.005", "-", "-", "-"));
		mLocationDb.addData(new LocationEntity("3", "AR", "0.004", "0.004", "-", "-", "-"));
		mLocationDb.addData(new LocationEntity("4", "AR", "0.005", "0.003", "-", "-", "-"));
		mLocationDb.addData(new LocationEntity("5", "AR", "0.006", "0.002", "-", "-", "-"));
		mLocationDb.addData(new LocationEntity("6", "AR", "0.007", "0.001", "-", "-", "-"));

		mLocationDb.setRowByString("6", new LocationEntity("6", "AR", "0.008", "0.000", "-", "-", "-"));
		mLocationDb.close();

		EventDb mEventDb = new EventDb();

		try{
			mEventDb.deleteAllData();
			mEventDb = new EventDb();
		} catch(UnityException e){
			Debug.Log(e.Message);
		}

		mEventDb.addData(new EventEntity("0", "","","",false,false,false,false,"","","","",false,"","","","","","","","","",""));
		mEventDb.addData(new EventEntity("1", "","","",false,false,false,false,"","","","",false,"","","","","","","","","",""));
		mEventDb.addData(new EventEntity("2", "","","",false,false,false,false,"","","","",false,"","","","","","","","","",""));

		mEventDb.setRowByString("1",new EventEntity("2", "new_data","","",false,false,false,false,"","","","",false,"","","","","","","","","",""));
		mEventDb.close();

		ChatDb mChatDb = new ChatDb();

		try{
			mChatDb.deleteAllData();
			mChatDb = new ChatDb();
		} catch(UnityException e){
			Debug.Log(e.Message);
		}

		//Add Data
		mChatDb.addData(ChatEntity.getFakeChat(0));
		mChatDb.addData(ChatEntity.getFakeChat(1));
		mChatDb.addData(ChatEntity.getFakeChat(2));
		mChatDb.addData(ChatEntity.getFakeChat(3));
		mChatDb.addData(ChatEntity.getFakeChat(4));

		mChatDb.setRowByString("4", ChatEntity.getFakeChat(6));
		mChatDb.close();

		FriendsDb mFriendsDb = new FriendsDb();

		try{
			mFriendsDb.deleteAllData();
			mFriendsDb = new FriendsDb();
		} catch(UnityException e){
			Debug.Log(e.Message);
		}

		//Add Data
		mFriendsDb.addData(FriendsEntity.getFakeFriend(0));
		mFriendsDb.addData(FriendsEntity.getFakeFriend(1));
		mFriendsDb.addData(FriendsEntity.getFakeFriend(2));
		mFriendsDb.addData(FriendsEntity.getFakeFriend(3));

		mFriendsDb.setRowByString("3", FriendsEntity.getFakeFriend(3));
		mFriendsDb.close();

		//Fetch All Data
		LocationDb mLocationDb2 = new LocationDb();
		System.Data.IDataReader reader = mLocationDb2.getAllData();

		int fieldCount = reader.FieldCount;
		List<LocationEntity> myList = new List<LocationEntity>();
		while (reader.Read())
		{
			LocationEntity entity = new LocationEntity(	reader[0].ToString(), 
														reader[1].ToString(), 
														reader[2].ToString(),
														reader[3].ToString(), 
														reader[4].ToString(),
														reader[5].ToString(),
														reader[6].ToString(),
														reader[7].ToString());

			Debug.Log("id: " + entity._id);
			myList.Add(entity);
		}

		EventDb mEventDb2 = new EventDb();
		System.Data.IDataReader reader2 = mEventDb2.getAllData();

		fieldCount = reader2.FieldCount;
		while (reader2.Read())
		{
			EventEntity entity = new EventEntity(	reader2[0].ToString(),
													reader2[1].ToString(),
													reader2[2].ToString(),
													reader2[3].ToString(),
													(bool)reader2[4],
													(bool)reader2[5],
													(bool)reader2[6],
													(bool)reader2[7],
													reader2[8].ToString(),
													reader2[9].ToString(),
													reader2[10].ToString(),
													reader2[11].ToString(),
													(bool)reader2[12],
													reader2[13].ToString(),
													reader2[14].ToString(),
													reader2[15].ToString(),
													reader2[16].ToString(),
													reader2[17].ToString(),
													reader2[18].ToString(),
													reader2[19].ToString(),
													reader2[20].ToString(),
													reader2[21].ToString(),
													reader2[22].ToString());

			Debug.Log("id: " + entity._id);
		}


		Debug.Log("Get Data: " + mEventDb2.getDataByString("1")[1].ToString());

		ChatDb mChatDb2 = new ChatDb();
		System.Data.IDataReader reader3 = mChatDb2.getAllData();

		Debug.Log("Chat Db Enteries: " + mChatDb2.getNumOfRows()[0].ToString());

		while (reader3.Read())
		{
			ChatEntity entity = new ChatEntity(		reader3[0].ToString(), 
													reader3[1].ToString(), 
													reader3[2].ToString(),
													reader3[3].ToString(), 
													reader3[4].ToString(),
													reader3[5].ToString(),
													reader3[6].ToString(),
													reader3[7].ToString(),
													reader3[8].ToString(),
													reader3[9].ToString(),
													reader3[10].ToString(),
													reader3[11].ToString(),
													reader3[12].ToString());

			Debug.Log("id: " + entity._id);
		}

		FriendsDb mFriendsDb2 = new FriendsDb();
		System.Data.IDataReader reader4 = mFriendsDb2.getAllData();

		Debug.Log("Chat Db Enteries: " + mFriendsDb2.getNumOfRows()[0].ToString());

		while (reader4.Read())
		{
			FriendsEntity entity = new FriendsEntity(	reader4[0].ToString(), 
														reader4[1].ToString(), 
														reader4[2].ToString(),
														reader4[3].ToString(),
														reader4[4].ToString(),
														reader4[5].ToString());

			Debug.Log("id: " + entity._id);
		}

		mEventDb2.close();
		mLocationDb2.close();
		mChatDb2.close();
		mFriendsDb2.close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
