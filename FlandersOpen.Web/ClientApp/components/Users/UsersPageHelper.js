import assign from "object-assign";
import { userService } from "../services/userService";

export default class UserPageHelper {
    constructor(context) {
        this.context = context;
        this.appContext = context.props.appContext;
    }

    init() {
        this.appContext.ajaxStarted();

        userService.getAll()
            .then((response) => {
                this.appContext.ajaxEnded();

                const users = assign({}, response.data);
                this.context.setState({
                    users: users
                });
            })
            .catch((err) => {
                this.appContext.ajaxEnded();
            });
    }
}