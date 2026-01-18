window.focusMode = {
    dotNetRef: null,

    register: function (dotNetRef) {
        this.dotNetRef = dotNetRef;
        document.addEventListener('keydown', this.handleKeyDown);
    },

    unregister: function () {
        document.removeEventListener('keydown', this.handleKeyDown);
        this.dotNetRef = null;
    },

    handleKeyDown: function (e) {
        if (!window.focusMode.dotNetRef) return;

        switch (e.key) {
            case "ArrowRight":
                window.focusMode.dotNetRef.invokeMethodAsync('NextStep');
                break;
            case "ArrowLeft":
                window.focusMode.dotNetRef.invokeMethodAsync('PreviousStep');
                break;
            case "Escape":
                window.focusMode.dotNetRef.invokeMethodAsync('Close');
                break;
        }
    }
};
