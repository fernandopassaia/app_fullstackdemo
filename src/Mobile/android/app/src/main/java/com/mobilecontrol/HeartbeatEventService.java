package com.appfullstackdemo;

import android.content.Intent;
import android.os.Bundle;
//import android.support.annotation.Nullable;
import androidx.annotation.Nullable;
import com.facebook.react.HeadlessJsTaskService;
import com.facebook.react.bridge.Arguments;
import com.facebook.react.jstasks.HeadlessJsTaskConfig;

public class HeartbeatEventService extends HeadlessJsTaskService {
    @Nullable
    protected HeadlessJsTaskConfig getTaskConfig(Intent intent) {
        Bundle extras = intent.getExtras();
        return new HeadlessJsTaskConfig("Heartbeat", extras != null ? Arguments.fromBundle(extras) : null, 5000, true);
    }
}