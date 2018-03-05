package pk.codistan.background;

import android.app.Notification;
import android.app.Service;
import android.content.Intent;
import android.os.Build;
import android.os.IBinder;
import android.util.Log;

public class BgService extends Service {
    private static final String CodistanTag= "Codistan: " + BgService.class.getSimpleName();

    public BgService() {
    }

    @Override
    public IBinder onBind(Intent intent) {
        Log.i(CodistanTag, "Binding Service");
        return null;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        if (Build.VERSION.SDK_INT >= 26) // 26 = Build.VERSION_CODES.O
        {
            startForeground(1, new Notification());
        }
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {

        Log.v(CodistanTag, "onStartCommand");

        DbManager manager = new DbManager(this);

        return super.onStartCommand(intent, flags, startId);
    }
}
