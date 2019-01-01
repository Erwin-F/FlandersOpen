import assign from "object-assign";
import { userService } from "../services/userService";

export default class RegisterPageHelper {
    constructor(context) {
        this.context = context;
        this.appContext = context.props.appContext;
    }

    register(user) {
        userService.register(user);

        const history = this.context.props.history;
        history.push("/");
    }
}