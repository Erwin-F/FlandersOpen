import assign from "object-assign";
import { showToastrError, showToastrSuccess, showToastrWarning } from "../../util/toastr";

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
                const data = response.data;
                const user = data.result;

                if (user && user.token) {
                    localStorage.setItem('user', JSON.stringify(user));

                    this.context.setState({ authenticationError: "" });

                    const history = this.context.props.history;
                    history.push("/");
                } else {
                    this.context.setState({ authenticationError: data.errorMessage });
                    showToastrError(data.errorMessage);
                }
            })
            .catch((ex) => {
                this.appContext.ajaxEnded();
                this.context.setState({ authenticationError: "Username or Password wrong" });
                showToastrError(ex);
            });
    }
}