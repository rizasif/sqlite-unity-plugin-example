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
		mLocationDb.addData(new LocationEntity("0", "AR", "0.001", "0.007"));
		mLocationDb.addData(new LocationEntity("1", "AR", "0.002", "0.006"));
		mLocationDb.addData(new LocationEntity("2", "AR", "0.003", "0.005"));
		mLocationDb.addData(new LocationEntity("3", "AR", "0.004", "0.004"));
		mLocationDb.addData(new LocationEntity("4", "AR", "0.005", "0.003"));
		mLocationDb.addData(new LocationEntity("5", "AR", "0.006", "0.002"));
		mLocationDb.addData(new LocationEntity("6", "AR", "0.007", "0.001"));

		mLocationDb.setRowByString("6", new LocationEntity("6", "AR", "0.008", "0.000"));
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
														reader[4].ToString());

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

		mEventDb2.close();
		mLocationDb2.close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
