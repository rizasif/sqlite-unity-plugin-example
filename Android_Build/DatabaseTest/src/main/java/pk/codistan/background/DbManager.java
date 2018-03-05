package pk.codistan.background;


import android.content.Context;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.database.sqlite.SQLiteCursorDriver;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteQuery;
import android.util.Log;

import java.io.File;

/**
 * Created by rizas on 3/5/2018.
 */

public class DbManager {
    private static final String CodistanTag  = "Codistan: " + DbManager.class.getSimpleName();

    public DbManager(Context context){

        String path = "/storage/emulated/0/Android/data/pk.codistan.database/files/madhunt_db";
        File file = new File(path);
        if(file.exists()){
            Log.i(CodistanTag, "File Exists");
            SQLiteDatabase db = SQLiteDatabase.openDatabase(path, null,
                    SQLiteDatabase.OPEN_READONLY);
            String selectQuery = "SELECT  * FROM " + "Locations";
            Cursor cursor = db.rawQuery(selectQuery, null);

            if (cursor.moveToFirst()) {
                do {
                    Log.i(CodistanTag, "Data Read: " + cursor.getString(0));
                } while (cursor.moveToNext());
            }

            db.close();

        } else {
            Log.i(CodistanTag, "File DOES NOT Exists");
        }
    }
}
