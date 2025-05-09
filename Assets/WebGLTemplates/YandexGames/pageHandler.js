

window.addEventListener('beforeunload', () => {
    unity.SendMessage('WebHandler', 'JS_OnPageBeforeUnload');
});


document.addEventListener('visibilitychange', () => {
    if (document.visibilityState === 'hidden') {
        unity.SendMessage('WebHandler', 'JS_OnPageHidden');
    }
    console.log("Visibility changed:", document.visibilityState);
});



