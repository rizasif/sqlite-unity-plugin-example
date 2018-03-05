package pk.codistan.background;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.util.Log;

/**
 * Created by rizas on 3/5/2018.
 */

public class AlarmRepitition extends BroadcastReceiver {
    private static final String CodistanTag= "Codistan: " + AlarmRepitition.class.getSimpleName();

    @Override
    public void onReceive(Context context, Intent intent) {
        Log.v(CodistanTag, "Alarm for LifeLog...");

        Intent ll24Service = new Intent(context, BgService.class);

        if (Build.VERSION.SDK_INT > Build.VERSION_CODES.N_MR1) {
            context.startForegroundService(ll24Service);
        } else {
            context.startService(ll24Service);
        }
    }
}
