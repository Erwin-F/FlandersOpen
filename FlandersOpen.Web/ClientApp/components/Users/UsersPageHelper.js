import assign from "object-assign";
import userApi from "../../api/userApi";

export default class UserPageHelper {
    constructor(context) {
        this.context = context;
        this.appContext = context.props.appContext;
    }

    init() {
        this.appContext.ajaxStarted();
        userApi.getall()
            .then((response) => {
                this.appContext.ajaxEnded();
                const data = response.data;
                const users = data.result;

                if (users) {
                    this.context.setState({ users: users });
                } else {
                    this.context.setState({ authenticationError: data.errorMessage }); //TODO Toastr Error
                }
            })
            .catch((ex) => {
                this.appContext.ajaxEnded();
                this.context.setState({ authenticationError: "Username or Password wrong" }); //TODO Toastr Error
            });
    }

    deleteUser(id){
        userApi.delete(id)
            .then((response) => {
                this.appContext.ajaxEnded();

                const users = this.context.state.users.filter(user => user.id !== id);
                this.context.setState({ users: users });
            })
            .catch((ex) => {
                this.appContext.ajaxEnded();
            });
    }
}