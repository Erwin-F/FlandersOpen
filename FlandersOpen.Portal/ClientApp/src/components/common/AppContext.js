import React from "react";

export const AppContext = React.createContext({
    ajaxCounter: 0,
    ajaxStarted: () => {},
    ajaxEnded: () => {},
    fullWidth: false
});