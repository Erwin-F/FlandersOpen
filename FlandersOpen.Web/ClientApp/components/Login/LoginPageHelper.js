import assign from "object-assign";
import { userService } from "../services/userService";

import userApi from "../../api/userApi";

export default class LoginPageHelper {
    constructor(context) {
        this.context = context;
        this.appContext = context.props.appContext;
    }

    logout() {
        localStorage.removeItem('user');
    }

    login(username, password) {
        this.appContext.ajaxStarted();
        userApi.login(username, password)
            .then((response) => {
                this.appContext.ajaxEnded();
                const user = response.data;

                if (user && user.token) {
                    localStorage.setItem('user', JSON.stringify(user));
                    //TODO Redirect to home
                } else {
                    //TODO show error
                }
            })
            .catch((ex) => {
                this.appContext.ajaxEnded();
                //TODO do something with error
            });

        userService.login(username, password);
    }
}