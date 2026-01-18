window.wakeLockAPI = {
    wakeLock: null,
    
    requestWakeLock: async function() {
        try {
            if ('wakeLock' in navigator) {
                this.wakeLock = await navigator.wakeLock.request('screen');
                console.log('Wake Lock is active');
                
                this.wakeLock.addEventListener('release', () => {
                    console.log('Wake Lock was released');
                });
            } else {
                console.log('Wake Lock API not supported');
            }
        } catch (err) {
            console.log(`Wake Lock request failed: ${err.message}`);
        }
    },
    
    releaseWakeLock: async function() {
        if (this.wakeLock !== null) {
            await this.wakeLock.release();
            this.wakeLock = null;
            console.log('Wake Lock released');
        }
    }
};

document.addEventListener('visibilitychange', async () => {
    if (window.wakeLockAPI.wakeLock !== null && document.visibilityState === 'visible') {
        await window.wakeLockAPI.requestWakeLock();
    }
});
