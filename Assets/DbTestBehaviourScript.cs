using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;

public class DbTestBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LocationDb mLocationDb = new LocationDb();

		//Add Data
		mLocationDb.addData(new LocationEntity("0", "AR", "0.001", "0.007"));
		mLocationDb.addData(new LocationEntity("1", "AR", "0.002", "0.006"));
		mLocationDb.addData(new LocationEntity("2", "AR", "0.003", "0.005"));
		mLocationDb.addData(new LocationEntity("3", "AR", "0.004", "0.004"));
		mLocationDb.addData(new LocationEntity("4", "AR", "0.005", "0.003"));
		mLocationDb.addData(new LocationEntity("5", "AR", "0.006", "0.002"));
		mLocationDb.addData(new LocationEntity("6", "AR", "0.007", "0.001"));
		mLocationDb.close();


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

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
