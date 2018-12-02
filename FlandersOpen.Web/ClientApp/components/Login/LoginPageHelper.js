import assign from "object-assign";
import { userService } from "../services/userService";

export default class LoginPageHelper {
    constructor(context) {
        this.context = context;
        this.appContext = context.props.appContext;
    }

    logout() {
        userService.logout();
    }

    login(username, password) {
        userService.login(username, password);
    }
}